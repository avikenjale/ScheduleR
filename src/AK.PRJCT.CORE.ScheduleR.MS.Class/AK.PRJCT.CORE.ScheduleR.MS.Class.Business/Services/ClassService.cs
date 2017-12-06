using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Business.Services
{
    public class ClassService: IClassService
    {
        protected readonly IClassDataService ClassDataService;

        public ClassService(IClassDataService classDataService)
        {
            ClassDataService = classDataService;
        }

        public Task<IEnumerable<ClassModel>> GetClassesAsync()
        {
            return ClassDataService.GetClassesAsync();
        }

        public Task<IEnumerable<ClassModel>> GetClassesByNameAsync(string name)
        {
            return ClassDataService.GetClassesByNameAsync(name);
        }        
    }
}