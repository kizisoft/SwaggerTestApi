using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IHelperService helperService;

        public CustomersController(IHelperService helperService)
        {
            this.helperService = helperService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Customers", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The Customer data is invalid")]
        public async Task<IActionResult> Get()
        {
            using var reader = this.helperService.GetFileAsStreamReader("customers.json");
            if (reader == null)
            {
                return BadRequest();
            }

            var jsonStr = await reader.ReadToEndAsync();
            var res = JsonConvert.DeserializeObject<Customer[]>(jsonStr);

            return Ok(res);
        }
    }
}