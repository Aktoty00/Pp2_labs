using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    [Serializable]
    class fruit
    {
        Random rnd = new Random();

        public int x, y;
        public fruit() { }
        public bool b = false;
        public fruit(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool testwall(wall w)
        {
            foreach (point p in w.body)
            {
                if (p.x == x && p.y == y)
                {
                    return false;
                }

            }
            return true;
        }
       /* public bool testsnake(snake s)
        {
            foreach (point p in s.)
            {
                if (p.x == x && p.y == y)
                {
                    return false;
                }
            }
            return true;
        }*/

        public static void Showfood(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Q");
        }
    }
}
