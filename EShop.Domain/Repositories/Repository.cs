namespace EShop.Domain.Repositories;

using System.Diagnostics;
using System.Runtime.InteropServices;
using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

public class Repository : IRepository
{
    //Dependency injection
    private readonly DataContext _context;
    public Repository(DataContext dataContext)
    {
        _context = dataContext;
    }

    //Get all products from the database
    public async Task<List<Product>> GetAllProductsAsync()
    {
        List<Product> products = await _context.Products.ToListAsync();

        return products;
    }
    //Get a single product from the database
    public async Task<Product> GetProductAsync(int id)
    {
        Product product = await _context.Products.Where(x => x.id == id).FirstOrDefaultAsync();

        return product;
    }
    //Add a single product to the database
    public async Task<Exception> AddProductAsync(Product product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }

    //Get client data from database
    public async Task<Clients> GetClientAsync(int id)
    {
        Clients client = await _context.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();

        return client;
    }

}
