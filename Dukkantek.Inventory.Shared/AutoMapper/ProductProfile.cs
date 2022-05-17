using AutoMapper;
using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Model.Models.Product;

namespace Dukkantek.Inventory.Shared.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ChangeProductStatusRequest>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductStatus, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();

            CreateMap<Product, SellProductRequest>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
