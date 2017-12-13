using System.Collections.Generic;
using System.Linq;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Extensions
{
    public static class EntityToDomainMapper
    {
        public static IEnumerable<Domain.Models.ClassModel> ToClassModels(this IEnumerable<Entities.Models.Class> classes)
        {
            return classes.Select(ToClassModel);
        }

        public static Domain.Models.ClassModel ToClassModel(this Entities.Models.Class class1)
        {
            return new Domain.Models.ClassModel{
                ClassId = class1.ClassId,
                Name = class1.Name
            };
        }

        public static Entities.Models.Class ToClassEntity(this Domain.Models.ClassModel class1)
        {
            return new Entities.Models.Class{
                ClassId = class1.ClassId,
                Name = class1.Name
            };
        }
    }
}