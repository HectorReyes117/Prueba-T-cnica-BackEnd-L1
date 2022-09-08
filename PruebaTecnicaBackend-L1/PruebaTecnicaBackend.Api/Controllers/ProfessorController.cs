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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        public ProfessorController(IProfessorRepository _professorRepository, IMapper _mapper)
        {
            this._professorRepository = _professorRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessor()
        {
            try
            {
                var Professor1 = await _professorRepository.GetProfessor();
                var ProfessorDTO = _mapper.Map<IEnumerable<ProfessorGetDTO>>(Professor1); 
                return StatusCode(StatusCodes.Status200OK, ProfessorDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Data could not be retrieved" });
            }
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetProfessorId(string Name)
        {
            try
            {
                var response = await _professorRepository.GetProfessorId(Name);
                if (response != null)
                {
                    var ProfessorDTO = _mapper.Map<IEnumerable<ProfessorDTO>>(response);
                    return StatusCode(StatusCodes.Status200OK,  ProfessorDTO);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "the Professor you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "error finding the Professor" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertProfessor(ProfessorDTO entity)
        {
            try
            {
                var Professor1 = _mapper.Map<Professor>(entity);

                
                var response = await _professorRepository.InsertProfessor(Professor1);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Professor created successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The teacher could not be created, check that the teacher does not belong to the inserted course or does not have the same shift." });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creating Professor" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            try
            {      
                var response = await _professorRepository.DeleteProfessor(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Professor deleted successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The Professor could not be deleted" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error deleting Professor" });
            }
        }
    }
}
