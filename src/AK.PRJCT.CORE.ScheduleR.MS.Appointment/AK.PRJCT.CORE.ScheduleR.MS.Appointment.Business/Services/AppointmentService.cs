using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Business.Services
{
    public class AppointmentService: IAppointmentService
    {       
        protected readonly IAppointmentDataService AppointmentDataService;

        public AppointmentService(IAppointmentDataService appointmentDataService)
        {
            AppointmentDataService = appointmentDataService;
        }

        public Task<IEnumerable<AppointmentModel>> GetAppointmentsAsync()
        {
            return AppointmentDataService.GetAppointmentsAsync();
        }

        public Task<IEnumerable<AppointmentModel>> GetAppointmentsByDateAsync(string date)
        {
            return AppointmentDataService.GetAppointmentsByDateAsync(date);
        }

        public Task<IEnumerable<AppointmentModel>> GetAppointmentsByTeacherAsync(int teacherId)
        {
            return AppointmentDataService.GetAppointmentsByTeacherAsync(teacherId);
        }

        public Task<int> SaveAppointmentAsync(AppointmentModel appointment)
        {
            return AppointmentDataService.SaveAppointmentAsync(appointment);
        }

        public Task<int> DeleteAppointmentAsync(int appointmentId)
        {
            return AppointmentDataService.DeleteAppointmentAsync(appointmentId);
        }
    }
}