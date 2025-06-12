using Ecommerce_Project.Cqrs.Queries.ProductsQueries;
using Ecommerce_Project.Infrastructure.Persistence;
using Ecommerce_Project.Models.Entities;
using MediatR;

namespace Ecommerce_Project.Cqrs.Handlers.ProductsQueryHandlers;

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