using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AutoMapper;

namespace AspCoreMentoring.SharedInfrastructure.AutoMapperRules
{
    public class CategoryDtoRules : Profile
    {
        public CategoryDtoRules()
        {
            CreateMap<Category, CategoryLinkDto>()
                .ForMember(dest => dest.Id, member => member.MapFrom(from => from.CategoryId))
                .ForMember(dest => dest.Name, member => member.MapFrom(from => from.CategoryName));
        }
    }
}