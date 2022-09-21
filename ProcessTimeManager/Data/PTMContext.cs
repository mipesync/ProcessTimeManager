using Microsoft.EntityFrameworkCore;

namespace ProcessTimeManager.Data
{
    public class PTMContext : DbContext
    {
        public DbSet<DataProcess> DataProcesses { get; set; } = null!;

        public PTMContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ptm.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DataProcess>()
                .ToTable("DataProcesses")
                .HasKey(builder => builder.ProcessId);
        }
    }
}
