using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;

namespace EShop.Application.Services;

public interface ICategoryService
{

    public Task<List<Category>> GetAllAsync();
    public Task<Category> GetAsync(int id);

    public Task<Exception> AddAsync(Category category);

}
