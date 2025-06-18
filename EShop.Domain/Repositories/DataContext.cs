using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    //Here define DbSets:
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Clients> Clients { get; set; }
}
