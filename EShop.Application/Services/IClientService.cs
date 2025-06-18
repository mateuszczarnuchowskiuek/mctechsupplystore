using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;

namespace EShop.Application.Services;

public interface IClientService
{
    public Task<Clients> GetAsync(int id);
}
