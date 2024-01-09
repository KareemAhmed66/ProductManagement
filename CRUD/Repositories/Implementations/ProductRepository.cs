using CRUD.Data;
using CRUD.Models;
using CRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)//Dependency Injection
        {
            _context = context;
        }


        public async Task<List<ProductEntity>> GetAllAsync()
        {
            var prod=await _context.Products.
                Include(c => c.Category)
                .ToListAsync();

            prod.ForEach(c => Console.WriteLine(c.Category.Name));
            return prod;
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
             var prod= await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id);//can be null
            Console.WriteLine(prod.Category.Name);


            return prod;
        }

        public async Task CreateAsync(ProductEntity productEntity)
        {
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductEntity productEntity)
        {

            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();
        }
            
        public async Task DeleteAsync(ProductEntity productEntity)
        {
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
