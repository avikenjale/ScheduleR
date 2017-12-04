using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Business.Services
{
    public interface ITeacherService
    {
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync();
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name);
    }
}