using AutoMapper;
using EBuy.API.DTO.Category;
using EBuy.API.Validators.Category;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategories();
            var categoriesDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return Ok(categoriesDTO);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();

            var category = await _categoryService.GetCategoryById(id);

            if (category == null) return NotFound();

            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);
            return Ok(categoryDTO);
        }

        // POST api/category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            var validator = new CreateCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(createCategoryDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var categoryToBeCreated = _mapper.Map<CreateCategoryDTO, Category>(createCategoryDTO);
            var categoryCreated = await _categoryService.CreateCategory(categoryToBeCreated);

            var newCategory = await _categoryService.GetCategoryById(categoryCreated.Id);
            var categoryDTO = _mapper.Map<Category, CategoryDTO>(newCategory);

            return Ok(categoryDTO);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (id == 0) return BadRequest();

            var validator = new UpdateCategoryDTOValidator();
            var validationResult = await validator.ValidateAsync(updateCategoryDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var categoryToBeUpdated = await _categoryService.GetCategoryById(id);

            if (categoryToBeUpdated == null)
            {
                return NotFound();
            }

            var newCategory = _mapper.Map<UpdateCategoryDTO, Category>(updateCategoryDTO);
            await _categoryService.UpdateCategory(categoryToBeUpdated, newCategory);

            var updatedCategory = await _categoryService.GetCategoryById(id);
            var categoryDTO = _mapper.Map<Category, CategoryDTO>(updatedCategory);

            return Ok(categoryDTO);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var categoryToBeDeleted = await _categoryService.GetCategoryById(id);

            if (categoryToBeDeleted == null) return NotFound();

            await _categoryService.DeleteCategory(categoryToBeDeleted);

            return Ok();
        }
    }
}
