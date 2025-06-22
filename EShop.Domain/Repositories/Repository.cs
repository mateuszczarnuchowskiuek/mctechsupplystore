namespace EShop.Domain.Repositories;

using System.Diagnostics;
using System.Dynamic;
using System.Runtime.InteropServices;
using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    #region Products

    //Get all products from the database


    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _context.Products.Include(g => g.Category).ToListAsync();
    }
    //Get a single product from the database
    public async Task<Product> GetProductAsync(int id)
    {
        Product product = await _context.Products.Where(x => x.Id == id).Include(g => g.Category).FirstOrDefaultAsync();

        return product;
    }
    //Add a single product to the database
    public async Task<Exception> AddProductAsync(Product product)
    {
        var t = await _context.Products.Where(x => x.Id == product.Id).FirstOrDefaultAsync();
        if (t != null)
            return new ProductAlreadyExistsException();
        try
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
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
    public async Task<Exception> UpdateProductAsync(int id, Product product)
    {
        try
        {
            product.UpdatedAt = DateTime.UtcNow;
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
        Product product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (product == null)
            return new ProductNotFoundException();
        if (product.Deleted == true)
            return null;
        try
        {
            product.Deleted = true;
            product.UpdatedAt = DateTime.UtcNow;
            _context.Products.Update(product);  //as far as I remember we're supposed to do this insead of actually deleting the product (correct me if i'm wrong)
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }
    #endregion Products

    //Clients
    #region Clients


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
    #endregion Clients

    //Categories
    #region Categories

    //Get single category data from database
    public async Task<Category> GetCategoryAsync(int id)
    {
        Category category = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

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

    //Delete Category from database
    public async Task<Exception> DeleteCategoryAsync(int id)
    {
        Category category = await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (category == null)
            return new ProductNotFoundException();
        if (category.Deleted == true)
            return null;
        try
        {
            category.Deleted = true;
            category.UpdatedAt = DateTime.UtcNow;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }

    //Update a Category
    public async Task<Exception> UpdateCategoryAsync(int id, Category category)
    {
        try
        {
            category.UpdatedAt = DateTime.UtcNow;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }
    #endregion Categories

    //Carts
    #region Carts

    //Get single cart data from database
    public async Task<Cart> GetCartAsync(int id)
    {
        Cart product = await _context.Carts.Where(x => x.id == id).Include(g => g.client).Include(g => g.products).FirstOrDefaultAsync();

        return product;
    }

    //Get all cart from database

    public async Task<List<Cart>> GetAllCartsAsync()
    {
        List<Cart> products = await _context.Carts.Include(g => g.client).Include(g => g.products).ToListAsync();

        return products;
    }

    //Add a cart to database

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

    //Delete Cart from database
    public async Task<Exception> DeleteCartAsync(int id)
    {
        Cart cart = await _context.Carts.Where(x => x.id == id).FirstOrDefaultAsync();
        if (cart == null)
            return new ProductNotFoundException();
        if (cart.Deleted == true)
            return null;
        try
        {
            cart.Deleted = true;
            cart.UpdatedAt = DateTime.UtcNow;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }
    //Update a Cart
    public async Task<Exception> UpdateCartAsync(int id, Cart cart)
    {
        try
        {
            cart.UpdatedAt = DateTime.UtcNow;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return e;
        }
        return null;
    }
    #endregion Carts
}
