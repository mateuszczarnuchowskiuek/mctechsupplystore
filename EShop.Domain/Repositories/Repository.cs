namespace EShop.Domain.Repositories;

using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

public class Repository : IRepository
{
    //Dependency injection
    private readonly DataContext _context;
    public Repository(DataContext dataContext)
    {
        _context = dataContext;
    }


    //Products


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
    //Update product in the database
    public async Task<Exception> UpdateProductAsync(Product product)
    {
        try
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }
    //Delete product from the database
    public async Task<Exception> DeleteProductAsync(int id)
    {
        try
        {
            Product product = await _context.Products.Where(x => x.id == id).FirstOrDefaultAsync();
            product.deleted = true;
            _context.Products.Update(product);  //as far as I remember we're supposed to do this insead of actually deleting the product (correct me if i'm wrong)
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }


    //Clients



    //Get single client data from database
    public async Task<Clients> GetClientAsync(int id)
    {
        Clients client = await _context.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();

        return client;
    }

    //Get all clients from database

    public async Task<List<Clients>> GetAllClientsAsync()
    {
        List<Clients> clients = await _context.Clients.ToListAsync();

        return clients;
    }



    //Categories

    //Get single category data from database
    public async Task<Category> GetCategoryAsync(int id)
    {
        Category category = await _context.Categories.Where(x => x.id == id).FirstOrDefaultAsync();

        return category;
    }

    //Get all categories from database

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        List<Category> category = await _context.Categories.ToListAsync();

        return category;
    }

    //Add a category to database

    public async Task<Exception> AddCategoryAsync(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }




    //Cart


    //Get single category data from database
    public async Task<Cart> GetCartAsync(int id)
    {
        Cart product = await _context.Carts.Where(x => x.id == id).FirstOrDefaultAsync();

        return product;
    }

    //Get all categories from database

    public async Task<List<Cart>> GetAllCartsAsync()
    {
        List<Cart> products = await _context.Carts.ToListAsync();

        return products;
    }

    //Add a category to database

    public async Task<Exception> AddCartAsync(Cart product)
    {
        try
        {
            _context.Carts.Add(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }




}
