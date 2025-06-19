using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application.Services;

public class CartService : ICartService
{
    //Setup (dependency injections)
    private IRepository _repository;
    public CartService(IRepository repository)
    {
        _repository = repository;
    }

    //Actual stuff
    public async Task<List<Cart>> GetAllAsync()
    {
        List<Cart> carts = await _repository.GetAllCartsAsync();

        return carts;
    }
    public async Task<Cart> GetAsync(int id)
    {
        Cart cart = await _repository.GetCartAsync(id);

        return cart;
    }
    public async Task<Exception> AddAsync(Cart cart)
    {
        Exception result = await _repository.AddCartAsync(cart);

        return result;
    }


}
