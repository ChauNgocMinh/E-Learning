using AutoMapper;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListeningQueryHandlers
{
    public class SubmitListeningExerciseHandler(ApplicationDbContext _context, IMapper _mapper) :
        IRequestHandler<SubmitListeningExerciseCommand, SubmissionResultViewModel>
    {
        public async Task<SubmissionResultViewModel> Handle(
            SubmitListeningExerciseCommand request,
            CancellationToken cancellationToken)
        {
            var model = request.Model; 

   
        var questions = await _context.ExerciseListenings
                .Where(x => x.ExerciseId == model.ExerciseId)
                .OrderBy(x => x.OrderNumber)
            .ToListAsync(cancellationToken);

          
        var submission = new ExerciseSubmission
        {
            Id = Guid.NewGuid(),
                ExerciseId = model.ExerciseId,
            UserId = request.UserId,
            TotalScore = 0
        };

     
            foreach (var question in questions)
        {
                model.Answers.TryGetValue(question.Id, out var answerText);

                var selected = string.IsNullOrEmpty(answerText)
                ? ' '
                : answerText[0];

                submission.Details.Add(new ExerciseSubmissionDetail
            {
                Id = Guid.NewGuid(),
                SubmissionId = submission.Id,
                    ExerciseListeningId = question.Id,
                    SelectedOption = selected,
                    IsCorrect = selected == question.CorrectOption
                });
            }

            if (detail.IsCorrect)
                submission.TotalScore++;

            submission.TotalScore = (short)submission.Details.Count(x => x.IsCorrect);

        _context.ExerciseSubmissions.Add(submission);
        await _context.SaveChangesAsync(cancellationToken);

            submission = await _context.ExerciseSubmissions
                .Include(s => s.Details)
                .ThenInclude(d => d.ExerciseListening)
                .FirstAsync(s => s.Id == submission.Id, cancellationToken);
             
            var vm = _mapper.Map<SubmissionResultViewModel>(submission);
            vm.SubmissionId = submission.Id;

            return vm;
    }
}
}