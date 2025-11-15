using E_Learning.Cqrs.Commands.ProductsCommands;
using E_Learning.Infrastructure.Persistence;
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsCommandHandlers;

public class CreateProductHandler(ApplicationDbContext _context) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}