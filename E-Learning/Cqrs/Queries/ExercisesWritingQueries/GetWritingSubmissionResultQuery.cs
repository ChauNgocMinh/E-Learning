using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesWritingQueries;

public record GetWritingSubmissionResultQuery(Guid SubmissionId)
    : IRequest<WritingResultViewModel>;
