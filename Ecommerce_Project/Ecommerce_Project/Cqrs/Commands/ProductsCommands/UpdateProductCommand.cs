using MediatR;
namespace Ecommerce_Project.Cqrs.Commands.ProductsCommands;
public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<bool>;
