using DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Proiect.Services.CategoryService;
using System.Xml.Linq;

namespace Proiect.Controllers
{

        public class CategoryController :ControllerBase
        {
            private readonly ICategoryService _categoryService;

            public CategoryController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            [HttpGet]
            [Route("categories/names")]
            [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllCategories()
            {
                var categories = await _categoryService.GetAllCategories();
                var categoryNames = categories.Select(c => c.Name).ToList();
                return Ok(categoryNames);
            }
        //public async Task<IActionResult> GetAllCategories()
        //    {
        //   var categories = await _categoryService.GetAllCategories();
        //    return Ok(categories);
        //    }

        [HttpGet]
        [Route("posts/category/{categoryId}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            var posts = await _categoryService.GetPostsByCategoryId(categoryId);
            return Ok(posts);
        }


        [HttpGet("{id}")]
            public async Task<IActionResult> GetCategoryById(Guid id)
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                    return NotFound();

                return Ok(category);
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategory([FromBody] Category category)
            {
            if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newCategory = await _categoryService.CreateCategory(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
            }


            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategory(Guid id)
            {
                var deleted = await _categoryService.DeleteCategory(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
        }


}

