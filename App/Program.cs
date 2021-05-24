using System;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGalvanize
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var database = new DatabaseContext();

            //write list of student names
            database.Students.ToList().ForEach(student => Console.WriteLine(student.FirstName));

            //given a student name, show their grades
            Console.Out.WriteLine("\nEnter a name to search for grades:");
            string name1 = Console.ReadLine();
            var student1 = database.Students.Include(student => student.Grades)
                .FirstOrDefault(student => student.FirstName.Equals(name1));
            Console.WriteLine($"{student1.FirstName} has the grades: ");
            student1.Grades.ToList().ForEach(grade => Console.Write($"{grade.Score} "));

            //Average grade of student
            Console.Out.WriteLine("\nEnter a name to find average grade:");
            string name2 = Console.ReadLine();
            var student2 = database.Students.Include(student => student.Grades)
                .FirstOrDefault(student => student.FirstName.Equals(name2));
            float average = student2.Grades.Average(grade => grade.Score);
            Console.Out.WriteLine($"{student2.FirstName}'s average score is {average}.");

            //student with the highest score
            var studentByAveragesDesc = database.Students.Include(student => student.Grades).Select(student => student)
                .OrderByDescending(student => student.Grades.Average(grade => grade.Score));
            Console.Out.WriteLine(
                $"\nThe student with the highest average is : {studentByAveragesDesc.First().FirstName}");

            //student with the highest # of courses
            
        }
    }
}