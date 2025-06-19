using EShop.Domain.Models;

namespace EShop.Application.Services;

public interface IProductService
{
    public Task<List<Product>> GetAllAsync();
    public Task<Product> GetAsync(int id);
    public Task<Exception> AddAsync(Product product);
    public Task<Exception> UpdateAsync(Product product);
    public Task<Exception> DeleteAsync(int id);
}
