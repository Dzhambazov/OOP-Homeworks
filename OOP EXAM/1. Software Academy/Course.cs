using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        protected List<string> courseTopics = new List<string>();
      
        public virtual string Name
        {
            get;
            set;
        }

        public virtual ITeacher Teacher
        {
            get;
            set;
        }

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
        }

        
        public virtual void AddTopic(string topic)
        {
            this.courseTopics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(": Name=");
            result.Append(this.Name);
            result.Append("; ");
            if (this.Teacher != null)
            {
                result.Append("Teacher=");
                result.Append(this.Teacher.Name);
                result.Append("; ");
            }
            if (courseTopics.Count > 0)
            {
                result.Append("Topics=[");
                foreach (var topic in courseTopics)
                {
                    result.Append(topic);
                    result.Append(", ");
                }
                result.Length--;
                result.Length--;
                result.Append("]; ");
            }
            return result.ToString();
        }
    }
}
