using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwaggerTestApi.Web.Models;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IHelperService helperService;

        public EmployeesController(IHelperService helperService)
        {
            this.helperService = helperService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all Employees", typeof(Employee[]))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The Employee data is invalid")]
        public async Task<IActionResult> Get()
        {
            using var reader = this.helperService.GetFileAsStreamReader("employees.json");
            if (reader == null)
            {
                return BadRequest();
            }

            var jsonStr = await reader.ReadToEndAsync();
            var res = JsonConvert.DeserializeObject<Employee[]>(jsonStr);

            return Ok(res);
        }

        [HttpGet("hierarchical")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all HierarchicalEmployees", typeof(HierarchicalEmployee[]))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The HierarchicalEmployee data is invalid")]
        public async Task<IActionResult> GetHierarchicalEmployee()
        {
            using var reader = this.helperService.GetFileAsStreamReader("hierarchicalEmployees.json");
            if (reader == null)
            {
                return BadRequest();
            }

            var jsonStr = await reader.ReadToEndAsync();
            var res = JsonConvert.DeserializeObject<HierarchicalEmployee[]>(jsonStr);

            return Ok(res);
        }
    }
}