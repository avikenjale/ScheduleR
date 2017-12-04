using Microsoft.EntityFrameworkCore;
using AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.Data.Context
{
    public class StudentContext:DbContext
    {
        public DbSet<AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models.Student> Students {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Avinash\Learning\dotnetcore\scheduleR\database\Student\Student.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models.Parent>()
            .ToTable("Parents")
            .HasKey(p => p.ParentId);

             modelBuilder.Entity<AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models.Student>()
            .ToTable("Students")
            .HasKey(s => s.StudentId);

             modelBuilder.Entity<AK.PRJCT.CORE.ScheduleR.MS.Student.Entities.Models.Student>()
            .ToTable("Students")
            .HasOne(s => s.Parent);
        }
    }
}