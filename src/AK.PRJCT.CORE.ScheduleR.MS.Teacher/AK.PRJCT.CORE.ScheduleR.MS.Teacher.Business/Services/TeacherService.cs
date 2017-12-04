using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Services;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Business.Services
{
    public class TeacherService:ITeacherService    
    {
        protected readonly ITeacherDataService TeacherDataService;

        public TeacherService(ITeacherDataService teacherDataService)
        {
            TeacherDataService = teacherDataService;
        }
        public Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync()
        {
            return TeacherDataService.GetTeachersAsync();
        }
        
        public Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name)
        {
            return TeacherDataService.GetTeachersByNameAsync(name);
        }
    }
}