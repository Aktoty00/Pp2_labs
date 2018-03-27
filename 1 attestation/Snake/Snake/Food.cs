using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Snake
{
    [Serializable]
    class Food
    {
        public ConsoleColor foodcolor;
        public Point loc;
        public char foodsign;

        public Food()
        {
            foodsign = '$';
            foodcolor = ConsoleColor.Red;
            SetRandomPos();
        }
        public void SetRandomPos()
        {
            int x = new Random().Next(2, 30);
            int y = new Random().Next(2, 30);
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
            for(int i = 0; i < w.wallbody.Count; ++i)
            {
                if (loc.x == w.wallbody[i].x && loc.y == w.wallbody[i].y)
                    return false;
                   
            }
            return true;
        }
        public bool OnTheSnake(Snake s)
        {
            for (int i = 1; i < s.body.Count; ++i)
            {
                if (loc.x == s.body[i].x && loc.y == s.body[i].y)
                    return false;
                
            }
            return true;

        }
    }
}
