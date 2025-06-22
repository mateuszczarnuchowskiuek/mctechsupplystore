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
                    new Product { Name = "Cobi", Ean = "1234", Price=245.04m, Stock=5, Sku="ABC123XYZ", Category=new Category{Name="klocki"}},
                    new Product { Name = "Duplo", Ean = "431", Price=21.36m,Stock=53, Sku="PROD-45678", Category=new Category{Name="agd"}},
                    new Product { Name = "Lego", Ean = "12212", Price=399.99m,Stock=24, Sku="ELEC-98765-TV", Category=new Category{Name="agd"}}
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
                    new Category { Name = "klocki"},
                    new Category { Name = "rtv"},
                    new Category { Name = "agd"}
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
