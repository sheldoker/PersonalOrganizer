using Microsoft.AspNetCore.Mvc;
using PersonalOrganizer.Domain.Entities;
using PersonalOrganizer.Domain.Repositories;

namespace PersonalOrganizer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetByID(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Категория с Id {id} не найдена");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryDto dto)
        {
            var category = new Category(dto.Name, dto.Description, dto.Color, dto.Icon);

            await _categoryRepository.AddAsync(category);

            return CreatedAtAction(nameof(GetByID), new {id = category.Id}, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Категория с Id {id} не найдена");
            }
            
            await _categoryRepository.DeleteAsync(category);
            return NoContent();
        }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Icon {  get; set; } = null!;
    }
}