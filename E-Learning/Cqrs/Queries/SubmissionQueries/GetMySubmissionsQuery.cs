using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.SubmissionQueries
{
    public record GetMySubmissionsQuery(Guid UserId)
        : IRequest<List<MySubmissionItemViewModel>>;
}
