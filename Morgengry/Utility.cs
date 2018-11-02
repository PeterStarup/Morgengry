using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Utility
    {
        private double lowqualityvalue = 12.5;
        private double mediumqualityvalue = 20.0;
        private double highqualityvalue = 27.5;
        private double coursehourvalue = 875.00;
        public double LowQualityValue
        {
            get
            {
                return lowqualityvalue;
            }
            set
            {
                lowqualityvalue = value;
            }
        }
        public double MediumQualityValue
        {
            get
            {
                return mediumqualityvalue;
            }
            set
            {
                mediumqualityvalue = value;
            }
        }
        public double HighQualityValue
        {
            get
            {
                return highqualityvalue;
            }
            set
            {
                highqualityvalue = value;
            }
        }
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

        public static double GetValueOfBook(Book book)
        {
            return book.Price;
        }

        public static double GetValueOfAmulet(Amulet amulet)
        {
            if (amulet.Quality.ToString() == "low")
            {
                return 12.5;
            }
            else if (amulet.Quality.ToString() == "medium")
            {
                return 20.0;
            }
            else
            {
                return 27.5;
            }
        }

        public static double GetValueOfCourse(Course course)
            //En anden måde at beregne det på er (course.DurationInMinutes + 59) / 60 * 875.00 - Mikkels udregning
        {
            Utility util = new Utility();
            double hours = course.DurationInMinutes % 60;
            
            if(hours >= 30)
            {
                return (course.DurationInMinutes / 60 + 1) * util.CourseHourValue;
            }
            else
            {
                return (course.DurationInMinutes / 60) * util.CourseHourValue;
            }
        }

        public static double GetValueOfMerchandise(Merchandise merchandise)
        {
            Utility util = new Utility();
            double value = 0.0;
            if (merchandise is Book book)
            {
                value = book.Price;
            }
            else if (merchandise is Amulet amulet)
            {
                if (amulet.Quality.ToString() == "low")
                {
                    value = util.LowQualityValue;
                }
                else if (amulet.Quality.ToString() == "medium")
                {
                    value = util.MediumQualityValue;
                }
                else
                {
                    value = util.HighQualityValue;
                }
            }
            return value;
        }
    }
}
