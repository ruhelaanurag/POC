using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp.MSDN
{
    public class LeftOuterJoin
    {
        /*
         * A left outer join is a join in which each element of the first collection is returned, 
         * regardless of whether it has any correlated elements in the second collection. 
         * You can use LINQ to perform a left outer join by calling the DefaultIfEmpty method on the results of a group join.
         */

        private static readonly IEnumerable<Department> departments = Sources.Departments;
        private static readonly IEnumerable<Student> students = Sources.Students;
        private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;

        public void LeftOuterJoin_MethodSyntax()
        {
            /*
             * The first step in producing a left outer join of two collections is to perform an inner join by using a group join.
             * The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. 
             * This is accomplished by calling DefaultIfEmpty on each sequence of matching elements from the group join.
             */
            var query = students.GroupJoin(
                                            departments,
                                            s => s.DepartmentID,
                                            d => d.ID,
                                            (s, departmentList) => new { s, subgroup = departmentList });
            var result = query.SelectMany(
                                            result => result.subgroup.DefaultIfEmpty(),
                                            (s2, d2) => new
                                            {
                                                s2.s.FirstName,
                                                s2.s.LastName,
                                                Department = d2?.Name
                                            });

            foreach (var v in result)
            {
                Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
            }
        }

        public void LeftOuterJoin_QuerySyntax()
        {
            var query = from student in students
                        join department in departments on student.DepartmentID equals department.ID into gj
                        from subgroup in gj.DefaultIfEmpty()
                        select new
                        {
                            student.FirstName,
                            student.LastName,
                            Department = subgroup?.Name ?? string.Empty
                        };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
            }
        }
    }
}
