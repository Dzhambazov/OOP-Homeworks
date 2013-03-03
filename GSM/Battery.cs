using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    class Battery
    {
        private BatteryType type;
        private string model;
        private int? hours_idle;
        private int? hours_talk;

        public Battery()
        {
        }

        public Battery(BatteryType type)
            : this(type, null, null, null)
        {
        }

        public Battery(BatteryType type, string model)
            : this(type, model, null, null)
        {
        }

        public Battery(BatteryType type, string model, int hours_idle)
            : this(type,model, hours_idle, null)
        {
        }

        public Battery(BatteryType type, string model, int? hours_idle, int? hours_talk)
        {
            this.type = type;
            this.model = model;
            this.hours_idle = hours_idle;
            this.hours_talk = hours_talk;
        }

        public BatteryType Type
        {
            get { return type; }
        }
        public string Model
        {
            get { return model; }
            set 
            {
                if (value.Length >= 2)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("Battery model should be at lesat 2 characters!");
                }
            }
        }


        public int? HoursIdle
        {
            get { return hours_idle; }
            set 
            {
                if (value >= 0)
                {
                    this.hours_idle = value;
                }
                else
                {
                    throw new ArgumentException("Hours idle should be a positive number!");
                }
            }
        }


        public int? HoursTalk
        {
            get { return hours_talk; }
            set 
            {
                if (value >= 0)
                {
                    this.hours_talk = value;
                }
                else
                {
                    throw new ArgumentException("Hpurs talk should be a positive number!");
                }
            }
        }



    }
}
