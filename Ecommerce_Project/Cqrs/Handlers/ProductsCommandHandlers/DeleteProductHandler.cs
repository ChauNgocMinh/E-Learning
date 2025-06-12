using Ecommerce_Project.Cqrs.Commands.ProductsCommands;
using Ecommerce_Project.Infrastructure.Persistence;
using MediatR;

namespace Ecommerce_Project.Cqrs.Handlers.ProductsCommandHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}