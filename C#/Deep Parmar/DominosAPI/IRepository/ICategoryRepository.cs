using DominosAPI.DTOs;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.IRepository
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        List<CategoryDTO> GetCategories();

        CategoryDTO GetCategory(int categoryId);
        bool UpdateCategory(int catId, Category entity);
    }
}
