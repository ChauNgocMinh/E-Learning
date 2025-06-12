using MediatR;

namespace Ecommerce_Project.Cqrs.Commands.ProductsCommands;
public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>;