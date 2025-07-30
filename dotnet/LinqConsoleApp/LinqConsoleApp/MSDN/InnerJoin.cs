using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp.MSDN
{
    public class InnerJoin
    {
        /*Join	
         *      Joins two sequences based on key selector functions and extracts pairs of values.
         *      join … in … on … equals …	
         *      Enumerable.Join
         *      Queryable.Join
         *      
         *GroupJoin	
         *      Joins two sequences based on key selector functions and groups the resulting matches for each element.	
         *      join … in … on … equals … into …	
         *      Enumerable.GroupJoin
         *      Queryable.GroupJoin
         */
        private static readonly IEnumerable<Department> departments = Sources.Departments;
        private static readonly IEnumerable<Student> students = Sources.Students;
        private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;

        public void SingleKeyJoin_MethodSyntax()
        {

            //this IEnumerable<TOuter> outer,
            //IEnumerable<TInner> inner,
            //Func<TOuter, TKey> outerKeySelector,
            //Func<TInner, TKey> innerKeySelector,
            //Func<TOuter, TInner, TResult> resultSelector
            var queryMethod = departments.Join(students, d => d.ID, s => s.DepartmentID, (d, s) => new { Department = d.Name, Student = s.FirstName + " " + s.LastName });

            foreach (var departmentAndStudent in queryMethod)
            {
                Console.WriteLine($"{departmentAndStudent.Department} is in {departmentAndStudent.Student}");
            }
        }

        public void CompositeKeyJoin_MethodSyntax()
        {
            //The following example uses a list of Teacher objects and a list of Student objects to determine which teachers are also students.

            //this IEnumerable<TOuter> outer,
            //IEnumerable<TInner> inner,
            //Func<TOuter, TKey> outerKeySelector,
            //Func<TInner, TKey> innerKeySelector,
            //Func<TOuter, TInner, TResult> resultSelector)
            IEnumerable<string> queryMethod = teachers.Join(students,
                                                        t => new { FirstName = t.First, LastName = t.Last }, //firstname, lastname is composite key
                                                        s => new { s.FirstName, s.LastName },
                                                        (t, s) => $"{t.First} {t.Last}");

            Console.WriteLine("The following people are both teachers and students:");
            foreach (string name in queryMethod)
            {
                Console.WriteLine(name);
            }
        }

        public void MultipleJoin_MethodSyntax()
        {
            //The following example uses a list of Student objects, a list of Department objects,
            //and a list of Teacher objects to determine which students are in which departments,
            //and which teachers lead those departments.

            //The first join clause matches students and departments based on a Student object's DepartmentID matching a Department object's ID.
            //It returns a sequence of anonymous types that contain the Student object and Department object.

            //The second join clause correlates the anonymous types returned by the first join with Teacher objects based on that teacher's ID matching the department head ID.

            // The first join matches Department.ID and Student.DepartmentID from the list of students and
            // departments, based on a common ID. The second join matches teachers who lead departments
            // with the students studying in that department.

            var result = students.Join(departments, s => s.DepartmentID, d => d.ID, (s, d) => new { s, d });
            var result2 = result.Join(teachers, r => r.d.TeacherID, t => t.ID, (r, t) => new
            {
                s = r.s,
                d = r.d,
                t = t
            }).OrderBy(x => x.d.ID).OrderBy(x => x.s.FirstName);

            foreach (var item in result2)
            {
                Console.WriteLine($"{item.d.TeacherID} , {item.t.First} , {item.d.Name} , {item.s.FirstName} {item.s.LastName}");
            }
        }

        public void JoinvsGroupJoin() 
        {
            var queryMethod = departments.Join(students, d=>d.ID, s=>s.DepartmentID, (d, s) => new { d.Name, s.FirstName });

            var queryMethod1 = departments.GroupJoin(students,
                                        department => department.ID,
                                        student => student.DepartmentID,
                                        (department, lstStudents) => new { department, lstStudents });
            var result = queryMethod1.SelectMany(x => x.lstStudents, (x, y) => new { x.department.Name, y.FirstName });


        }

        public void InnerjoinUsingGroupJoin_MethodSyntax()
        {
            //The list of Department objects is group-joined to the list of Student objects based on the Department.ID matching the Student.DepartmentID property.
            //The group join creates a collection of intermediate groups, where each group consists of a Department object and a sequence/list of matching Student objects
            //The SelectMany method is then used to flatten the collection of groups into a collection of Student objects, each of which has a Department object.


            var queryMethod1 = departments.GroupJoin(students,
                                                    department => department.ID,
                                                    student => student.DepartmentID,
                                                    (department, gj) => new { department, gj })
                                            .SelectMany(departmentAndStudent => departmentAndStudent.gj,
                                                        (departmentAndStudent, subStudent) => new
                                                        {
                                                            DepartmentName = departmentAndStudent.department.Name,
                                                            StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
                                                        });
            //this IEnumerable<TSource> source, Func< TSource,
            //IEnumerable < TCollection >> collectionSelector, Func<TSource, TCollection, TResult> resultSelector
            Console.WriteLine("Inner join using GroupJoin():");
            foreach (var v in queryMethod1)
            {
                Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
            }
        }

        #region Query Syntax
        public void SingleKeyJoin_QuerySyntax()
        {
            var query = from department in departments
                        join student in students on department.ID equals student.DepartmentID
                        select new
                        {
                            DepartmentName = department.Name,
                            StudentName = student.FirstName + " " + student.LastName
                        };

            foreach (var departmentAndStudent in query)
            {
                Console.WriteLine($"{departmentAndStudent.StudentName} is in {departmentAndStudent.DepartmentName}");
            }
        }

        public void CompositeKeyJoin_QuerySyntax()
        {
            //The following example uses a list of Teacher objects and a list of Student objects to determine which teachers are also students.
            IEnumerable<string> query = from teacher in teachers
                                        join student in students on new
                                        {
                                            FirstName = teacher.First,
                                            LastName = teacher.Last
                                        } equals new
                                        {
                                            student.FirstName,
                                            student.LastName
                                        }
                                        select teacher.First + " " + teacher.Last;

            string result = "The following people are both teachers and students:\r\n";
            foreach (string name in query)
            {
                result += $"{name}\r\n";
            }
            Console.Write(result);
        }

        public void MultipleJoin_QuerySyntax()
        {
            var query = students.Join(departments,
                                        student => student.DepartmentID,
                                        department => department.ID,
                                        (student, department) => new { student, department })
                                .Join(teachers,
                                        dept => dept.department.TeacherID,
                                        teacher => teacher.ID,
                                        (commonDepartment, teacher) => new
                                        {
                                            StudentName = $"{commonDepartment.student.FirstName} {commonDepartment.student.LastName}",
                                            DepartmentName = commonDepartment.department.Name,
                                            TeacherName = $"{teacher.First} {teacher.Last}"
                                        });

            foreach (var obj in query)
            {
                Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.TeacherName}".""");
            }
        }

        #endregion
    }
}
