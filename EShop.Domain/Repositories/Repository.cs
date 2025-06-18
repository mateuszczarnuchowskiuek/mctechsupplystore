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

    //Database stuff
    public async Task<Product> GetProductAsync(int id)
    {
        Product product = await _context.Products.Where(x => x.id == id).FirstOrDefaultAsync();

        return product;
    }
}
