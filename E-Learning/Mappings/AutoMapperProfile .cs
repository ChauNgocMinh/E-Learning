using AutoMapper;
using E_Learning.Mappings.ProductMappings;
namespace E_Learning.Mappings;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ToProductMappings.ConfigureProfile(this);
    }
}