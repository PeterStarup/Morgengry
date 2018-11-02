using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Course : IValuable
    {
        private double coursehourvalue = 825.00;
        private int durationinminutes;

        public double CourseHourValue
        {
            get
            {
                return coursehourvalue;
            }
            set
            {
                coursehourvalue = value;
            }
        }
        public string Name { get; set; }
        public int DurationInMinutes
        {
            get
            {
                return durationinminutes;
            }
            set
            {
                durationinminutes = value;
            }
        }

        public Course(string name):
            this(name, 0)
        {
        }

        public Course(string name, int duration)
        {
            Name = name;
            DurationInMinutes = duration;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", " + "Duration in Minutes: " + DurationInMinutes + ", Pris pr påbegyndt time: " + CourseHourValue;
        }

        public double GetValue()
        {
            double hours = DurationInMinutes % 60;

            if (hours >= 30)
            {
                return (DurationInMinutes / 60 + 1) * CourseHourValue;
            }
            else
            {
                return (DurationInMinutes / 60) * CourseHourValue;
            }
        }
    }
}
