using AutoMapper;
using E_Learning.Cqrs.Commands.ProductsCommands;
using E_Learning.Models.Entities;

namespace E_Learning.Mappings.ProductMappings;
public static class ToProductMappings
{
    public static void ConfigureProfile(Profile profile)
    {
        profile.CreateMap<Product, CreateProductCommand>().ReverseMap();
    }
}
