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

        [HttpGet, Route("api/[controller]/{id:int}")]
        public async Task<IActionResult> GetStudentAsync(int id)
        {
            try
            {
                var student = await StudentService.GetStudentAsync(id);

                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    Logger.LogInformation("No students found for given id.");
                    return NotFound("No students found for given id.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
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
            catch (Exception exception)
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
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        [HttpPost, Route("api/[controller]")]
        public async Task<IActionResult> PostStudentAsync([FromBody]Domain.Models.StudentModel student)
        {
            try
            {
                var results = await StudentService.SaveStudentAsync(student).ConfigureAwait(false);

                if(results <=0)
                {
                    Logger.LogWarning("Unable to save student properly.");      
                    return BadRequest();              
                }

                return Ok($"Student saved successfully. {results}");
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete, Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var result = await StudentService.DeleteStudentAsync(id);

                if (result != 0)
                {
                    return Ok("Student deleted successfully for given id.");
                }
                else
                {
                    Logger.LogInformation("No students found for given id.");
                    return NotFound("No students found for given id.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }
    }
}

