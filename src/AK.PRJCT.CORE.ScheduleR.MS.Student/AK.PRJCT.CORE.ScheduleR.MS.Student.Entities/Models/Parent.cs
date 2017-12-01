using System.Collections.Generic;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public int Zip { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}