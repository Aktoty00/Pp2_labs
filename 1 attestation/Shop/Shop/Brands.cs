using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Brands
    {
        public string name;
        public List<string> goods = new List<string>();
        public static int[] cnt = new int[200100];
        public static int[] cost = new int[200100];

        public Brands(string name = "")
        {
            this.name = name;
            for(int i = 0;i < 10;i ++)
            {
                goods.Add(name + i.ToString());
                cnt[i] = 10;
                cost[i] = (i + 1) * 10;
            }
        }

        public void showAll(int pos = 0)
        {
            Console.Clear();
            for (int i = 0;i < 10;i++)
            {
                if (i == pos)
                    Console.BackgroundColor = ConsoleColor.White;
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(goods[i] + " " + cnt[i] + " " + cost[i]);
            }
        }
    }
}
