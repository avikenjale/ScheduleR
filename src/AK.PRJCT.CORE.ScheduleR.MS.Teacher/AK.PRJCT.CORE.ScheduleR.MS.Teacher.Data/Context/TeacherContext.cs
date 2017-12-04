using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Context
{
    public class TeacherContext : DbContext
    {
        public DbSet<Entities.Models.Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Avinash\Learning\dotnetcore\scheduleR\database\Teacher\Teacher.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Teacher>()
            .ToTable("Teachers")
            .HasKey(t => t.TeacherId);
        }
    }
}