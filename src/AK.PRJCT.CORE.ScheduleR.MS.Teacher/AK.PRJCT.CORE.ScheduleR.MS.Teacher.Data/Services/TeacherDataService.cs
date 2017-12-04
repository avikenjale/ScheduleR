using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Repositories;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Services
{
    public class TeacherDataService : ITeacherDataService
    {

        protected readonly ITeacherRepository TeacherRepository;

        public TeacherDataService(ITeacherRepository teacherRepository)
        {
            TeacherRepository = teacherRepository;
        }

        public Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync()
        {
            return TeacherRepository.GetTeachersAsync();
        }

        public Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name)
        {
            return TeacherRepository.GetTeachersByNameAsync(name);
        }
    }
}