using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.API.Controllers
{
    public class StudentsController : Controller
    {
        protected readonly ILoggerFactory LoggerFactory;
        protected readonly ILogger Logger;
        protected readonly IStudentService StudentService;

        public StudentsController(IStudentService studentService, ILoggerFactory loggerFactory)
        {
            StudentService = studentService;

            LoggerFactory = loggerFactory;
            Logger = LoggerFactory.CreateLogger("LoggerCategory");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Warmpup()
        {
            return Ok("Students service is running.");
        }

        [HttpGet, Route("api/[controller]")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var students = await StudentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet, Route("api/[controller]/{name}")]
        public async Task<IActionResult> GetStudentsByNameAsync(string name)
        {
            try
            {
                var students = await StudentService.GetStudentsByNameAsync(name);

                if (students.Any())
                {
                    return Ok(students);
                }
                else
                {
                    Logger.LogInformation("No students found for given criteria.");
                    return NotFound("No students found for given criteria.");
                }
            }
            catch(Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("api/[controller]/parent/{name}")]
        public async Task<IActionResult> GetStudentsByParentNameAsync(string name)
        {
            try
            {
                var students = await StudentService.GetStudentsByParentNameAsync(name);

                if (students.Any())
                {
                    return Ok(students);
                }
                else
                {
                    Logger.LogInformation("No students found for given parent criteria.");
                    return NotFound("No students found for given parent criteria.");
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

