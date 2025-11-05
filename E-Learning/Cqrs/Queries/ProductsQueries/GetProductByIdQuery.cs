using E_Learning.Domain.Entities;
using MediatR;
using System;
namespace E_Learning.Cqrs.Queries.ProductsQueries;
public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;