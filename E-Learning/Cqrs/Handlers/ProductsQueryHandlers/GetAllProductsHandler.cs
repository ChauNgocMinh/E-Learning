using E_Learning.Cqrs.Queries.ProductsQueries;
using E_Learning.Domain.Entities;
using E_Learning.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Cqrs.Handlers.ProductsQueryHandlers;

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