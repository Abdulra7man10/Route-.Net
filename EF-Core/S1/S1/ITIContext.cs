using ITI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection.Emit;

namespace ITI
{
    public class ITIContext : DbContext
    {
        public ITIContext() : base() { }

        public ITIContext(DbContextOptions<ITIContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Stud_Course> StudentCourses { get; set; }
        public DbSet<Course_Instructor> CourseInstructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stud_Course>()
                .HasKey(sc => new { sc.Stud_Id, sc.Course_Id });

            modelBuilder.Entity<Course_Instructor>()
                .HasKey(ci => new { ci.Course_Id, ci.Inst_Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
