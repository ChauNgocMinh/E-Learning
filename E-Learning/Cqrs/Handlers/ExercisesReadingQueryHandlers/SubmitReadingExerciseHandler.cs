using AutoMapper;
using E_Learning.Cqrs.Commands.ExercisesReadingCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesReadingHandlers;

public class SubmitReadingExerciseHandler(ApplicationDbContext _context, IMapper _mapper) :
    IRequestHandler<SubmitReadingExerciseCommand, SubmissionResultViewModel>
{



    public async Task<SubmissionResultViewModel> Handle(
        SubmitReadingExerciseCommand request,
        CancellationToken cancellationToken)
    {
        var model = request.Model;


        var questions = await _context.ExercisesReadings
            .Where(x => x.ExerciseId == model.ExerciseId)
            .ToListAsync(cancellationToken);

        var submission = new ExerciseSubmission
        {
            Id = Guid.NewGuid(),
            ExerciseId = model.ExerciseId,
            UserId = request.UserId,
        };


        foreach (var (questionId, answerText) in model.Answers)
        {
            var question = questions.FirstOrDefault(x => x.Id == questionId);
            if (question == null) continue;

            var selected = string.IsNullOrEmpty(answerText)
                ? ' '
                : answerText[0];

            submission.Details.Add(new ExerciseSubmissionDetail
            {
                Id = Guid.NewGuid(),
                SubmissionId = submission.Id,
                ExerciseReadingId = question.Id,
                ExerciseListeningId = null,
                SelectedOption = selected,
                IsCorrect = selected == question.CorrectOption
            });

        }

        submission.TotalScore = (short)submission.Details.Count(x => x.IsCorrect);

        _context.ExerciseSubmissions.Add(submission);
        await _context.SaveChangesAsync(cancellationToken);

        submission = await _context.ExerciseSubmissions
            .Include(s => s.Details)
            .ThenInclude(d => d.ExerciseReading)
            .FirstAsync(s => s.Id == submission.Id, cancellationToken);

        var vm = _mapper.Map<SubmissionResultViewModel>(submission);
        vm.SubmissionId = submission.Id;

        return vm;
    }
}
