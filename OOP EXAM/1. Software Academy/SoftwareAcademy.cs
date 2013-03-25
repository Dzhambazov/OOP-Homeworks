using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name,teacher,lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

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

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        public string Town
        {
            get;
            set;
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }


        public override void AddTopic(string topic)
        {
            courseTopics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("Town=");
            result.Append(this.Town);
            return result.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {

        public string Lab
        {
            get;
            set;
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }



        public override void AddTopic(string topic)
        {
            courseTopics.Add(topic);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("Lab=");
            result.Append(this.Lab);
            return result.ToString();
        }
    }

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