using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Course { get; set; }
            public int Score { get; set; }
        }

        private static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Remember Mabunda", Course = "Computer Science", Score = 85 },
            new Student { Id = 2, Name = "Mthunzi Magasela", Course = "Mathematics", Score = 90 },
            new Student { Id = 3, Name = "Khodani Maphosa", Course = "Physics", Score = 80 }
        };


        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }


        // GET: api/Students/5
        //[HttpGet]
        //public Student GetById(int id)
        //{
        //    return students.FirstOrDefault(s => s.Id == id);
        //}

        // POST: api/Students
        [HttpPost]
        public void Post([System.Web.Http.FromBody] Student student)
        {
            students.Add(student);
        }

        // DELETE: api/Students/5
        [HttpDelete]
        public void Delete(int id)
        {
            students.RemoveAll(s => s.Id == id);
        }
    }
}
