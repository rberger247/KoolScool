using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Students;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IUnitofWork unitofWork;

        public StudentController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

       [HttpGet]
       public async Task<ActionResult<List<Student>>> GetStudents()
        {
         var students =   await unitofWork.StudentRepository.GetAllAsync();

            return Ok(students);

        }
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult<Student> Upsert(Student student)
        {
            if (student != null)
            {
                if (student.StudentId == 0)
                {
                    unitofWork.StudentRepository.Add(student);
                }
                else
                {
                    unitofWork.StudentRepository.Update(student);
                }

            }
            unitofWork.Save();
            return Ok(student);

        }
    };
}