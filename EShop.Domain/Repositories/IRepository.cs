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

    public Task<List<Clients>> GetAllClientsAsync();

    //Categorys

    public Task<Category> GetCategoryAsync(int id);

    public Task<List<Category>> GetAllCategoriesAsync();

    public Task<Exception> AddCategoryAsync(Category category);

    //Cart

    public Task<Cart> GetCartAsync(int id);

    public Task<List<Cart>> GetAllCartsAsync();

    public Task<Exception> AddCartAsync(Cart product);



}
