using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1step
{
    class Food
    {
        public char sign;
        public Point loc;
        public ConsoleColor color;

        public Food()
        {
            sign = '@';
            color = ConsoleColor.Red;
            SetRandomPos();
        }

        public void SetRandomPos()
        {
            int x = new Random().Next(0, 70);
            int y = new Random().Next(0, 20);

            loc = new Point(x, y);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(loc.x, loc.y);
            Console.Write(sign);
        }


    }
}