using AutoMapper;
using MyGameShopApi.Entities;
using MyGameShopApi.Models;

namespace MyGameShopApi.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(m => m.Pegi, c => c.MapFrom(s => s.Pegi.AgeCategory));

            CreateMap<Receipt, ReceiptDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
