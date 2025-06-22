using EShop.Domain.Repositories;
using EShop.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace EShop.Domain.Seeders
{
    public class EShopSeeder(DataContext context) : IEShopSeeder
    {
        public async Task SeedProducts()
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { name = "Cobi", ean = "1234", price=245.04m, stock=5, sku="ABC123XYZ", category=new Category{name="klocki"}},
                    new Product { name = "Duplo", ean = "431", price=21.36m,stock=53, sku="PROD-45678", category=new Category{name="agd"}},
                    new Product { name = "Lego", ean = "12212", price=399.99m,stock=24, sku="ELEC-98765-TV", category=new Category{name="agd"}}
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
        public async Task SeedClients()
        {
            if (!context.Clients.Any())
            {
                var clients = new List<Clients>
                {
                    new Clients { Name = "Mark", Surname = "aaa"},
                    new Clients { Name = "Marry", Surname = "bbb"},
                    new Clients { Name = "Leon", Surname = "ccc" }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }

        }
        public async Task SeedCategory()
        {
            if (!context.Categories.Any())
            {
                var category = new List<Category>
                {
                    new Category { name = "klocki"},
                    new Category { name = "rtv"},
                    new Category { name = "agd"}
                };

                context.Categories.AddRange(category);
                context.SaveChanges();
            }
        }

        public async Task SeedCart()
        {
            if (!context.Carts.Any())
            {
                var product = new List<Cart>
                {
                    new Cart { products = new List<Product>(), client = new Clients{Name = "May"} },
                    new Cart{ products = new List<Product>(), client = new Clients{Name = "Mandy"} },
                    new Cart { products = new List<Product>(), client = new Clients{Name = "Marta"} }
                };

                context.Carts.AddRange(product);
                context.SaveChanges();
            }
        }
    }
}
