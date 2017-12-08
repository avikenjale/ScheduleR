using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Business.Services
{
    public class StudentService : IStudentService
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

        public Task<Domain.Models.StudentModel> GetStudentAsync(int studentId)
        {
            return StudentDataService.GetStudentAsync(studentId);
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name)
        {
            return StudentDataService.GetStudentsByNameAsync(name);
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name)
        {
            return StudentDataService.GetStudentsByParentNameAsync(name);
        }

        public Task<int> SaveStudentAsync(Domain.Models.StudentModel student)
        {
            return StudentDataService.SaveStudentAsync(student);
        }

        public Task<int> DeleteStudentAsync(int studentId)
        {
            return StudentDataService.DeleteStudentAsync(studentId);
        }
    }
}