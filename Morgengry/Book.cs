using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Book : Merchandise
    {
        //public string ItemID { get; private set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Book(string itemID):
            this(itemID, "", 0) //this i denne sammenshæng betyder at den prøver at finde en anden constructor i klassen
        {
        }

        public Book(string itemID, string title):
            this(itemID, title, 0) //this i denne sammenshæng betyder at den prøver at finde en anden constructor i klassen
        {
        }

        public Book(string itemID, string title,double price)//:
            //base(itemID) //base i denne sammenhæng betyder at den lede efter det sted den arver fra "itemID" som ligger Merchandise
        {
            ItemId = itemID;
            Title = title;
            Price = price;
        }

        public override string ToString()
        {
            return "ItemId: " + ItemId + ", " + "Title: " + Title + ", " + "Price: " + Price;
        }

        public override double GetValue()
        {
            return Price;
        }

    }

    
}
