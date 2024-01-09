using AutoMapper;
using CRUD.Data;
using CRUD.DTOS;
using CRUD.Models;
using CRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
            private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)//Dependency Injection
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesDTO = _mapper.Map<List<CategoryDto>>(categories);// removes the products from the category
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDTO = _mapper.Map<CategoryDto>(category);// removes the products from the category
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);

            return Ok("Category created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("no Category for this id");
            }
            category.Name = categoryDto.Name;

            var categoryEntity = _mapper.Map<CategoryEntity>(categoryDto);
            categoryEntity.Id = id;
            await _categoryRepository.UpdateAsync(categoryEntity);

            return Ok(category);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("no Category for this id");
            }
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            await _categoryRepository.DeleteAsync(categoryEntity);

            return Ok("Category deleted successfully");
        }
       
    }
}
