using E_Learning.Cqrs.Queries.ExercisesSpeakingQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.ViewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ExercisesSpeakingQueryHandlers
{
    public class GetAllSpeakingExerciseHandler
        : IRequestHandler<GetSpeakingExerciseQuery, SpeakingExercisePageViewModel>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSpeakingExerciseHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SpeakingExercisePageViewModel> Handle(GetSpeakingExerciseQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.ExerciseSpeakings
                .Include(x => x.Exercise)
                .OrderBy(x => x.Part)          
                .ThenBy(x => x.ExerciseId)      
                .ThenBy(x => x.OrderNumber)     
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var vm = new SpeakingExercisePageViewModel();

            vm.Parts = data
                .GroupBy(x => x.Part)
                .Select(g => new SpeakingPartViewModel
                {
                    Part = g.Key,

                    Topics = g
                        .GroupBy(q => q.Exercise)
                        .Select(topic => new SpeakingTopicViewModel
                        {
                            ExerciseId = topic.Key.Id,
                            Title = topic.Key.Title,

                            Questions = topic.Select(q => new SpeakingQuestionViewModel
                            {
                                Id = q.Id,
                                QuestionText = q.QuestionText,
                                AudioUrl = q.AudioUrl,
                                Part = q.Part,
                                OrderNumber = q.OrderNumber

                            }).ToList()

                        }).ToList()

                }).ToList();

            return vm;
        }
    }
}
