using AutoMapper;
using Business.Dtos.Request.Product;
using Business.Dtos.Response.Product;
using Entities.Concrete;

namespace Business.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductRequest, Product>().ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();
            CreateMap<DeleteProductRequest, Product>().ReverseMap();
            CreateMap<Product, GetAllProductResponse>().ReverseMap();
        }
    }
}
