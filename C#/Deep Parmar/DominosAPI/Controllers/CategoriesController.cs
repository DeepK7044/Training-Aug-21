using DominosAPI.Authentication;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository Category;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            Category = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = Category.GetCategories();
            if (categories==null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{CategoryId}")]
        public IActionResult GetCategory(int CategoryId)
        {
            var category = Category.GetCategory(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (category==null)
            {
                throw new ArgumentNullException(nameof(category));
            }           
            Category.Add(category);
            return Ok(new Response { Status = "Success", Message = "category Created Successfully" });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{CatId}")]
        public IActionResult DeleteCategory(int CatId)
        {
            var category = Category.GetById(CatId);
            if (category == null)
            {
                return NotFound($"Category Which id is : {CatId} Is Not Available");
            }           
            var Result = Category.Delete(category);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing category Failed." });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{CatId}")]
        public IActionResult UpdateCategory(int CatId, Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            var categoryExists = Category.GetById(CatId);
            if (categoryExists == null)
            {
                return NotFound($"Category Which id is : {CatId} Is Not Available");
            }
            var result = Category.UpdateCategory(CatId, category);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
