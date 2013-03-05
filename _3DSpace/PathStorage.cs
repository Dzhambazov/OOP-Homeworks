using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3DSpace
{
    static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter("savedPaths.txt"))
            {
                foreach (var line in path.AllPaths)
                {
                    writer.WriteLine(line);
                }
            }
        }

        public static Path LoadPath()
        {
            Path path = new Path();
             
            using (StreamReader reader = new StreamReader("LoadPaths.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] coordinates = line.Split();
                    Point3D points = new Point3D();
                    points.XPoint = double.Parse(coordinates[0]);
                    points.YPoint = double.Parse(coordinates[1]);
                    points.ZPoint = double.Parse(coordinates[2]);

                    path.AddPath(points);
                    line = reader.ReadLine();
                }
            }
            return path;
        }
    }
}
