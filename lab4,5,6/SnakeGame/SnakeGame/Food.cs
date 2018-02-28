using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace SnakeGame
{
    [Serializable]
    class Food
    {
       
        public char foodsign;
        public Point loc; // loc kepps the coordinates of the food
        public ConsoleColor foodcolor;

        public Food()
        {
            foodcolor = ConsoleColor.Red;
            foodsign = '$'; // the sign of the snake
            SetRandomPos();
        }

        public void SetRandomPos()
        {
            int x = new Random().Next(2, 30); //random position 
            int y = new Random().Next(2, 15); //random position

            loc = new Point(x, y);  // food's loc take x and y
        }
         public void FoodDraw()
        {
            Console.ForegroundColor = foodcolor;
            Console.SetCursorPosition(loc.x, loc.y); // here we should put the food's sign 
            Console.Write(foodsign);
        }

        public bool OnTheWall(Wall w)
        {
            for (int i = 0; i < w.wallbody.Count; i++)
                if (loc.x == w.wallbody[i].x && loc.y == w.wallbody[i].y) // the condition when random food appeares on the wall
                    return false;
            return true;
        }

        public bool OnTheSnake(Snake s)
        {
            for (int i = 1; i < s.body.Count; i++)
                if (loc.x == s.body[i].x && loc.y == s.body[i].y) // the condition when random food appeares on the snake
                    return false;
            return true;
        }
    }
}
