using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
             

            Student[] allStudents = {
                                        new Student("Jorkata","Jorev",11),
                                        new Student("Gosheto","Goshev",11),
                                        new Student("Vankata","Ivanov",12),
                                        new Student("Pesheto","Peshev",10),
                                        new Student("Jorkata","Jorev",9),
                                        new Student("Yavkata","Yavorov",11),
                                        new Student("Stenli","Stelqnov",11),
                                        new Student("Minko","Minkov",12),
                                        new Student("Kolio","Koliev",10),
                                        new Student("Stynkata","Stanimirov",9)
                                    };

            Worker[] allWorkers = {
                                      new Worker("Peter","Ivanov",450,8),
                                      new Worker("Hristian","Kalchev",752,12),
                                      new Worker("Kristian","Manchev",480,8),
                                      new Worker("Ivo","Ivanov",550,6),
                                      new Worker("Plamen","Dinkov",350,4),
                                      new Worker("Tihol","Stankov",490,8),
                                      new Worker("Misho","Danchev",650,10),
                                      new Worker("Mario","Georgiev",344,4),
                                      new Worker("Simeon","Tsonev",897,12),
                                      new Worker("Naskov","Georgiev",753,8),
                                  };
            // order students
            var orderedStudents =
                from student in allStudents
                orderby student.Grade
                select student;

            // print ordered list of students
            Console.WriteLine("print ordered list of students");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }

            // order workers
            var orderWorkers =
                from worker in allWorkers
                orderby worker.MoneyPerHour()
                select worker;

            Console.WriteLine("Print ordered list of workers");
            foreach (var worker in orderWorkers)
            {
                Console.WriteLine(worker);
            }
        }
    }
}
