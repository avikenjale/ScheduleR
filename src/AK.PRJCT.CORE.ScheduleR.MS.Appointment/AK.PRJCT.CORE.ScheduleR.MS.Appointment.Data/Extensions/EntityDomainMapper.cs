using System.Collections.Generic;
using System.Linq;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Extensions
{
    public static class EntityDomainMapper
    {
        public static IEnumerable<Domain.Models.AppointmentModel> ToAppointmentModels(this IEnumerable<Entities.Models.Appointment> appointments)
        {
            return appointments.Select(a => a.ToAppointmentModel());
        }

        public static Domain.Models.AppointmentModel ToAppointmentModel(this Entities.Models.Appointment appointment)
        {
            return new Domain.Models.AppointmentModel
            {
                AppointmentId = appointment.AppointmentId,
                StudentId = appointment.StudentId,
                ClassId = appointment.ClassId,
                TeacherId = appointment.TeacherId,
                AppointmentTime = appointment.AppointmentTime
            };
        }

        public static IEnumerable<Entities.Models.Appointment> ToAppointmentEntities(this IEnumerable<Domain.Models.AppointmentModel> appointments)
        {
            return appointments.Select(a => a.ToAppointmentEntity());
        }

        public static Entities.Models.Appointment ToAppointmentEntity(this Domain.Models.AppointmentModel appointment)
        {
            return new Entities.Models.Appointment{
                 AppointmentId = appointment.AppointmentId,
                StudentId = appointment.StudentId,
                ClassId = appointment.ClassId,
                TeacherId = appointment.TeacherId,
                AppointmentTime = appointment.AppointmentTime
            };        
        }
    }
}