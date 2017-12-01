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
        public Task<IEnumerable<Entities.Models.Student>> GetStudentsAsync()
        {
            return StudentRepository.GetStudentsAsync();
        }
    }
}