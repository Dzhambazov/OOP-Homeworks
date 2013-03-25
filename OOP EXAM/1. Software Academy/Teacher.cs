using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {

        List<ICourse> courses = new List<ICourse>();
        public string Name
        {
            get;
            set;
        }

        public Teacher(string name)
        {
            this.Name = name;
        }

        public void AddCourse(ICourse course)
        {
            courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Teacher: Name=");
            result.Append(this.Name);
            result.Append("; ");
            if (courses.Count > 0)
            {
                result.Append("Courses=[");
                foreach (var course in courses)
                {
                    result.Append(course.Name);
                    result.Append(", ");
                }
                result.Length--;
                result.Length--;
                result.Append("]; ");
            }
            result.Length--;
            result.Length--;
            return result.ToString();
        }
    }
}
