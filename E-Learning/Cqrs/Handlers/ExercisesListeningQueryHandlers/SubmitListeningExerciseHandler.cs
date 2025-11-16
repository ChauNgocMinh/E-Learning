using E_Learning.Cqrs.Commands.ExercisesLearningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace E_Learning.Cqrs.Handlers { 
public class SubmitListeningExerciseHandler(ApplicationDbContext _context): IRequestHandler<SubmitListeningExerciseCommand, ExerciseSubmission>
{
    public async Task<ExerciseSubmission> Handle(SubmitListeningExerciseCommand request, CancellationToken cancellationToken)
    {
        var questions = await _context.ExerciseListenings
            .Where(x => x.ExerciseId == request.ExerciseId)
            .ToListAsync(cancellationToken);
        var submission = new ExerciseSubmission
        {
            Id = Guid.NewGuid(),
            ExerciseId = request.ExerciseId,
            UserId = request.UserId,
            TotalScore = 0
        };

        foreach (var (questionId, answerText) in request.Answers)
        {
            var question = questions.FirstOrDefault(x => x.Id == questionId);
            if (question == null)
                continue;

            var selectedOption = string.IsNullOrEmpty(answerText)
                ? ' '
                : answerText[0];
            var detail = new ExerciseSubmissionDetail
            {
                Id = Guid.NewGuid(),
                SubmissionId = submission.Id,
                ExerciseListeningId = questionId,
                SelectedOption = selectedOption,
                IsCorrect = selectedOption == question.CorrectOption
            };

            if (detail.IsCorrect)
                submission.TotalScore++;

            submission.Details.Add(detail);
        }

        _context.ExerciseSubmissions.Add(submission);
        await _context.SaveChangesAsync(cancellationToken);

        return submission;
    }
}
}