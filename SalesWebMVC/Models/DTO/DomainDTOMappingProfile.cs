using AutoMapper;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Models.DTO
{
    public class DomainDTOMappingProfile : Profile
    {
        public  DomainDTOMappingProfile() 
        {
            CreateMap<SellerEntity, SellerEntityDTOResponse>().ReverseMap();
            CreateMap<SellerEntity, SellerEntityDTORequest>().ReverseMap();
        }
    }
}
