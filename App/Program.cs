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
            
            // Console.Out.WriteLine("Enter a name to search for grades:");
            // string name = Console.ReadLine();
            // var student1 = database.Students.FirstOrDefault(student => student.FirstName.Equals(name));
            // Console.WriteLine($"{student1} has the grades: ");
            // var grades = student1.Grades.ToList();
            
            
        }
    }
}