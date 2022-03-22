using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Models.Response;
using StudentsApi.Repository;

namespace StudentsApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<StudentResponse> GetStudents([FromQuery] int? page, string? firstName)
        {
            if (!page.HasValue || page == 0)
                page = 1;

            return _studentRepository.GetStudents(page.Value, firstName);
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody] Student student)
        {
            _studentRepository.CreateStudent(student);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentById([FromRoute] int id)
        {
            var student = _studentRepository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent([FromRoute] int id, [FromBody] Student student)
        {
            var result = _studentRepository.UpdateStudent(id, student);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent([FromRoute] int id)
        {
            var result = _studentRepository.DeleteStudent(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
