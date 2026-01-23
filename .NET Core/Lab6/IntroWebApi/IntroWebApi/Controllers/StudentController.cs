using IntroWebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GettAll()
        {
            var s1 = new StudentDTO
            {
                Id = 1,
                Name = "Basharul Alam",
                Email = "basha@gmail.com",
                Phone = "01711111111",
            };

            var s2 = new StudentDTO
            {
                Id = 2,
                Name = "Basharul Alam",
                Email = "basha@gmail.com",
                Phone = "01711111111",
            };

            var students = new List<StudentDTO> { s1, s2 };
            return Ok(students);
        }

        [HttpPost]
        public IActionResult DataPost(StudentDTO student)
        {
            return Ok(student);
        }
    }

    
}
