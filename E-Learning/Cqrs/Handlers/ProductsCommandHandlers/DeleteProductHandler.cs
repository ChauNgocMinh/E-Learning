using E_Learning.Cqrs.Commands.ProductsCommands;
using E_Learning.Infrastructure.Persistence;
using MediatR;

namespace E_Learning.Cqrs.Handlers.ProductsCommandHandlers;

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