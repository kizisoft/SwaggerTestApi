using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IHelperService helperService;

        public CategoriesController(IHelperService helperService)
        {
            this.helperService = helperService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Categories", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The Category data is invalid")]
        public async Task<Category[]> Get()
        {
            using var reader = this.helperService.GetFileAsStreamReader("categories.json");
            if (reader == null)
            {
                return new List<Category>().ToArray();
            }

            var jsonStr = await reader.ReadToEndAsync();
            var res = JsonConvert.DeserializeObject<Category[]>(jsonStr);

            return res;
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a Category by Id", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The Category data is invalid")]
        public async Task<IActionResult> Get(int id)
        {
            using var reader = this.helperService.GetFileAsStreamReader("categories.json");
            if (reader == null)
            {
                return BadRequest();
            }

            var jsonStr = await reader.ReadToEndAsync();
            var categorys = JsonConvert.DeserializeObject<Category[]>(jsonStr) ?? Array.Empty<Category>();
            var res = categorys.Where(c => c.CategoryId == id).FirstOrDefault();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }
    }
}