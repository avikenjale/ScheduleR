using System;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Domain.Models
{
    public class AppointmentModel
    {
        public int AppointmentId {get;set;}
        public int StudentId {get;set;} 
        public int ClassId {get;set;} 
        public int TeacherId {get;set;} 
        public string AppointmentTime {get;set;}       
    }
}