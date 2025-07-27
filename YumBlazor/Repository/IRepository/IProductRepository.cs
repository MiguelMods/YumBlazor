using YumBlazor.Data.Entities;

namespace YumBlazor.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product?> GetByIdAsync(long id);
        public Task<Product?> AddAsync(Product product);
        public Task<Product?> UpdateAsync(Product pategory);
        public Task<bool> DeleteAsync(long id);
    }
}
