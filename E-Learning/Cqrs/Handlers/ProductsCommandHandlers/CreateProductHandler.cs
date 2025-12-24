/*using E_Learning.Cqrs.Commands.ProductsCommands;
using E_Learning.Infrastructure.Persistence;
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsCommandHandlers;

public class CreateProductHandler(ApplicationDbContext _context) : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _context.Products.Add(product);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }
}*/
/*using E_Learning.Cqrs.Commands.ProductsCommands;
using E_Learning.Infrastructure.Persistence;
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsCommandHandlers;

public class CreateProductHandler(ApplicationDbContext _context) : IRequestHandler<CreateProductCommand, bool>
{
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _context.Products.Add(product);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }
}*/