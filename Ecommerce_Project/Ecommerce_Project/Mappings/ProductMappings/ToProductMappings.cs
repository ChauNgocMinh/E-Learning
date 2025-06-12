using AutoMapper;
using Ecommerce_Project.Cqrs.Commands.ProductsCommands;
using Ecommerce_Project.Models.Entities;

namespace Ecommerce_Project.Mappings.ProductMappings;
public static class ToProductMappings
{
    public static void ConfigureProfile(Profile profile)
    {
        profile.CreateMap<Product, CreateProductCommand>().ReverseMap();
    }
}
