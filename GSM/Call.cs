using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class Call
    {
        private string date;
        private string time;
        private string dialedNumber;
        private int duration;

        public Call(string date, string time, string dialedNumber, int duration)
        {
            this.date = date;
            this.time = time;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }

        public string Date
        {
            get { return date; }
        }

        public string Time
        {
            get { return time; }
        }

        public string DialedNumber
        {
            get { return dialedNumber; }
        }

        public int Duration
        {
            get { return duration; }
        }

 
    }
}
