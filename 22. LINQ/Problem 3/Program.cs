using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem 4: ");
            var students = new List<Student>()
            {
                new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 15 },
                new Student { FirstName = "Georgi", LastName = "Georgiev", Age = 19 },
                new Student { FirstName = "Nikolai", LastName = "Tanov", Age = 22 }
            };
            List<dynamic> st = Student.FindStudentsBetweenAges(students);
            foreach (var item in st)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine("Problem 5: ");
            var orderedStudents = students.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            foreach (var item in orderedStudents)
            {
                Console.WriteLine(item.ToString());
            }
            


        }
    }
}
