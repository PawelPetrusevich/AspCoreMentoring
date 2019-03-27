using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.Service.Common.DTO;
using AutoMapper;

namespace AspCoreMentoring.SharedInfrastructure.AutoMapperRules
{
    public class SupplierDtoRules : Profile
    {
        public SupplierDtoRules()
        {
            CreateMap<Supplier, SupplierLinkDto>()
                .ForMember(dest => dest.Id, member => member.MapFrom(from => from.SupplierId))
                .ForMember(dest => dest.Name, member => member.MapFrom(from => from.CompanyName));
        }
    }
}