using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application.Services;

public class CategoryService : ICategoryService
{

    private IRepository _repository;
    public CategoryService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> GetAsync(int id)
    {
        Category category = await _repository.GetCategoryAsync(id);

        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        List<Category> categories = await _repository.GetAllCategoriesAsync();

        return categories;
    }

    public async Task<Exception> AddAsync(Category category)
    {
        Exception result = await _repository.AddCategoryAsync(category);

        return result;
    }

    public async Task<Exception> DeleteAsync(int id)
    {
        Exception result = await _repository.DeleteCategoryAsync(id);

        return result;
    }

}


