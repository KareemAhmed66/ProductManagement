using AutoMapper;
using CRUD.DTOS;
using CRUD.Models;

namespace CRUD.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
        }
    }
}
