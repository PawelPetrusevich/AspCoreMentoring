using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AutoMapper;

namespace AspCoreMentoring.SharedInfrastructure.AutoMapperRules
{
    public class ProductDtoRules : Profile
    {
        public ProductDtoRules()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.CategoryName, entity => entity.MapFrom(product => product.Category.CategoryName));
        }
        
    }
}