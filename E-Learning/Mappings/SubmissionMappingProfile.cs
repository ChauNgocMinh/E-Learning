using AutoMapper;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

namespace E_Learning.Mappings
{
    public class SubmissionMappingProfile : Profile
    {
        public SubmissionMappingProfile()
        {
           
            // --- Map Submission → SubmissionResultViewModel ---
            CreateMap<Submission, SubmissionResultViewModel>()
                .ForMember(dest => dest.SubmissionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId));

            // --- Mapping Listening ---
            //CreateMap<(SubmissionDetail detail, ExerciseListening question), SubmissionDetailResultViewModel>()
            //    .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.detail.QuestionId))
            //    .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.question.OrderNumber))
            //    .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.question.QuestionText))

            //    .ForMember(dest => dest.OptionA, opt => opt.MapFrom(src => src.question.OptionA))
            //    .ForMember(dest => dest.OptionB, opt => opt.MapFrom(src => src.question.OptionB))
            //    .ForMember(dest => dest.OptionC, opt => opt.MapFrom(src => src.question.OptionC))
            //    .ForMember(dest => dest.OptionD, opt => opt.MapFrom(src => src.question.OptionD))

            //    .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.question.CorrectOption.ToString()))
            //    .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.question.Explanation))
            //    .ForMember(dest => dest.UserInput, opt => opt.MapFrom(src => src.detail.UserInput))
            //    .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.detail.IsCorrect))
            //    .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.detail.Score));

            //// --- Mapping Reading ---
            //CreateMap<(SubmissionDetail detail, ExerciseReading question), SubmissionDetailResultViewModel>()
            //    .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.detail.QuestionId))
            //    .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.question.OrderNumber))
            //    .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.question.QuestionText))

            //    .ForMember(dest => dest.OptionA, opt => opt.Ignore())
            //    .ForMember(dest => dest.OptionB, opt => opt.Ignore())
            //    .ForMember(dest => dest.OptionC, opt => opt.Ignore())
            //    .ForMember(dest => dest.OptionD, opt => opt.Ignore())

            //    .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.question.CorrectAnswer))
            //    .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.question.Explanation))
            //    .ForMember(dest => dest.UserInput, opt => opt.MapFrom(src => src.detail.UserInput))
            //    .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.detail.IsCorrect))
            //    .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.detail.Score));
        }
    }
}
