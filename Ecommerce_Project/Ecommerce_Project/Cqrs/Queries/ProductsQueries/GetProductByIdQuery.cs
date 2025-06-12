using Ecommerce_Project.Models.Entities;
using MediatR;
using System;
namespace Ecommerce_Project.Cqrs.Queries.ProductsQueries;
public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;