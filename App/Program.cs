using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGalvanize
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext database = new DatabaseContext();
            
            //write list of student names
            database.Students.ToList().ForEach(student => Console.WriteLine(student.FirstName));
            
            //given a student name, show their grades
            
            Console.Out.WriteLine("\nEnter a name to search for grades:");
            string name = Console.ReadLine();
            var student1 = database.Students.Include(student => student.Grades ).FirstOrDefault(student => student.FirstName.Equals(name));
            Console.WriteLine($"{student1.FirstName} has the grades: ");
            student1.Grades.ToList().ForEach(grade => Console.Write($"{grade.Score}" ));

            // const string student2Name = "Robert";
            // var student2 = database.Students.FirstOrDefault(student => student.FirstName.Equals(student2Name));
            // // var average = student2.Grades.ToList().Average();

            //var averageGrades = database.Students.


        }
    }
}