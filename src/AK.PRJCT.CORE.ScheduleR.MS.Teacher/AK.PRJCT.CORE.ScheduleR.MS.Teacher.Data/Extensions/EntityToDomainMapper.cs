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
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                TeacherPhoneNumber = teacher.PhoneNumber,
                TeacherEmail = teacher.Email,
                TeacherAddress = teacher.Address,
                TeacherCity = teacher.City,
                TeacherState = teacher.State,
                TeacherZip = teacher.Zip
            };
        }
    }
}