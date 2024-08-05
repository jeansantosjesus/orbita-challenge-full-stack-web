using EdTechAPI.Model;
using EdTechAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EdTechAPI.Controllers
{
    [ApiController]
    [Route("api/v1/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        [HttpPost]
        public IActionResult Add(StudentViewModel studentView)
        {
            var student = new Student(studentView.Cpf, studentView.Name, studentView.Email);
            
            _studentRepository.Add(student);
            
            return Ok();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var student = _studentRepository.GetAll();
            
            return Ok(student);
        }
    }
}
