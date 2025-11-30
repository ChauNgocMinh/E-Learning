using AutoMapper;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

namespace E_Learning.Mappings.ListeningMappings
{
    public class ListeningMappingProfile : Profile
    {
        public ListeningMappingProfile()
        {
            CreateMap<ExerciseSubmissionDetail, SubmissionDetailViewModel>()
                .ForMember(dest => dest.Question,
                    opt => opt.MapFrom(src => src.ExerciseListening.QuestionText))
                .ForMember(dest => dest.OptionA,
                    opt => opt.MapFrom(src => src.ExerciseListening.OptionA))
                .ForMember(dest => dest.OptionB,
                    opt => opt.MapFrom(src => src.ExerciseListening.OptionB))
                .ForMember(dest => dest.OptionC,
                    opt => opt.MapFrom(src => src.ExerciseListening.OptionC))
                .ForMember(dest => dest.OptionD,
                    opt => opt.MapFrom(src => src.ExerciseListening.OptionD))
                .ForMember(dest => dest.CorrectOption,
                    opt => opt.MapFrom(src => src.ExerciseListening.CorrectOption))
                .ForMember(dest => dest.OrderNumber,
                    opt => opt.MapFrom(src => src.ExerciseListening.OrderNumber));
        }
    }
}
