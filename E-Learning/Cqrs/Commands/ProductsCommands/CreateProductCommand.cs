using MediatR;

namespace E_Learning.Cqrs.Commands.ProductsCommands;
public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>;