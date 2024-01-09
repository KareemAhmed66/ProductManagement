using CRUD.Models;

namespace CRUD.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryEntity>> GetAllAsync();
        public Task<CategoryEntity> GetByIdAsync(int id);
        public Task CreateAsync(CategoryEntity categoryEntity);
        public Task UpdateAsync(CategoryEntity categoryEntity);
        public Task DeleteAsync(CategoryEntity categoryEntity);
    }
}
