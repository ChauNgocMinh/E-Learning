using E_Learning.Models.Entities;
using MediatR;
using System;
namespace E_Learning.Cqrs.Queries.ProductsQueries;
public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;