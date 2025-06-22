using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

public interface IRepository
{
    //Products
    public Task<List<Product>> GetAllProductsAsync();
    public Task<Product> GetProductAsync(int id);
    public Task<Exception> AddProductAsync(Product product);
    public Task<Exception> UpdateProductAsync(int id, Product product);
    public Task<Exception> DeleteProductAsync(int id);

    //Clients
    public Task<Clients> GetClientAsync(int id);

    public Task<List<Clients>> GetAllClientsAsync();


    //Categories

    public Task<Category> GetCategoryAsync(int id);

    public Task<List<Category>> GetAllCategoriesAsync();

    public Task<Exception> AddCategoryAsync(Category category);

    public Task<Exception> DeleteCategoryAsync(int id);

    public Task<Exception> UpdateCategoryAsync(int id, Category category);

    //Cart

    public Task<Cart> GetCartAsync(int id);

    public Task<List<Cart>> GetAllCartsAsync();

    public Task<Exception> AddCartAsync(Cart product);

    public Task<Exception> DeleteCartAsync(int id);

    public Task<Exception> UpdateCartAsync(int id, Cart cart);





}
