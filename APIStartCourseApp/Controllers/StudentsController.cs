using APIStartCourseApp.DAL;
using APIStartCourseApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIStartCourseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public StudentsController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<List<Student>> GetAll()
        {
            var data = _context.Students.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var data = _context.Students.Find(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, Student student)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.SurName = student.SurName;
            existingStudent.GroupId = student.GroupId;

            _context.SaveChanges();

            return Ok(existingStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
