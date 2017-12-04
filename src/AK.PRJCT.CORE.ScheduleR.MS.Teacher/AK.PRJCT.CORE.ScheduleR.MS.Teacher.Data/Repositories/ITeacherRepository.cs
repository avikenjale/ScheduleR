using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Repositories
{
    public interface ITeacherRepository
    {
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync();
         Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name);
    }
}