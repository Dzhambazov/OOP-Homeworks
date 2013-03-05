using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    class Program
    {
        public static void Main()
        {
            Path myPaths = new Path();
            myPaths.AddPath(new Point3D(2.3, 5.3, 2.6));
            myPaths.AddPath(new Point3D(12, 53, 22));
            myPaths.AddPath(new Point3D(-1.2, -2, -5.2));

            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 3, 2);

            //Display some new paths
            Console.WriteLine("Display some new paths");
            Console.WriteLine();
            foreach(var path in myPaths.AllPaths)
            {
                Console.WriteLine(path);
            }


            //Load Paths from file
            Console.WriteLine();
            Console.WriteLine("Load Paths from file");
            Console.WriteLine();

            foreach (var v in PathStorage.LoadPath().AllPaths)
            {
                Console.WriteLine(v);
            }

            //Save paths in file
            Console.WriteLine();
            Console.WriteLine("Save paths in a file");
            Console.WriteLine();
            PathStorage.SavePath(myPaths);
            
            //Calc Distance btw two points
            Console.WriteLine();
            Console.WriteLine("Calc distance btw points");
            Console.WriteLine();
            Console.WriteLine(DistanceBtwPoints.Distance(point1, point2));
           
        }
    }
}
