namespace EShop.Domain.Seeders
{
    public interface IEShopSeeder
    {
        Task SeedProducts();

        Task SeedClients();
    }
}
