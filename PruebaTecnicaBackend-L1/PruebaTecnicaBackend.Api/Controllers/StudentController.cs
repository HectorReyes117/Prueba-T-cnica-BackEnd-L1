using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend.Core.DTO;
using PruebaTecnicaBackend.Core.Entities;
using PruebaTecnicaBackend.Core.Interfaces;

namespace PruebaTecnicaBackend.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private readonly IStudentRepository studentRepository;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository studentRepository, IMapper _mapper)
        {
            this.studentRepository = studentRepository;
            this._mapper = _mapper; 
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                var response = await studentRepository.GetStudent();
                var Student1 = _mapper.Map<IEnumerable<StudentDTO>>(response);
                return StatusCode(StatusCodes.Status200OK, Student1);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Data could not be retrieved" });
            }
        }

        [HttpGet("{Student}")]
        public async Task<IActionResult> GetStudentId(string Student)
        {
            try
            {
                var response = await studentRepository.GetStudentId(Student);
                if (response != null)
                {
                    var Student1 =  _mapper.Map<IEnumerable<StudentDTO>>(response);
                    return StatusCode(StatusCodes.Status200OK,  Student1);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "The Student you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Error finding the Student" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(StudentDTO entity)
        {
            try
            {
                var Professor1 = _mapper.Map<Student>(entity);


                var response = await studentRepository.InsertStudent(Professor1);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Student created successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The student could not be added, check that you can add more students to this course" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creating Student" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var response = await studentRepository.DeleteStudent(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Student deleted successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "The Student not could not be deleted" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error deleting Student" });
            }
        }
    }
}
