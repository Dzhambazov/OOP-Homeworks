using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Class : ICommentable
    {
        private readonly List<Student> students = new List<Student>();
        private readonly List<Teacher> teachers = new List<Teacher>();
        public string Signature { get; set; }
        public string Comment { get; set; }


        public Class(string signature)
        {
            this.Signature = signature;
        }

        public List<Student> Students
        {
            get { return students; }
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }


        public override string ToString()
        {
            var sortStudents =
                from student in students
                orderby student.FirstName, student.MiddleName, student.LastName
                select student;  

            StringBuilder result = new StringBuilder();
            result.AppendLine(this.Signature + " class");
            result.AppendLine("Students list:");
            foreach (var student in sortStudents)
            {
                result.Append(student);
            }

            var sortTeachers =
                from teacher in teachers
                orderby teacher.FirstName, teacher.MiddleName, teacher.LastName
                select teacher;
            result.AppendLine();
            result.AppendLine("Teachers list:");
            foreach (var teacher in sortTeachers)
            {
                result.Append(teacher);
            }
            return result.ToString();
        }
    }
}
