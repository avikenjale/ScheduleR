using System.Collections.Generic;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Repository;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Domain.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Services
{
    public class AppointmentDataService: IAppointmentDataService
    {
        protected readonly IAppointmentRepository AppointmentRepository;
        public AppointmentDataService(IAppointmentRepository appointmentRepository)
        {
            AppointmentRepository = appointmentRepository;
        }
        public Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsAsync()
        {
            return AppointmentRepository.GetAppointmentsAsync();
        }
        public Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByDateAsync(string date)
        {
            return AppointmentRepository.GetAppointmentsByDateAsync(date);
        }
        public Task<IEnumerable<Domain.Models.AppointmentModel>> GetAppointmentsByTeacherAsync(int teacherId)
        {
            return AppointmentRepository.GetAppointmentsByTeacherAsync(teacherId);
        }
        public Task<int> SaveAppointmentAsync(Domain.Models.AppointmentModel appointment)
        {
            return AppointmentRepository.SaveAppointmentAsync(appointment);
        }

        public Task<int> DeleteAppointmentAsync(int appointmentId)
        {
            return AppointmentRepository.DeleteAppointmentAsync(appointmentId);
        }
    }
}