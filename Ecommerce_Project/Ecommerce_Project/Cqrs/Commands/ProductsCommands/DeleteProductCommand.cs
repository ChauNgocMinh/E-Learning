using MediatR;

namespace Ecommerce_Project.Cqrs.Commands.ProductsCommands;
public record DeleteProductCommand(Guid Id) : IRequest<bool>;