using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp.MSDN
{
    public class GroupedJoin
    {
        private static readonly IEnumerable<Department> departments = Sources.Departments;
        private static readonly IEnumerable<Student> students = Sources.Students;
        private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;

        public void GroupJoin_MethodSyntax()
        {
            /*
            The following example performs a group join of objects of type Department and Student based on the Department.ID matching the Student.DepartmentID property. 
            Unlike a non-group join, which produces a pair of elements for each match, 
            the group join produces only one resulting object for each element of the first collection, which in this example is a Department object. 
            The corresponding elements from the second collection, which in this example are Student objects, are grouped into a collection. 
            Finally, the result selector function creates an anonymous type for each match that consists of Department.Name and a collection of Student objects.
             */
            var query = departments.GroupJoin
                (students, 
                department => department.ID, 
                student => student.DepartmentID, 
                (department, Students) => new { DepartmentName = department.Name, Students }
                );

            foreach (var v in query) //output is departmentname and list of students in that dept.
            {
                // Output the department's name.
                Console.WriteLine($"{v.DepartmentName}:");

                // Output each of the students in that department.
                foreach (Student? student in v.Students)
                {
                    Console.WriteLine($"  {student.FirstName} {student.LastName}");
                }
            }

        }
        public void GroupJoin_QuerySyntax()
        {
            IEnumerable<IEnumerable<Student>> studentGroups = from department in departments
                                                              join student in students on department.ID equals student.DepartmentID into studentGroup
                                                              select studentGroup;
            foreach (IEnumerable<Student> studentGroup in studentGroups)
            {
                Console.WriteLine("Group");
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine($"  - {student.FirstName}, {student.LastName}");
                }
            }


            var studentGroupMethod = departments.GroupJoin(students, d => d.ID, s => s.DepartmentID, (d, s) => new { Department = d, group = s });

            foreach (var studentGroup in studentGroupMethod)
            {
                Console.WriteLine("Group");
                foreach (var student in studentGroup.group)
                {
                    Console.WriteLine($"  - {student.FirstName}, {student.LastName}");
                }
            }
        }
    }
}
