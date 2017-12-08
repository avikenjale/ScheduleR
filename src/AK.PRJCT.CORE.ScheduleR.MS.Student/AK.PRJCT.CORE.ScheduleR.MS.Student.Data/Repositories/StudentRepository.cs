using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsAsync()
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students.AsNoTracking()
                                .Include(s => s.Parent);

                return (await query.ToListAsync()).ToStudentModels();
            }
        }

        public async Task<Domain.Models.StudentModel> GetStudentAsync(int studentId)
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students.AsNoTracking()
                                .Where(s => s.StudentId == studentId)
                                .Include(s => s.Parent);

                return (await query.FirstOrDefaultAsync()).ToStudentModel();
            }
        }

        public async Task<IEnumerable<Domain.Models.StudentModel>> GetStudentsByNameAsync(string name)
        {
            using (var context = new StudentContext())
            {
                var query = context
                                .Students
                                    .AsNoTracking()
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
                                .Students.AsNoTracking()
                                    .Where(s => s.Parent.FirstName.ToLower().Contains(name.ToLower()) || s.Parent.LastName.ToLower().Contains(name.ToLower()))
                                .Include(s => s.Parent);

                return (await query.ToListAsync()).ToStudentModels();
            }
        }

        public async Task<int> SaveStudentAsync(Domain.Models.StudentModel student)
        {
            using (var context = new StudentContext())
            {
                var studentEntity = student.ToStudentEntity();

                if (student.StudentId != 0)
                {
                    context.Students.Attach(studentEntity);      
                    context.Entry(studentEntity).State = EntityState.Modified;

                    context.Parents.Attach(studentEntity.Parent);
                    context.Entry(studentEntity.Parent).State = EntityState.Modified;
                }
                else
                {
                    context.Set<Entities.Models.Student>().Add(studentEntity);

                    if(student.ParentId != 0)
                    {
                        context.Parents.Attach(studentEntity.Parent);
                        context.Entry(studentEntity.Parent).State = EntityState.Modified;
                    }
                }

                var results = await context.SaveChangesAsync().ConfigureAwait(false);
                return results;
            }
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            using (var context = new StudentContext())
            {
                var results = 0;
                var student = await this.GetStudentAsync(studentId).ConfigureAwait(false);

                try
                {
                    context.Remove<Entities.Models.Student>(student.ToStudentEntity());
                    results = await context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                return results;
            }
        }
    }
}