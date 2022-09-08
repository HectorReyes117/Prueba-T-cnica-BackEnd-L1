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
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;
        public ClassroomController(IClassroomRepository _classroomRepository, IMapper _mapper)
        {
            this._classroomRepository = _classroomRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassroom()
        {
            try
            {
                var response = await _classroomRepository.GetClassroom();
                var Classroom1 = _mapper.Map<IEnumerable<ClassroomDTO>>(response);
                return StatusCode(StatusCodes.Status200OK, Classroom1);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Data could not be retrieved" });
            }
        }

        [HttpGet("{CLassroom}")]
        public async Task<IActionResult> GetClassroomId(string CLassroom)
        {
            try
            {
                var response = await _classroomRepository.GetClassroomId(CLassroom);
                if (response != null)
                {
                    var Classroom1 = _mapper.Map<IEnumerable<ClassroomDTO>>(response);
                    return StatusCode(StatusCodes.Status200OK,  Classroom1);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "The Classroom you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Error finding the Classroom" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            try
            {
                var response = await _classroomRepository.DeleteClassroom(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Classroom deleted successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "The Classroom not could not be deleted, check that it is not in use" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error deleting course" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertClassroomt(ClassroomDTO entity)
        {
            try
            {
                var Professor1 = _mapper.Map<Classroom>(entity);

                var response = await _classroomRepository.InsertClassroom(Professor1);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Classroom created successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The Classroom could not be added" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creating Classroom" });
            }
        }

    }
}
