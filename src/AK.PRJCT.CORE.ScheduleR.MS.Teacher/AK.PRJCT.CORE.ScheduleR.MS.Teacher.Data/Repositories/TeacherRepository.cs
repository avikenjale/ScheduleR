using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
       public async Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersAsync()
        {
            using (var context = new TeacherContext())
            {
                return (await context.Teachers.ToListAsync()).ToTeacherModels();
            }
        }

        public async Task<IEnumerable<Domain.Models.TeacherModel>> GetTeachersByNameAsync(string name)
        {
            using (var context = new TeacherContext())
            {
                var query = context
                                .Teachers
                                    .Where(t => t.FirstName.ToLower().Contains(name.ToLower()) || t.LastName.ToLower().Contains(name.ToLower()));

                return (await query.ToListAsync()).ToTeacherModels();
            }
        }
    }
}