using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services
{
    public interface IStudentDataService
    {
         Task<IEnumerable<Entities.Models.Student>> GetStudentsAsync(); 
    }
}