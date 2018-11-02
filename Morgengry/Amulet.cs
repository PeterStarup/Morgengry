using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public enum Level { low, medium, high };
    public class Amulet : Merchandise
    {
        private double lowqualityvalue = 12.5;
        private double mediumqualityvalue = 20.0;
        private double highqualityvalue = 27.5;

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

        //public string ItemID { get; private set; }
        public string Design { get; set; }

        public Level Quality { get; set; }
        
        public Amulet(string itemID):
            this(itemID, Level.medium, "") //this i denne sammenshæng betyder at den prøver at finde en anden constructor i klassen
        {
        }

        public Amulet(string itemID, Level quality):
            this(itemID, quality, "") //this i denne sammenshæng betyder at den prøver at finde en anden constructor i klassen
        {
        }

        public Amulet (string itemID,Level quality,string design)//:
            //base(itemID)
        {
            ItemId = itemID;
            Quality = quality;
            Design = design;
        }
        
        public override string ToString()
        {
            return "ItemId: " + ItemId + ", " + "Quality: " + Quality + ", " + "Design: " + Design;
        }

        public override double GetValue()
        {
            double value = 0.0;
            if (Quality == Level.low)
            {
                value = LowQualityValue;
            }
            else if (Quality == Level.medium)
            {
                value = MediumQualityValue;
            }
            else
            {
                value = HighQualityValue;
            }
            return value;
        }

    }
}
