using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreGalvanize
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Class Classification { get; set; }
        public List<Grade> Grades { get; set; }

        public enum Class
        {
            Freshman,
            Sophomore,
            Junior,
            Senior
        }
    }
}