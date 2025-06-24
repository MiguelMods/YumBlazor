using YumBlazor.Data.Entities;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(long id);
        public Task<Category?> AddAsync(Category category);
        public Task<Category?> UpdateAsync(Category category);
        public Task<bool> DeleteAsync(long id);
    }
}
