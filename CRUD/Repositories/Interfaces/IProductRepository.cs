using CRUD.DTOS;
using CRUD.Models;

namespace CRUD.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductEntity>> GetAllAsync();
        public Task<ProductEntity> GetByIdAsync(int id);
        public Task CreateAsync(ProductEntity productEntity);
        public Task UpdateAsync(ProductEntity productEntity);
        public Task DeleteAsync(ProductEntity productEntity);
    }
}
