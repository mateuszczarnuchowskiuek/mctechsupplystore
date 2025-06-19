using Microsoft.EntityFrameworkCore.Query;
using EShop.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using EShop.Domain.Models;

namespace EShop.Application.Services;

public class ProductService : IProductService
{
    //Setup (dependency injections)
    private IRepository _repository;
    public ProductService(IRepository repository)
    {
        _repository = repository;
    }

    //Actual stuff
    public async Task<List<Product>> GetAllAsync()
    {
        List<Product> products = await _repository.GetAllProductsAsync();

        return products;
    }
    public async Task<Product> GetAsync(int id)
    {
        Product product = await _repository.GetProductAsync(id);

        return product;
    }
    public async Task<Exception> AddAsync(Product product)
    {
        Exception result = await _repository.AddProductAsync(product);

        return result;
    }
    public async Task<Exception> UpdateAsync(Product product)
    {
        Exception result = await _repository.UpdateProductAsync(product);

        return result;
    }
    public async Task<Exception> DeleteAsync(int id)
    {
        Exception result = await _repository.DeleteProductAsync(id);

        return result;
    }
}
