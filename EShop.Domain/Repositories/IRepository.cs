using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

public interface IRepository
{
    //Products
    public Task<Product> GetProductAsync(int id);
}
