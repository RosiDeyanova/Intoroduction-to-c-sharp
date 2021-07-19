using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public List<Student> FindStudentWithLongerFirstName(List<Student> students)
        {
            var outputStudents = students.FindAll(x => (x.FirstName.Length) > (x.LastName.Length));
            return outputStudents;
        }

        public static List<object> FindStudentsBetweenAges(List<Student> students)
        {
            var outputStudents = (from student in students
                                  where student.Age >= 18 && student.Age <= 24
                                  select new { student.FirstName, student.LastName } as object).ToList();

            return outputStudents;
        }

        public override string ToString()
        {
            return ("First name: " + FirstName + " " + "Last name: " + LastName + " " + "Age: " + Age);
        }
    }
}
