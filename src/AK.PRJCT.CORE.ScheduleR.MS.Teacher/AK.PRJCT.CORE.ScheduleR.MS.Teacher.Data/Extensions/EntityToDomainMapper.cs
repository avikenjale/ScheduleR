using System.Collections.Generic;
using System.Linq;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Extensions
{
    public static class EntityToDomainMapper
    {
        public static IEnumerable<Domain.Models.TeacherModel> ToTeacherModels(this IEnumerable<Entities.Models.Teacher> teachers)
        {
            return teachers.Select(t => ToTeacherModel(t));
        }

        public static Domain.Models.TeacherModel ToTeacherModel(this Entities.Models.Teacher teacher)
        {
            return new Domain.Models.TeacherModel {
                TeacherId = teacher.TeacherId,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                PhoneNumber = teacher.PhoneNumber,
                Email = teacher.Email,
                Address = teacher.Address,
                City = teacher.City,
                State = teacher.State,
                Zip = teacher.Zip
            };
        }
    }
}