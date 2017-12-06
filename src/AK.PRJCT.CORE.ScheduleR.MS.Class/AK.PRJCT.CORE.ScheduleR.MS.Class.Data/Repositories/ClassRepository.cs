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
    }
}