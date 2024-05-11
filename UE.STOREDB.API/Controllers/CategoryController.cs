using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        //public CategoryController(ICategoryRepository categoryRepository)
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            //_categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var categories = await _categoryRepository.GetAll();
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("Products")]
        public async Task<IActionResult> Products()
        {
            var categoriesWithProducts = await _categoryService.GetWithProducts();
            return Ok(categoriesWithProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] bool includeProducts)
        {            
            if (includeProducts)
                return Ok(await _categoryService.GetByIdWithProducts(id));
            else
                return Ok(await _categoryService.GetById(id));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var category = await _categoryRepository.GetById(id);
        //    if (category == null)
        //        return NotFound();

        //    return Ok(category);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDTO category)
        {
            var result = await _categoryService.Create(category);
            if (!result) return BadRequest();
            return Ok(result);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] Category category)
        //{
        //    if (id != category.Id) return BadRequest();
        //    var result = await _categoryRepository.Update(category);
        //    if (!result) return BadRequest();
        //    return Ok(result);
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _categoryRepository.Delete(id);
        //    if (!result) return BadRequest();
        //    return Ok(result);
        //}

    }
}
