using E_Learning.Domain.Comon;
using E_Learning.Domain.Entities;
using MediatR;

namespace E_Learning.Cqrs.Queries.ExercisesQueries
{
    public class GetAllExercisesQuery : IRequest<ListPages<Exercise>>
    {
        /// <summary>
        /// this current page
        /// </summary>
        public short? Page { get; set; } = 1;

        /// <summary>
        /// this number of items per page
        /// </summary>
        public short? PageSize { get; set; } = 8;
    }
}
