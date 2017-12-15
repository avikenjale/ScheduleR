using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.API.Controllers
{
    public class AppointmentsController : Controller
    {
        [HttpGet, Route("")]
        public IActionResult Warmpup()
        {
            return Ok("Appointment API is running.");
        }      
    }
}