using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync()
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students
                                .Include(s => s.Parent);


                return (await query.ToListAsync()).ToStudentModels();
            }
        }

        public async Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name)
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students
                                    .Where(s => s.FirstName.ToLower().Contains(name.ToLower()) || s.LastName.ToLower().Contains(name.ToLower()))
                                .Include(s => s.Parent);

                return (await query.ToListAsync()).ToStudentModels();
            }

        }
        public async Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByParentNameAsync(string name)
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students
                                    .Where(s => s.Parent.FirstName.ToLower().Contains(name.ToLower()) || s.Parent.LastName.ToLower().Contains(name.ToLower()))
                                .Include(s => s.Parent);

                return (await query.ToListAsync()).ToStudentModels();
            }
        }
    }
}