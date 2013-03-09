using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Worker : Human
    {
        public double WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            double result = 0;
            result = this.WeekSalary / 5 / this.WorkHoursPerDay;
            return result;
        }

        public override string ToString()
        {
            string result = this.FirstName + " " + this.LastName + " " + this.WeekSalary + " " + WorkHoursPerDay;
            return result;
        }
    }
}
