using EShop.Domain.Models;

namespace EShop.Application.Services;

public interface IProductService
{
    public Task<Product> GetAsync(int id);
}
