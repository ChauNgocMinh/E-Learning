using E_Learning.Domain.Entities;
using MediatR;

namespace E_Learning.Cqrs.Queries.ProductsQueries;
public record GetAllProductsQuery : IRequest<List<Product>>;