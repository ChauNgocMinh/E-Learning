/*using AutoMapper;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

namespace E_Learning.Mappings.ReadingMappings
{
    public class ReadingMappingProfile : Profile
    {
        public ReadingMappingProfile()
        {
            CreateMap<ExerciseSubmissionDetail, SubmissionDetailViewModel>()
                .ForMember(dest => dest.Question,
                    opt => opt.MapFrom(src => src.ExerciseReading.QuestionText))
                .ForMember(dest => dest.OptionA,
                    opt => opt.MapFrom(src => src.ExerciseReading.OptionA))
                .ForMember(dest => dest.OptionB,
                    opt => opt.MapFrom(src => src.ExerciseReading.OptionB))
                .ForMember(dest => dest.OptionC,
                    opt => opt.MapFrom(src => src.ExerciseReading.OptionC))
                .ForMember(dest => dest.OptionD,
                    opt => opt.MapFrom(src => src.ExerciseReading.OptionD))
                .ForMember(dest => dest.CorrectOption,
                    opt => opt.MapFrom(src => src.ExerciseReading.CorrectOption))
                .ForMember(dest => dest.OrderNumber,
                    opt => opt.MapFrom(src => src.ExerciseReading.OrderNumber));
        }
    }
}
*/