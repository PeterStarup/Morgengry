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
            StreamWriter writer = new StreamWriter("ValuableRepository.txt");
            for (int i = 0; i < valuables.Count; i++)
            {
                if (valuables[i] is Merchandise)
                {
                    if (valuables[i] is Book book)
                    {
                        writer.WriteLine("BOG;Id" +  book.ItemId + ";" + book.Title + ";" + book.Price);
                    }
                    else if (valuables[i] is Amulet amulet)
                    {
                        writer.WriteLine("AMULET;Id" + amulet.ItemId + ";" + amulet.Quality + ";" + amulet.Design);
                    }
                }
                else if (valuables[i] is Course cour)
                {
                    writer.WriteLine("KURSUS;" + cour.Name + ";" + cour.DurationInMinutes);
                }
            }
            writer.Close();
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            for (int i = 0; i < valuables.Count; i++)
            {
                if (valuables[i] is Merchandise)
                {
                    if (valuables[i] is Book book)
                    {
                        writer.WriteLine("BOG;Id" + book.ItemId + ";" + book.Title + ";" + book.Price);
                    }
                    else if (valuables[i] is Amulet amulet)
                    {
                        writer.WriteLine("AMULET;Id" + amulet.ItemId + ";" + amulet.Quality + ";" + amulet.Design);
                    }
                }
                else if (valuables[i] is Course cour)
                {
                    writer.WriteLine("KURSUS;" + cour.Name + ";" + cour.DurationInMinutes);
                }
            }
            writer.Close();
        }

        public void Load()
        {
            StreamReader reader = new StreamReader("ValuableRepository.txt");
            string line;
            Level lvl = Level.low;
            while((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(';');

                if (split[0] == "BOG")
                {
                    Book book = new Book(split[1].Substring(2), split[2], double.Parse(split[3]));
                    valuables.Add(book);
                }
                else if (split[0] == "AMULET")
                {
                    switch (split[2])
                    {
                        case "high":
                            lvl = Level.high;
                            break;

                        case "medium":
                            lvl = Level.medium;
                            break;

                        case "low":
                            lvl = Level.low;
                            break;
                    }
                    Amulet amulet = new Amulet(split[1].Substring(2), lvl, split[3]);
                    valuables.Add(amulet);
                }
                else if (split[0] == "KURSUS")
                {
                    Course cour = new Course(split[1], int.Parse(split[2]));
                    valuables.Add(cour);
                }
            }
            reader.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string line;
            Level lvl = Level.low;
            while((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(';');

                if (split[0] == "BOG")
                {
                    Book book = new Book(split[1].Substring(2), split[2], double.Parse(split[3]));
                    valuables.Add(book);
                }
                else if (split[0] == "AMULET")
                {
                    switch (split[2])
                    {
                        case "high":
                            lvl = Level.high;
                            break;

                        case "medium":
                            lvl = Level.medium;
                            break;

                        case "low":
                            lvl = Level.low;
                            break;
                    }
                    Amulet amulet = new Amulet(split[1].Substring(2), lvl, split[3]);
                    valuables.Add(amulet);
                }
                else if (split[0] == "KURSUS")
                {
                    Course cour = new Course(split[1], int.Parse(split[2]));
                    valuables.Add(cour);
                }
            }
            reader.Close();
        }
    }
}
