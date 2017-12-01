using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Repositories
{
    public interface IStudentRepository
    {
         Task<IEnumerable<Entities.Models.Student>> GetStudentsAsync();
    }
}