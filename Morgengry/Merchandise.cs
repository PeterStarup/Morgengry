using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public abstract class Merchandise : IValuable
    {
        public string ItemId { get; set; }

        /*public Merchandise(string ItemID)
        {
            this.ItemID = ItemID;
        }*/

        public override string ToString()
        {
            return "ItemId: " + ItemId;
        }

        public abstract double GetValue();
    }
}
