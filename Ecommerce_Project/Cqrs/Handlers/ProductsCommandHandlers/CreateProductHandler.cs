using Ecommerce_Project.Cqrs.Commands.ProductsCommands;
using Ecommerce_Project.Infrastructure.Persistence;
using MediatR;

namespace Ecommerce_Project.Cqrs.Handlers.ProductsCommandHandlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreateProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Models.Entities.Product
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