using MediatR;
namespace E_Learning.Cqrs.Commands.ProductsCommands;
public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<bool>;
