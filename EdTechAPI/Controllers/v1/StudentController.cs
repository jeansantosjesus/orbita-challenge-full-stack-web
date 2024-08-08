using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model;

namespace WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepository.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _studentRepository.Get(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student object is null");
                }

                _studentRepository.Add(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.ra }, student);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework)
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }       

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (student == null || student.ra != id)
                {
                    return BadRequest("Student data is invalid");
                }

                var existingStudent = _studentRepository.Get(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                _studentRepository.Update(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _studentRepository.Get(id);
                if (student == null)
                {
                    return NotFound();
                }

                _studentRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }
    }

}
