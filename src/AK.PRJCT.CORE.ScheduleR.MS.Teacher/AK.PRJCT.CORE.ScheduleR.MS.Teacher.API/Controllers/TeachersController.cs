using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.API.Controllers
{
    public class TeachersController : Controller
    {
        protected readonly ILoggerFactory LoggerFactory;
        protected readonly ILogger Logger;
        protected readonly ITeacherService TeacherService;

        public TeachersController(ITeacherService teacherService, ILoggerFactory loggerFactory)
        {
            TeacherService = teacherService;
            LoggerFactory = loggerFactory;

            Logger = LoggerFactory.CreateLogger("LoggerCategory");
        }

        [HttpGet,Route("")]
        public IActionResult Warmup()
        {
            return Ok("Teachers service is running.");
        }    

        [HttpGet,Route("api/[controller]")]
        public async Task<IActionResult> GetTeachersAsync()
        {
            try
            {
                var teachers = await TeacherService.GetTeachersAsync().ConfigureAwait(false);
                return Ok(teachers);
            }
            catch(Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

         [HttpGet,Route("api/[controller]/{name}")]
        public async Task<IActionResult> GetTeachersByNameAsync(string name)
        {
            try
            {
                var teachers = await TeacherService.GetTeachersByNameAsync(name).ConfigureAwait(false);
                if(teachers.Any())
                {
                    return Ok(teachers);
                }
                else
                {
                    Logger.LogInformation("No teachers found for given criteria.");
                    return NotFound("No teachers found for given criteria.");
                }
            }
            catch(Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }
    }
}
