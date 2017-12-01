using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<IEnumerable<Entities.Models.Student>> GetStudentsAsync()
        {
            using (var context = new StudentContext())
            {
                return  await context.Students.ToListAsync();
            }
        }
    }
}