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
    public class ScheduleWeekController : ControllerBase
    {
        private readonly IScheduleWeekRepository _scheduleWeekRepository;
        private readonly IMapper _mapper;

        public ScheduleWeekController(IScheduleWeekRepository _scheduleWeekRepository, IMapper _mapper)
        {
            this._scheduleWeekRepository = _scheduleWeekRepository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetScheduleWeek()
        {
            try
            {
                var response = await _scheduleWeekRepository.GetScheduleWeek();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Data could not be retrieved" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertScheduleWeek(ScheduleWeekDTO entity)
        {
            try
            {
                var student = _mapper.Map<ScheduleWeek>(entity);


                var response = await _scheduleWeekRepository.InsertScheduleWeek(student);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Schedule created successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The Schedule could not be added" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creating Schedule" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteScheduleWeek(int id)
        {
            try
            {
                var response = await _scheduleWeekRepository.DeleteScheduleWeek(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Schedule deleted successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "The Schedule not could not be deleted" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error deleting Schedule" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateScheduleWeek(ScheduleWeekDTO entity)
        {
            try
            {
                var student = _mapper.Map<ScheduleWeek>(entity);

                var response = await _scheduleWeekRepository.UpdateScheduleWeek(student);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Schedule updated successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "The Schedule could not be updated" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error updating Schedule" });
            }
        }

        [HttpGet("GetScheduleWeekDayMonthYear")]  
        public async Task<IActionResult> GetScheduleWeekDayMonthYear(int Day, string Month, int Year)
        {
            try
            {
                var response = await _scheduleWeekRepository.GetScheduleWeekDayMonthYear(Day,Month,Year);
                if (response != null && response.Count() > 0)
                {               
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "The ScheduleWeek you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Error finding the ScheduleWeek" });
            }
        }

        [HttpGet("GetScheduleWeekMonthYear")]
        public async Task<IActionResult> GetScheduleWeekMonthYear(string Month, int Year)
        {
            try
            {
                var response = await _scheduleWeekRepository.GetScheduleWeekMonthYear(Month, Year);
                if (response != null && response.Count() > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "The ScheduleWeek you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Error finding the ScheduleWeek" });
            }
        }

        [HttpGet("GetScheduleWeek_WeekMonthYear")]
        public async Task<IActionResult> GetScheduleWeek_WeekMonthYear(string Week, string Month, int Year)
        {
            try
            {
                var response = await _scheduleWeekRepository.GetScheduleWeek_WeekMonthYear(Week, Month, Year);
                if (response != null && response.Count() > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { response = "The ScheduleWeek you were looking for was not found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Error finding the ScheduleWeek" });
            }
        }
    }
}
