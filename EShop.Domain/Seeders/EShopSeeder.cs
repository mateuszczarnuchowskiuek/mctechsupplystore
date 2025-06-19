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
                    new Product { id=1, name = "Cobi", ean = "1234", price=245.04m, stock=5, sku="ABC123XYZ", category=new Category{id=1, name="klocki"}},
                    new Product { id=2, name = "Duplo", ean = "431", price=21.36m,stock=53, sku="PROD-45678", category=new Category{id=2, name="agd"}},
                    new Product { id=3, name = "Lego", ean = "12212", price=399.99m,stock=24, sku="ELEC-98765-TV", category=new Category{id=5, name="agd"}}
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
                    new Clients { Id=1, Name = "Mark", Surname = "aaa"},
                    new Clients { Id=2, Name = "Marry", Surname = "bbb"},
                    new Clients { Id=3, Name = "Leon", Surname = "ccc" }
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
                    new Category { id=7, name = "klocki"},
                    new Category { id=8, name = "rtv"},
                    new Category { id=9, name = "agd"}
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
                    new Cart { id=7, products = new List<Product>(), client = new Clients{Id = 19, Name = "May"} },
                    new Cart{ id=8 },
                    new Cart { id=9 }
                };

                context.Carts.AddRange(product);
                context.SaveChanges();
            }
        }
    }
}
