using System;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Domain.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Parent Details 
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}