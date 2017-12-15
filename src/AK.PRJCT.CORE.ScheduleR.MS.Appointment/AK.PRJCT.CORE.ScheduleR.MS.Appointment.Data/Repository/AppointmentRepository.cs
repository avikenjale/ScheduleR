using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Context;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Extensions;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public async Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsAsync()
        {
            using (var context = new AppointmentContext())
            {
                return (await context.Appointments.ToListAsync().ConfigureAwait(false)).ToAppointmentModels();
            }
        }

        public async Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByDateAsync(string date)
        {
            using (var context = new AppointmentContext())
            {
                var appointmentQuery = context.Appointments
                                                    .Where(a => a.AppointmentTime.Contains(date));

                return (await appointmentQuery.ToListAsync().ConfigureAwait(false)).ToAppointmentModels();
            }
        }

        public async Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByTeacherAsync(int teacherId)
        {
            using (var context = new AppointmentContext())
            {
                var appointmentQuery = context.Appointments
                                                    .Where(a => a.TeacherId == teacherId);

                return (await appointmentQuery.ToListAsync().ConfigureAwait(false)).ToAppointmentModels();
            }
        }

        public Task<int> SaveAppointmentAsync(Domain.Models.AppointmentModel appointment)
        {
            using (var context = new AppointmentContext())
            {
                if (appointment.AppointmentId == 0)
                {
                    context.AddAsync(appointment.ToAppointmentEntity());
                }
                else
                {
                    var appointmentEntity = appointment.ToAppointmentEntity();
                    context.Attach(appointmentEntity);
                    context.Entry(appointmentEntity).State = EntityState.Modified;
                }

                return context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteAppointmentAsync(int appointmentId)
        {
            var result = 0;

            using (var context = new AppointmentContext())
            {
                if (appointmentId != 0)
                {
                    var appointment = await context.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefaultAsync().ConfigureAwait(false);

                    if(appointment != null)
                    {
                        context.Remove(appointment);
                        context.Entry(appointment).State = EntityState.Deleted;

                        result = await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
            }

            return result;
        }
    }
}