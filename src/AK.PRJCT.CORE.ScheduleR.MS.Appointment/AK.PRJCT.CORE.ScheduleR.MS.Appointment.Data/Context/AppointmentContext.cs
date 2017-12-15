using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Context
{
    public class AppointmentContext : DbContext
    {
        public DbSet<Entities.Models.Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite(@"Data Source=C:\Avinash\Learning\dotnetcore\scheduleR\database\Appointment\Appointment.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Appointment>()
                .ToTable("Appointments")
                .HasKey(a => a.AppointmentId);
        }
    }
}