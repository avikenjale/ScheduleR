using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Repositories;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Services
{
    public class ClassDataService : IClassDataService
    {
        protected readonly IClassRepository ClassRepository;

        public ClassDataService(IClassRepository classRepository)
        {
            ClassRepository = classRepository;
        }

        public Task<IEnumerable<ClassModel>> GetClassesAsync()
        {
            return ClassRepository.GetClassesAsync();
        }

        public Task<IEnumerable<ClassModel>> GetClassesByNameAsync(string name)
        {
            return ClassRepository.GetClassesByNameAsync(name);
        }        

        public Task<int> SaveClassAsync(ClassModel class1)
        {
            return ClassRepository.SaveClassAsync(class1);
        }
    }
}