using EF_relationship_between_the_table.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF_relationship_between_the_table
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses {  get; set; }
        public DbSet<StudentCourse> StudentCourses {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(sc=>new {sc.studentId,sc.CourseId});
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;" +
                    "Database=Db_relationship;" +
                    "Trusted_Connection=True;" +
                    "TrustServerCertificate=True"
                )
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(
                    LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole();
                    })
                );
        }
    }
}

