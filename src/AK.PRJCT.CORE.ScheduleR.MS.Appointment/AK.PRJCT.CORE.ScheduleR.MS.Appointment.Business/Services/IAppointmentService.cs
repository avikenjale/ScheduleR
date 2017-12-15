using System.Collections.Generic;
using System.Threading.Tasks;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Business.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsAsync();
        Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByDateAsync(string date);
        Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByTeacherAsync(int teacherId);
        Task<int> SaveAppointmentAsync(Domain.Models.AppointmentModel appointment);
        Task<int> DeleteAppointmentAsync(int appointmentId);
    }
}