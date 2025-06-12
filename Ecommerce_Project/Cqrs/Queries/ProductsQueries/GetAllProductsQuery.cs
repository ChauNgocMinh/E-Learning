using Ecommerce_Project.Models.Entities;
using MediatR;

namespace Ecommerce_Project.Cqrs.Queries.ProductsQueries;
public record GetAllProductsQuery : IRequest<List<Product>>;