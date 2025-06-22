using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EShop.Domain.Repositories;


public class DataContext : DbContext
{

   // public DataContext(DbContextOptions<DataContext> options) : base(options) { }
   
    public IConfiguration _config { get; set; }

    public DataContext(IConfiguration config) 
    {  
        _config = config; 
    }
    /*
     * MsSql implementation
     * 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
    */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_config.GetConnectionString("SQLiteDefault"));
    }

    //Here define DbSets:
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Clients> Clients { get; set; }

    public DbSet<Cart> Carts { get; set; }
}
