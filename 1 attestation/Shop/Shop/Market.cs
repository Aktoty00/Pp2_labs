using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Market
    {
        public List<Brands> brands = new List<Brands>();

        public Market()
        {
            brands.Add(new Brands("Gucci"));
            brands.Add(new Brands("Nike"));
            brands.Add(new Brands("Zara"));
        }

        public void ShowBrands(int pos)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i = 0;i < brands.Count;i ++)
            {
                if(i == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(brands[i].name);
            }
        }
        public void showProduct(int pos)
        {
            int curPos = 0;
            while (true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                Console.Clear();
                brands[pos].showAll(curPos);
                if (btn.Key == ConsoleKey.UpArrow)
                {
                    curPos--;
                    if (curPos == -1)
                    {
                        curPos = 9;
                    }
                }
                if (btn.Key == ConsoleKey.DownArrow)
                {
                    curPos++;
                    if (curPos == 10)
                        curPos = 0;
                }
                if(btn.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
