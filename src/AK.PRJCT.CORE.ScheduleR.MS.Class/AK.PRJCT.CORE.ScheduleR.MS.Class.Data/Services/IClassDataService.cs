using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Services
{
    public interface IClassDataService
    {
        Task<IEnumerable<ClassModel>> GetClassesAsync();
        Task<IEnumerable<ClassModel>> GetClassesByNameAsync(string name);
    }
}