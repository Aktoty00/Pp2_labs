using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food
    {
       
        public char foodsign;
        public Point loc;
        public ConsoleColor foodcolor;

        public Food()
        {
            foodcolor = ConsoleColor.Red;
            foodsign = '@';
            SetRandomPos();
        }

        public void SetRandomPos()
        {
            int x = new Random().Next(1, 30);
            int y = new Random().Next(1, 15);

            loc = new Point(x, y);  
        }
         public void FoodDraw()
        {
            Console.ForegroundColor = foodcolor;
            Console.SetCursorPosition(loc.x, loc.y);
            Console.Write(foodsign);
        }

        public bool OnTheWall(Wall w)
        {
            for (int i = 1; i < w.wallbody.Count; i++)
                if (loc.x == w.wallbody[i].x && loc.y == w.wallbody[i].y)
                    return false;
            return true;
        }

        public bool OnTheSnake(Snake s)
        {
            for (int i = 1; i < s.body.Count; i++)
                if (loc.x == s.body[i].x && loc.y == s.body[i].y)
                    return false;
            return true;
        }
    }
}
