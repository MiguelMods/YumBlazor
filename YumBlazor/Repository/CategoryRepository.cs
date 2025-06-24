using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Data.Entities;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository(ApplicationDbContext applicationDbContext) : ICategoryRepository
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await applicationDbContext.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(long id)
            => await applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Category?> AddAsync(Category category)
        {
            var entry = await applicationDbContext.Categories.AddAsync(category);
            var result = await applicationDbContext.SaveChangesAsync();
            return result > 0 ? entry.Entity : null;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await GetByIdAsync(category.Id) ?? throw new KeyNotFoundException($"Category with id {category.Id} not found.");
            existingCategory.Name = category.Name;
            applicationDbContext.Categories.Update(existingCategory);
            var result = await applicationDbContext.SaveChangesAsync();
            return result > 0 ? existingCategory : null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var category = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            _ = applicationDbContext.Categories.Remove(category);
            var result = await applicationDbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
