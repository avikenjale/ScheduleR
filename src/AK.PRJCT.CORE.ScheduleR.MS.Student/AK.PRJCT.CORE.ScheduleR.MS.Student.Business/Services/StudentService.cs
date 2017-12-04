using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Business.Services
{
    public class StudentService: IStudentService
    {
        protected readonly IStudentDataService StudentDataService;

        public StudentService(IStudentDataService studentDataService)
        {
            StudentDataService = studentDataService;
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync()
        {
            return StudentDataService.GetStudentsAsync();
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name)
        {
            return StudentDataService.GetStudentsByNameAsync(name);
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name)
        {
            return StudentDataService.GetStudentsByParentNameAsync(name);
        }
    }    
}