using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services
{
    public interface IStudentDataService
    {
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync();
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name);
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name);
    }
}