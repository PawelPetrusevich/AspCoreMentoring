using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AutoMapper;

namespace AspCoreMentoring.SharedInfrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}