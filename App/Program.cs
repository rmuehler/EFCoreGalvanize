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
            const string name1 = "Robert";
            var student1 = database.Students.Include(student => student.Grades)
                .FirstOrDefault(student => student.FirstName.Equals(name1));
            Console.WriteLine($"\n{student1.FirstName} has the grades: ");
            student1.Grades.ToList().ForEach(grade => Console.Write($"{grade.Score} "));

            //Average grade of student
            const string name2 = "Robert";
            var student2 = database.Students.Include(student => student.Grades)
                .FirstOrDefault(student => student.FirstName.Equals(name2));
            float average = student2.Grades.Average(grade => grade.Score);
            Console.Out.WriteLine($"\n{student2.FirstName}'s average score is {average}.");

            //student with the highest score
            var studentByAveragesDesc = database.Students.Include(student => student.Grades).Select(student => student)
                .OrderByDescending(student => student.Grades.Average(grade => grade.Score));
            Console.Out.WriteLine(
                $"\nThe student with the highest average is: {studentByAveragesDesc.First().FirstName}");

            //student with the highest # of courses
            var studentByNumCoursesDesc = database.Students.Include(student => student.Grades)
                .Select(student => student)
                .OrderByDescending(student => student.Grades.Count);
            Console.Out.WriteLine(
                $"\nThe student with the most number of courses is: {studentByNumCoursesDesc.First().FirstName}");

            //student with no courses
            var studentWithNoCourses = database.Students.Include(student => student.Grades)
                .FirstOrDefault(student => student.Grades.Count.Equals(0));
            Console.Out.WriteLine($"\n{studentWithNoCourses.FirstName} is taking no courses!");

            //number of freshmen
            var freshmenCount = database.Students
                .Select(student => student.Classification).Count(classification => classification.Equals(Student.Class.Freshman));
            Console.Out.WriteLine($"\nThere are {freshmenCount} Freshmen!");
        }
    }
}