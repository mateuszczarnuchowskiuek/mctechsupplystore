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
                    new Product { Id=1, Name = "Cobi", Ean = "1234", Price=245.04m, Stock=5, Sku="ABC123XYZ", Category=new Category{Id=1, Name="klocki"}},
                    new Product { Id=2, Name = "Duplo", Ean = "431", Price=21.36m, Stock=53, Sku="PROD-45678", Category=new Category{Id=2, Name="agd"}},
                    new Product { Id=3, Name = "Lego", Ean = "12212", Price=399.99m, Stock=24, Sku="ELEC-98765-TV", Category=new Category{Id=5, Name="agda"}}
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
                    new Category { Id=7, Name = "klocki"},
                    new Category { Id=8, Name = "rtv"},
                    new Category { Id=9, Name = "agd"}
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
