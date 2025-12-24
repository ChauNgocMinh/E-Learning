using E_Learning.ViewModel;
using MediatR;

namespace E_Learning.Cqrs.Queries.SubmissionQueries
{
    public record GetSubmissionResultQuery(Guid SubmissionId)
        : IRequest<SubmissionResultViewModel>;
}
