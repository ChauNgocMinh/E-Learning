using Ecommerce_Project.Cqrs.Commands.ProductsCommands;
using Ecommerce_Project.Infrastructure.Persistence;
using MediatR;

namespace Ecommerce_Project.Cqrs.Handlers.ProductsCommandHandlers;
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null) return false;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
