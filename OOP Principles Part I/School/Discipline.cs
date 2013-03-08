using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Discipline : ICommentable
    {
        public string Name { get; set; }
        public int NumberLectures { get; set; }
        public int NumberExercises { get; set; }
        public string Comment { get; set; }

        public Discipline(string name, int numberLectures, int numberExercises)
        {
            this.Name = name;
            this.NumberLectures = numberLectures;
            this.NumberExercises = numberExercises;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
