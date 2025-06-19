using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

public interface IRepository
{
    //Products
    public Task<List<Product>> GetAllProductsAsync();
    public Task<Product> GetProductAsync(int id);
    public Task<Exception> AddProductAsync(Product product);
    public Task<Exception> UpdateProductAsync(Product product);
    public Task<Exception> DeleteProductAsync(int id);

    //Clients
    public Task<Clients> GetClientAsync(int id);
}
