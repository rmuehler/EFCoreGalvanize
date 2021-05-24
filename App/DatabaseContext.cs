using Microsoft.EntityFrameworkCore;

namespace EFCoreGalvanize
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var grades = new Grade[]
            {
                new Grade() {Id = 1, StudentId =  3, CourseName = "Calculus 302", Score = 89},
                new Grade() {Id = 2, StudentId  =  1, CourseName = "English 101", Score = 98},
                new Grade() {Id = 3, StudentId = 2, CourseName = "Computer Science 203", Score = 66},
                new Grade() {Id = 4, StudentId  = 1, CourseName = "Woodwork 200", Score = 45},
                new Grade() {Id = 5,  StudentId = 5, CourseName = "Database Design 101", Score = 0}
            };

            var students = new Student[]
            {
                new Student()
                {
                    Id = 1, FirstName = "Robert", LastName = "Muehler", Age = 22, Classification = Student.Class.Senior
                },
                new Student()
                    {Id = 2, FirstName = "Bob", LastName = "Evans", Age = 21, Classification = Student.Class.Junior},
                new Student()
                {
                    Id = 3, FirstName = "Ronald", LastName = "McDonald", Age = 20,
                    Classification = Student.Class.Sophomore
                },
                new Student()
                {
                    Id = 4, FirstName = "Joseph", LastName = "Biden", Age = 121, Classification = Student.Class.Senior
                },
                new Student()
                    {Id = 5, FirstName = "Frank", LastName = "Biden", Age = 18, Classification = Student.Class.Freshman}
            };

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Grade>().HasData(grades);
            base.OnModelCreating(modelBuilder);
        }
    }
}