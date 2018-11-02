using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morgengry
{
    public class ValuableRepository : IPersistable
    {
        private List<IValuable> valuables = new List<IValuable>();

        public void AddValuable(IValuable valuable)
        {
            valuables.Add(valuable);
        }

        public IValuable GetValuable(string itemId)
        {
            for (int i = 0; i < valuables.Count; i++)
            {
                if (valuables[i] is Course cour)
                {
                    if (cour.Name == itemId)
                    {
                        return valuables[i];
                    }
                }
                else if (valuables[i] is Merchandise mer)
                {
                    if (mer.ItemId == itemId)
                    {
                        return valuables[i];
                    }
                }
            }
            return null;
        }

        public double GetTotalValue()
        {
            double value = 0;
            for (int i = 0; i < valuables.Count; i++)
            {
                if (valuables[i] is Course cour)
                {
                    value += cour.GetValue();
                }
                else if (valuables[i] is Merchandise mer)
                {
                    if (valuables[i] is Book b)
                    {
                        value += b.GetValue();
                    }
                    else if (valuables[i] is Amulet amul)
                    {
                        value += amul.GetValue();
                    }
                }
            }
            return value;
        }

        public int Count()
        {
            int count = 0;
            foreach(IValuable i in valuables)
            {
                count++;
            }
            return count;
        }

        public void Save()
        {

        }

        public void Save(string filename)
        {

        }

        public void Load()
        {

        }

        public void Load(string filename)
        {

        }
    }
}
