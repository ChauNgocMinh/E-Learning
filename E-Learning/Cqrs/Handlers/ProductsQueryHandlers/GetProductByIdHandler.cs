using E_Learning.Cqrs.Queries.ProductsQueries;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Models.Entities;
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsQueryHandlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.FindAsync(request.Id);
    }
}