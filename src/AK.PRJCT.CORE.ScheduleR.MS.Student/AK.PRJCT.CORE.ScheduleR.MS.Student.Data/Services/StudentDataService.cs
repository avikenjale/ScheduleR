using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Repositories;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Services
{
    public class StudentDataService : IStudentDataService
    {
        protected readonly IStudentRepository StudentRepository;
        public StudentDataService(IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }
        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync()
        {
            return StudentRepository.GetStudentsAsync();
        }

        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name)
        {
            return StudentRepository.GetStudentsByNameAsync(name);
        }
        public Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name)
        {
            return StudentRepository.GetStudentsByParentNameAsync(name);
        }
    }
}