using E_Learning.Cqrs.Queries.ExercisesQueries;
using E_Learning.Domain.Comon;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace E_Learning.Cqrs.Handlers.ExercisesQueryHandlers
{
    public class GetAllExercisesHandler(ApplicationDbContext _context) : IRequestHandler<GetAllExercisesQuery, ListPages<Exercise>>
    {
        public async Task<ListPages<Exercise>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            short page = request.Page ?? 1;
            short pageSize = request.PageSize ?? 20;
            var query = _context.Exercises.OrderByDescending(x => x.CreatedAt);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new ListPages<Exercise>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}