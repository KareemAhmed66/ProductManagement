using CRUD.Data;
using CRUD.Models;
using CRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CRUD.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)//Dependency Injection
        {
            _context = context;
        }

        public async Task<List<CategoryEntity>> GetAllAsync()
        {
                var cat = await _context.Categories.Include(c=> c.Products).ToListAsync();
            //cat.ForEach(c => Console.WriteLine(c.Products));

            return cat;
        }

        public async Task<CategoryEntity> GetByIdAsync(int id)
        {
            var cat= await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(p => p.Id == id);//can be null
            //cat.Products.ForEach(c => Console.WriteLine(c.Name));
            return cat;
        }

            public async Task CreateAsync(CategoryEntity categoryEntity)
        {
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryEntity categoryEntity)
        {

            _context.Categories.Update(categoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategoryEntity categoryEntity)
        {
            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();
        }

    }
}
