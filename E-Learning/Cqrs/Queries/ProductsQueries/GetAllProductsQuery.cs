using E_Learning.Models.Entities;
using MediatR;

namespace E_Learning.Cqrs.Queries.ProductsQueries;
public record GetAllProductsQuery : IRequest<List<Product>>;