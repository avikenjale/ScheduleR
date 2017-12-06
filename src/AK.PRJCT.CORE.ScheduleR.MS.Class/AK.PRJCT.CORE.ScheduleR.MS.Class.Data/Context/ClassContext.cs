using Microsoft.EntityFrameworkCore;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Context
{
    public class ClassContext : DbContext
    {
        public DbSet<Entities.Models.Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Avinash\Learning\dotnetcore\scheduleR\database\Class\Class.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Class>()
            .ToTable("Classes")
            .HasKey(c => c.ClassId);
        }
    }
}