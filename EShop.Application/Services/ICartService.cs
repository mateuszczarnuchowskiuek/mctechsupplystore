using EShop.Domain.Models;

namespace EShop.Application.Services;

public interface ICartService
{
    public Task<List<Cart>> GetAllAsync();
    public Task<Cart> GetAsync(int id);
    public Task<Exception> AddAsync(Cart cart);
    public Task<Exception> DeleteAsync(int id);

    public Task<Exception> UpdateAsync(int id, Cart cart);
}
