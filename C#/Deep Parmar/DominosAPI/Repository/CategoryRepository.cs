using AutoMapper;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Repository
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private readonly DominosDatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DominosDatabaseContext context,IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }




        public List<CategoryDTO> GetCategories()
        {
            try
            {
                var Categories = _context.Categories.ToList();
                return _mapper.Map<List<CategoryDTO>>(Categories);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public CategoryDTO GetCategory(int categoryId)
        {
            try
            {
                var Category = _context.Categories.SingleOrDefault(pizza => pizza.CategoryId == categoryId);
                return _mapper.Map<CategoryDTO>(Category);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateCategory(int catId, Category entity)
        {
            try
            {
                var ExistingCategory = _context.Categories.FirstOrDefault(category => category.CategoryId == catId);
                ExistingCategory.CategoryName = entity.CategoryName;
                ExistingCategory.ModificationTime = DateTime.Now;
                ExistingCategory.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool Delete(Category entity)
        {
            try
            {
                entity.IsActive = false;
                entity.DeletionTime = DateTime.Now;
                Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
