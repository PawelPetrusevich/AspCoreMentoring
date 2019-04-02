using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AutoMapper;

namespace AspCoreMentoring.SharedInfrastructure.AutoMapperRules
{
    public class ProductDtoRules : Profile
    {
        public ProductDtoRules()
        {
            CreateMap<Product, ProductViewDto>();
            CreateMap<ProductViewDto, Product>()
                .ForMember(dest => dest.CategoryId, member => member.MapFrom(from => from.Category.Id))
                .ForMember(dest => dest.SupplierId, member => member.MapFrom(from => from.Supplier.Id))
                .ForMember(dest => dest.Category, member => member.Ignore())
                .ForMember(dest => dest.Supplier, member => member.Ignore());
        }
    }
}