using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.API.Controllers
{
    public class StudentsController : Controller
    {
        protected readonly IStudentService StudentService;

        public StudentsController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Warmpup(){
            return Ok("Students service is running.");
        }

        [HttpGet,  Route("api/[controller]")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var students = await StudentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet,  Route("api/[controller]/{name}")]
        public async Task<IActionResult> GetStudentsByNameAsync(string name)
        {
            var students = await StudentService.GetStudentsByNameAsync(name);
            return Ok(students);
        }

        [HttpGet,  Route("api/[controller]/parent/{name}")]
        public async Task<IActionResult> GetStudentsByParentNameAsync(string name)
        {
            var students = await StudentService.GetStudentsByParentNameAsync(name);
            return Ok(students);
        }
    }
}

