using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Teacher : Person
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
        }

        public Teacher(string firstName, string middleName, string lastName) : base(firstName, middleName,lastName)
        {

        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.disciplines.Remove(discipline);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.FirstName + " " + this.MiddleName + " " + this.LastName);
            result.Append("Disciplines: ");
            foreach (var discipline in disciplines)
            {
                result.Append(discipline);
            }
            result.AppendLine();
            return result.ToString();
        }
    }
}
