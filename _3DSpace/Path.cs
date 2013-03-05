using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    class Path
    {
        private List<Point3D> allPaths = new List<Point3D>();


        public List<Point3D> AllPaths
        {
            get { return allPaths; }
        }


        public void AddPath(Point3D path)
        {
            allPaths.Add(path);
        }

        public void RemovePath(int pathIndex)
        {
            allPaths.RemoveAt(pathIndex);
        }

        public void ClearAllPaths()
        {
            allPaths.Clear();
        }
    }
}
