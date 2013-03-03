using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    class GSM
    {
        Battery battery = new Battery();
        Display display = new Display();

        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private static readonly GSM iPhone4S = new GSM("iPhone4S","Apple",989.99,"Pesho");
        private List<Call> callHistory = new List<Call>();


        public GSM(string model, string manufacturer)
            : this(model, manufacturer,null, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, double price)
            : this(model, manufacturer, price, null, null, null)
        {
        }

        public GSM(string model, string manufacturer, double price, string owner)
            : this(model, manufacturer, price, owner, null, null)
        {
        }


        public GSM(string model, string manufacturer, double price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, null)
        {
        }

        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return model; }
            set 
            {
                if (value != null && value.Length >= 2)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("Model should be at least 2 characters");
                }
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("Manufacturer name should be at least 2 characters!");
                }
            }
        }

        public double? Price
        {
            get { return price; }
            set 
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Price should be a positive number!");
                }
            }
        }


        public string Owner
        {
            get { return owner; }
            set 
            {
                if (value.Length >= 2)
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentException("Owbers name should be at least 2 characters!");
                }
            }
        }

        public List<Call> CallHistory
        {
            get { return callHistory; }
        }


        public void AddCall(string date, string time, string dialedNumber, int duration)
        {
            CallHistory.Add(new Call(date,time,dialedNumber,duration));
        }

        public void DeleteCall(int index)
        {
            CallHistory.RemoveAt(index);
        }

        public void ClearAllCalls()
        {
            CallHistory.Clear();
        }


        public double TotalPrice(double price)
        {
            double sum = 0;
            foreach (var call in CallHistory)
            {
                sum += call.Duration / 60 * price;
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Model: " + this.model);
            result.AppendLine("Manufacturer: " + this.manufacturer);
            result.AppendLine("Price: " + this.price);
            result.AppendLine("Owner: " + this.owner);
            result.AppendLine("Battery: " + this.battery.Model + " " + this.battery.HoursIdle + " " + this.battery.HoursTalk);
            result.AppendLine("Display: " + this.display.Size + " " + this.display.ColorsNum);
            return result.ToString();
        }


    }
}
