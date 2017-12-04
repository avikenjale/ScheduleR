using System.Collections.Generic;
using System.Linq;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Domain;


namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Extensions
{
    public static class EntityToDomainMapper
    {
        public static IEnumerable<Domain.Models.StudentModel> ToStudentModels(this IEnumerable<Entities.Models.Student> students)
        {
                return students.Select(s => ToStudentModel(s));
        }

        public static Domain.Models.StudentModel ToStudentModel(this Entities.Models.Student student)
        {
            return new Domain.Models.StudentModel {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                ParentFirstName = student.Parent.FirstName,
                ParentLastName = student.Parent.LastName,
                PhoneNumber = student.Parent.PhoneNumber,
                Email = student.Parent.Email,
                Address = student.Parent.Address,
                City = student.Parent.City,
                State = student.Parent.State,
                Zip = student.Parent.Zip
            };
        }
    }
}