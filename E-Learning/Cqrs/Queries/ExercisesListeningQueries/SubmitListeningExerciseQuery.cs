using AutoMapper;
using E_Learning.Cqrs.Commands.ExercisesListeningCommands;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesListening
{
    public class SubmitListeningExerciseHandler
        : IRequestHandler<SubmitListeningExerciseCommand, SubmissionResultViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubmitListeningExerciseHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubmissionResultViewModel> Handle(SubmitListeningExerciseCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            // 1. Lấy danh sách câu hỏi
            var questions = await _context.ExerciseListenings
                .Where(q => q.ExerciseId == model.ExerciseId)
                .OrderBy(q => q.OrderNumber)
                .ToListAsync(cancellationToken);

            // 2. Tạo submission
            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                ExerciseId = model.ExerciseId,
                UserId = request.UserId,
                SubmittedAt = DateTime.UtcNow,
                Details = new List<SubmissionDetail>()
            };

            foreach (var question in questions)
            {
                model.Answers.TryGetValue(question.Id, out var userAnswer);
                var selected = userAnswer?.Trim()?.ToUpper() ?? "";

                bool isCorrect = selected == question.CorrectOption.ToString();

                submission.Details.Add(new SubmissionDetail
                {
                    Id = Guid.NewGuid(),
                    SubmissionId = submission.Id,
                    QuestionId = question.Id,
                    QuestionType = 0, // listening
                    UserInput = selected,
                    Score = isCorrect ? 1 : 0,
                    IsCorrect = isCorrect
                });
            }

            submission.TotalScore = (short)submission.Details.Sum(x => x.Score);

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync(cancellationToken);

            // 3. Load lại submission + details
            var saved = await _context.Submissions
                .Include(s => s.Details)
                .FirstAsync(s => s.Id == submission.Id, cancellationToken);

            // 4. Lấy thông tin bài tập
            var exercise = await _context.Exercises
                .FirstAsync(e => e.Id == saved.ExerciseId, cancellationToken);

            // 5. Map phần chung
            var vm = _mapper.Map<SubmissionResultViewModel>(saved);
            vm.ExerciseTitle = exercise.Title;
            vm.TotalQuestions = questions.Count;

            // 6. Map chi tiết từng câu bằng tuple (detail, question)
            vm.Details = saved.Details
                .Join(questions,
                      d => d.QuestionId,
                      q => q.Id,
                      (d, q) => _mapper.Map<SubmissionDetailResultViewModel>((d, q)))
                .OrderBy(d => d.OrderNumber)
                .ToList();

            return vm;
        }
    }
}
