/*using AutoMapper;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

namespace E_Learning.Mappings.ListeningMappings
{
    public class ListeningMappingProfile : Profile
    {
        public ListeningMappingProfile()
        {
            CreateMap<SubmissionDetail, SubmissionDetailResultViewModel>();

            CreateMap<ExerciseListening, SubmissionDetailResultViewModel>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText))
                .ForMember(dest => dest.OptionA, opt => opt.MapFrom(src => src.OptionA))
                .ForMember(dest => dest.OptionB, opt => opt.MapFrom(src => src.OptionB))
                .ForMember(dest => dest.OptionC, opt => opt.MapFrom(src => src.OptionC))
                .ForMember(dest => dest.OptionD, opt => opt.MapFrom(src => src.OptionD))
                .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectOption.ToString()))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.Explanation));
        }
    }
}
*/