using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application.Services;

public class ClientService : IClientService
{
    
    private IRepository _repository;
    public ClientService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Clients> GetAsync(int id)
    {
        Clients client = await _repository.GetClientAsync(id);

        return client;
    }


}
