using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            Discipline Math = new Discipline("Math", 10, 10);
            Discipline Physics = new Discipline("Physics", 5, 5);
            Discipline English = new Discipline("English", 12, 12);
            Teacher teacher1 = new Teacher("Joro", "Jorev", "Jorkata");
            Teacher teacher2 = new Teacher("Ivan", "Ivanov", "Vankata");
            Student student1 = new Student("Peter", "Peshev", "Petrov", "F55516");
            Student student2 = new Student("Pesho", "Peshev", "Peshoto", "F52341");

            Class myClass = new Class("11b");
            myClass.AddStudent(student1);
            myClass.AddStudent(student2);
            myClass.AddStudent(new Student("Gosho","Goshev","Georgiev","F101010"));
            // remove student1
            myClass.RemoveStudent(student1);

            teacher1.AddDiscipline(Math);
            teacher1.AddDiscipline(Physics);
            teacher2.AddDiscipline(English);
            //remove math
            teacher1.RemoveDiscipline(Math);

            myClass.AddTeacher(teacher1);
            myClass.AddTeacher(teacher2);

            Console.WriteLine(myClass);

 
            
            
        }
    }
}
