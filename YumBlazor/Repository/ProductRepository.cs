using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Data.Entities;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class ProductRepository(ApplicationDbContext applicationDbContext) : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        public async Task<IEnumerable<Product>> GetAllAsync()
            => await applicationDbContext.Products.Include(x => x.Category).ToListAsync();

        public async Task<Product?> GetByIdAsync(long id)
            => await applicationDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Product?> AddAsync(Product product)
        {
            var entry = await applicationDbContext.Products.AddAsync(product);
            var result = await applicationDbContext.SaveChangesAsync();
            return result > 0 ? entry.Entity : null;
        }
        
        public async Task<Product?> UpdateAsync(Product pategory)
        {
            var existingProduct = await applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == pategory.Id) ?? throw new KeyNotFoundException($"Product with id {pategory.Id} not found.");
            
            existingProduct.Name = pategory.Name;
            existingProduct.Price = pategory.Price;
            existingProduct.CategoryId = pategory.CategoryId;
            
            applicationDbContext.Products.Update(existingProduct);
            
            var result =  await applicationDbContext.SaveChangesAsync();
            
            return result > 0 ? existingProduct : null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var product = await applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Product with id {id} not found.");
            applicationDbContext.Products.Remove(product);
            var result = await applicationDbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
