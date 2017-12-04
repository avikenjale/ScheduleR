using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Business.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync();
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name);
        Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name);
    }
}