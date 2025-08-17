using MediatR;

namespace E_Learning.Cqrs.Commands.ProductsCommands;
public record DeleteProductCommand(Guid Id) : IRequest<bool>;