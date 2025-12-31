using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        StudentService service;

        public StudentController(StudentService service)
        {
            this.service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var students = service.GetAll();
            return Ok(students);
        }

        [HttpGet("all{id}")]
        public IActionResult GetStudent(int id)
        {
            var students = service.GetAll(id);
            return Ok(students);
        }

        [HttpPost("Create")]
        public IActionResult AddStudent(StudentDTO student)
        {
            var students = service.Add(student);
            return Ok(students);

        }
    }
}
