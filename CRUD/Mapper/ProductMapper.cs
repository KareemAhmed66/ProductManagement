using AutoMapper;
using CRUD.DTOS;
using CRUD.Models;

namespace CRUD.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
                CreateMap<ProductEntity,ProductDto>()
                .ReverseMap();
        }
    }
}
