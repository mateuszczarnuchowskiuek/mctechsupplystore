using EShop.Application.Services;
using EShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Setup (dependency injection)
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            Exception e = await _categoryService.AddAsync(category);
            if (e == null)
                return Ok();

            return BadRequest(e);
        }
        /*
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
