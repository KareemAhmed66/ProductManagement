using AutoMapper;
using CRUD.DTOS;
using CRUD.Models;
using CRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)//Dependency Injection
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productsDTO = _mapper.Map<List<ProductDto>>(products);// removes the Catygory from the Product
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDTO = _mapper.Map<ProductDto>(product);// removes the Catygory from the Product
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDto productDto)
        {            

            var productEntity = _mapper.Map<ProductEntity>(productDto);
            await _productRepository.CreateAsync(productEntity);

            return Ok("Product created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("no Product for this id");
            }
            product.Name = productDto.Name;
            product.Description = productDto.Description;


            var productEntity = _mapper.Map<ProductEntity>(productDto);
            productEntity.Id = id;//to update the same product

            await _productRepository.UpdateAsync(productEntity);

            return Ok("Product updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("no Product for this id");
            }
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _productRepository.DeleteAsync(productEntity);

            return Ok("Product deleted successfully");
        }





    }
}
