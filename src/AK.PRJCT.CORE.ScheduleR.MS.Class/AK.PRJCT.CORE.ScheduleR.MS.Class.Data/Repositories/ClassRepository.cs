using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Domain.Models;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        public async Task<IEnumerable<ClassModel>> GetClassesAsync()
        {
            using (var context = new ClassContext())
            {
                return (await context.Classes.ToListAsync()).ToClassModels();
            }
        }

        public async Task<IEnumerable<ClassModel>> GetClassesByNameAsync(string name)
        {
            using (var context = new ClassContext())
            {
                return (await context.Classes.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync()).ToClassModels();
            }
        }

        public async Task<int> SaveClassAsync(ClassModel class1)
        {
            using (var context = new ClassContext())
            {
                var classEntity = class1.ToClassEntity();

                if(classEntity.ClassId != 0)
                {
                    context.Classes.Attach(classEntity);
                    context.Entry(classEntity).State = EntityState.Modified;
                }
                else
                {
                    context.Classes.Add(classEntity);                
                }
                var result = await context.SaveChangesAsync().ConfigureAwait(false);
                return result;
            }
        }
    }
}