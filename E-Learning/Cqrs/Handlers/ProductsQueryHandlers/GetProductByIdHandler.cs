using E_Learning.Cqrs.Queries.ProductsQueries;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
 
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsQueryHandlers;

public class GetProductByIdHandler(ApplicationDbContext _context) : IRequestHandler<GetProductByIdQuery, Product?>
{


    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.FindAsync(request.Id);
    }
}
