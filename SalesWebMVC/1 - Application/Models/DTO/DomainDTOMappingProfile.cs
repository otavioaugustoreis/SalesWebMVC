using AutoMapper;
using SalesWebMVC.Models.DTO;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Models.DTO
{
    public class DomainDTOMappingProfile : Profile
    {
        public  DomainDTOMappingProfile() 
        {
            CreateMap<SellerEntity, SellerEntityDTOResponse>().ReverseMap();
            CreateMap<SellerEntity, SellerEntityDTORequest>().ReverseMap();
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();
        }
    }
}
