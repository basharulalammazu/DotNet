using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var d1 = new DTOs.DepartmentDTO
            {
                Id = 1,
                Name = "CSE",
            };
            var d2 = new DTOs.DepartmentDTO
            {
                Id = 2,
                Name = "EEE",
            };
            var departments = new List<DTOs.DepartmentDTO> { d1, d2 };
            return Ok(departments);
        }

        [HttpGet("Id/{id}")]
        public IActionResult Get(int id)
        {
            var department = new DTOs.DepartmentDTO
            {
                Id = id,
                Name = "CSE",
            };
            return Ok(department);
        }

        [HttpGet("id/{id}/name/{name}")]
        public IActionResult GetByIdAndName(int id, string name)
        {
            var department = new DTOs.DepartmentDTO
            {
                Id = id,
                Name = name,
            };
            return Ok(department);
        }


        [HttpPost("Create")]
        public IActionResult Create(DTOs.DepartmentDTO department)
        {
            return Ok(department);
        }
    }
}
