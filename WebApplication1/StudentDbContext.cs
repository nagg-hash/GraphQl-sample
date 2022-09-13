using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student>? StudentData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "VesselInsight")
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToContainer("Student");
            modelBuilder.Entity<Student>().HasNoDiscriminator();

            modelBuilder.Entity<Student>().HasPartitionKey(o => o.Id);
            modelBuilder.Entity<Student>().Property(x => x.Id).ToJsonProperty("id");

            modelBuilder.Entity<Student>().OwnsOne(
                o => o.Name,
                sa =>
                {
                    sa.ToJsonProperty("name");
                    sa.Property(p => p.LName).ToJsonProperty("lname");
                    sa.Property(p => p.FName).ToJsonProperty("fname");
                });

            modelBuilder.Entity<Student>().OwnsMany(
                p => p.Subjects,
                sa =>
                {
                    sa.ToJsonProperty("subjects");
                    sa.Property(p => p.SubjectId).ToJsonProperty("subjectId");
                    sa.Property(p => p.Name).ToJsonProperty("name");
                });
        }
    }
}
