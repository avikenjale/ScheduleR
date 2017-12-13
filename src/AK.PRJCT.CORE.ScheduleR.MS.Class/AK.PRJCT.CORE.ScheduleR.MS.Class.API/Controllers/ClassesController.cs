using System;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Business.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.API.Controllers
{
    public class ClassesController : Controller
    {

        protected readonly ILoggerFactory LoggerFactory;
        protected readonly ILogger Logger;
        protected readonly IClassService ClassService;

        public ClassesController(IClassService classService, ILoggerFactory loggerFactory)
        {
            ClassService = classService;
            LoggerFactory = loggerFactory;

            Logger = LoggerFactory.CreateLogger("LoggerCategory");
        }

        [HttpGet, Route("")]
        public IActionResult Warmup()
        {
            return Ok("Class service is running");
        }


        [HttpGet, Route("api/[controller]")]
        public async Task<IActionResult> GetClassesAsync()
        {
            try
            {
                var classes = await ClassService.GetClassesAsync().ConfigureAwait(false);

                if (classes.Any())
                {
                    return Ok(classes);
                }
                else
                {
                    return NotFound("Classes are not available.");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        [HttpGet, Route("api/[controller]/{name}" )]
        public async Task<IActionResult> GetClassesByNameAsync(string name)
        {
            try
            {
                var classes = await ClassService.GetClassesByNameAsync(name).ConfigureAwait(false);

                if (classes.Any())
                {
                    return Ok(classes);
                }
                else
                {
                    Logger.LogWarning($"Class not found for given criteria: {name}");
                    return NotFound($"Class not found for given criteria: {name}");
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        [HttpPost, Route("api/[controller]")]
        public async Task<IActionResult> SaveClassAsync([FromBody]ClassModel class1)
        {
            try
            {
                var result = await ClassService.SaveClassAsync(class1).ConfigureAwait(false);

                if (result != 0)
                {
                    return Ok("Class saved successfully.");
                }
                else
                {
                    return NotFound("Class is unable to save.");
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