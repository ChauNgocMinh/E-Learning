using AutoMapper;
using E_Learning.Application.Submissions.Snapshots;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

namespace E_Learning.Mappings.ListeningMappings
{
    public class ListeningMappingProfile : Profile
    {
        public ListeningMappingProfile()
        {
            CreateMap<ExerciseListening, QuestionResult>()
                .ForMember(d=>d.QuestionId, o=> o.MapFrom(s=>s.Id))
            .ForMember(d => d.UserAnswer, o => o.Ignore())
            .ForMember(d => d.CorrectAnswer, o => o.Ignore())
            .ForMember(d => d.IsCorrect, o => o.Ignore());

        }
    }
}
