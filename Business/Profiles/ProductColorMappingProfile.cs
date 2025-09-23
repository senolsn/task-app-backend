using AutoMapper;
using Business.Dtos.Request.ProductColor;
using Entities.Concrete;

namespace Business.Profiles
{
    public class ProductColorMappingProfile : Profile
    {
        public ProductColorMappingProfile()
        {
            CreateMap<CreateProductColorRequest, ProductColor>().ReverseMap();
            CreateMap<DeleteProductColorRequest, ProductColor>().ReverseMap();
            CreateMap<UpdateProductColorRequest, ProductColor>().ReverseMap();
        }
    }
}
