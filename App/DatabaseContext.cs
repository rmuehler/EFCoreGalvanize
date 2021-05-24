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
                new Grade() {CourseName = "Calculus 302", Score = 89},
                new Grade() {CourseName = "English 101", Score = 98},
                new Grade() {CourseName = "Computer Science 203", Score = 66},
                new Grade() {CourseName = "Woodwork 200", Score = 45},
                new Grade() {CourseName = "Database Design 101", Score = 0}
            };

            var students = new Student[]
            {
                new Student()
                    {FirstName = "Robert", LastName = "Muehler", Age = 22, Classification = Student.Class.Senior},
                new Student()
                    {FirstName = "Bob", LastName = "Evans", Age = 21, Classification = Student.Class.Junior},
                new Student()
                    {FirstName = "Ronald", LastName = "McDonald", Age = 20, Classification = Student.Class.Sophomore},
                new Student()
                    {FirstName = "Joseph", LastName = "Biden", Age = 121, Classification = Student.Class.Senior},
                new Student()
                    {FirstName = "Frank", LastName = "Biden", Age = 18, Classification = Student.Class.Freshman}
            };
            
            modelBuilder.Entity<Grade>().HasData(grades);
            modelBuilder.Entity<Student>().HasData(students);
            base.OnModelCreating(modelBuilder);
        }
    }
}