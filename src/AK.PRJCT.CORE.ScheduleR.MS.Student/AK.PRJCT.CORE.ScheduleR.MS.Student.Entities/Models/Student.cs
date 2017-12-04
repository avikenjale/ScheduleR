namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Parent Parent { get; set; }
    }
}