using AutoMapper;
using Ecommerce_Project.Mappings.ProductMappings;
namespace Ecommerce_Project.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ToProductMappings.ConfigureProfile(this);
    }
}