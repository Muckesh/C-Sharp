using api.Models;

namespace api.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(int id, Product product);

        Task<bool> DeleteAsync(int id);
    }
}
