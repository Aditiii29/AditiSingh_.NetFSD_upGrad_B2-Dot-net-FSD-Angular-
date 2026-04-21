using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CategoryService.DTOs;
using CategoryService.Services;

namespace CategoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories  (Admin + User)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET: api/categories/5  (Admin + User)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { Message = $"Category with ID {id} not found." });
            return Ok(category);
        }

        // POST: api/categories  (Admin only)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _categoryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.CategoryId }, created);
        }

        // PUT: api/categories/5  (Admin only)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _categoryService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(new { Message = $"Category with ID {id} not found." });
            return Ok(updated);
        }

        // DELETE: api/categories/5  (Admin only)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { Message = $"Category with ID {id} not found." });
            return Ok(new { Message = "Category deleted successfully." });
        }
    }
}