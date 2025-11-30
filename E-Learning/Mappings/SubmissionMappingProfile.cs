using AutoMapper;
using E_Learning.Domain.Entities;
using E_Learning.ViewModel;

public class SubmissionMappingProfile : Profile
{
    public SubmissionMappingProfile()
    {
        CreateMap<ExerciseSubmission, SubmissionResultViewModel>()
            .ForMember(dest => dest.Details,
                       opt => opt.MapFrom(src => src.Details));
    }
}
