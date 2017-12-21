using System;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Business.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.API.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    public class AppointmentsController : Controller
    {
        protected readonly ILogger Logger;
        protected readonly ILoggerFactory LoggerFactory;
        protected readonly IAppointmentService AppointmentService;

        public AppointmentsController(IAppointmentService appointmentService, ILoggerFactory loggerFactory)
        {
            AppointmentService = appointmentService;

            LoggerFactory = loggerFactory;
            Logger = LoggerFactory.CreateLogger("LoggerCategory");
        }

        [HttpGet, Route("")]
        public IActionResult Warmpup()
        {
            return Ok("Appointment API is running.");
        }

        [HttpGet, Route("api/[controller]")]
        public async Task<IActionResult> GetAppointmentsAsync()
        {
            try
            {
                var appointments = await AppointmentService.GetAppointmentsAsync().ConfigureAwait(false);

                if (appointments.Any())
                {
                    return Ok(appointments);
                }
                else
                {
                    Logger.LogWarning("No Appointments available.");
                    return NotFound("No Appointments available.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError("Something went wrong while getting appointments.");
                Logger.LogError(exception.Message);

                return StatusCode(500, "Something went wrong while getting appointments.");
            }
        }

        [HttpGet, Route("api/[controller]/date/{date}")]
        public async Task<IActionResult> GetAppointmentsByDateAsync(string date)
        {
            try
            {
                var appointments = await AppointmentService.GetAppointmentsByDateAsync(date).ConfigureAwait(false);

                if (appointments.Any())
                {
                    return Ok(appointments);
                }
                else
                {
                    Logger.LogWarning("No Appointments available.");
                    return NotFound("No Appointments available.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError("Something went wrong while getting appointments.");
                Logger.LogError(exception.Message);

                return StatusCode(500, "Something went wrong while getting appointments.");
            }
        }

        [HttpGet, Route("api/[controller]/Teacher/{teacherId:int}")]
        public async Task<IActionResult> GetAppointmentsByTeacherAsync(int teacherId)
        {
            try
            {
                var appointments = await AppointmentService.GetAppointmentsByTeacherAsync(teacherId).ConfigureAwait(false);

                if (appointments.Any())
                {
                    return Ok(appointments);
                }
                else
                {
                    Logger.LogWarning("No Appointments available.");
                    return NotFound("No Appointments available.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError("Something went wrong while getting appointments.");
                Logger.LogError(exception.Message);

                return StatusCode(500, "Something went wrong while getting appointments.");
            }
        }

        [HttpPost, Route("api/[controller]")]
        public async Task<IActionResult> SaveAppointmentAsync([FromBody] AppointmentModel appointment)
        {
            try
            {
                var result = await AppointmentService.SaveAppointmentAsync(appointment).ConfigureAwait(false);

                if (result > 0)
                {
                    return Ok("Appointment saved successfully.");
                }
                else
                {
                    Logger.LogWarning("Unable to save appointment at this time.");
                    return BadRequest("Unable to save appointment at this time.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError("Something went wrong while getting appointments.");
                Logger.LogError(exception.Message);

                return StatusCode(500, "Something went wrong while getting appointments.");
            }
        }

        [HttpDelete, Route("api/[controller]/appointment/{appointmentId:int}")]
        public async Task<IActionResult> DeleteAppointmentAsync(int appointmentId)
        {
            try
            {
                var result = await AppointmentService.DeleteAppointmentAsync(appointmentId).ConfigureAwait(false);

                if (result > 0)
                {
                    return Ok("Appointment deleted successfully.");
                }
                else
                {
                    Logger.LogWarning("Unable to delete appointment at this time.");
                    return BadRequest("Unable to delete appointment at this time.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError("Something went wrong while getting appointments.");
                Logger.LogError(exception.Message);

                return StatusCode(500, "Something went wrong while getting appointments.");
            }
        }
    }
}