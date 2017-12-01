using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        protected readonly IStudentDataService StudentDataService;

        public StudentsController(IStudentDataService studentDataService)
        {
            StudentDataService = studentDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await StudentDataService.GetStudentsAsync();
            return Ok(students);
        }
    }
}

