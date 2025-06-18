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
    public async Task<Product> GetAsync(int id)
    {
        Product product = await _repository.GetProductAsync(id);

        return product;
    }
}
