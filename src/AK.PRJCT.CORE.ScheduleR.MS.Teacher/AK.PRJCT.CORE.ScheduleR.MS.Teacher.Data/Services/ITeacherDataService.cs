using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Services
{
    public interface ITeacherDataService
    {
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync();
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name);
    }
}