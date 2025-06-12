using Ecommerce_Project.Cqrs.Queries.ProductsQueries;
using Ecommerce_Project.Infrastructure.Persistence;
using Ecommerce_Project.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Cqrs.Handlers.ProductsQueryHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetAllProductsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}