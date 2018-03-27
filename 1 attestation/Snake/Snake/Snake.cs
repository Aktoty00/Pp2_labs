using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Snake
{
    [Serializable]
    class Snake
    {
        public List<Point> body;
        public ConsoleColor color;
        public char sign;
        public int record, score;

        public Snake()
        {
            record = 0;
            sign = 'o';
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Cyan;
        }

        public void Move(int dx, int dy)
        {
            for(int i= body.Count-1; i >= 1; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            if(body[0].x < 1)
            {
                body[0].x = Console.WindowWidth - 1;
            }
            if (body[0].x > Console.WindowWidth - 1)
            {
                body[0].x = 1;
            }
            if (body[0].y < 1)
            {
                body[0].y = Console.WindowHeight - 1;
            }
            if (body[0].y > Console.WindowHeight - 1)
            {
                body[0].y = 1;
            }
            int xlast = body[body.Count - 1].x;
            int ylast = body[body.Count - 1].y;

            Console.SetCursorPosition(xlast, ylast);
            Console.Write(' ');
        }

        public void SnakeDraw()
        {
            int index = 0;
            foreach(Point p in body)
            {
                if (index == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sign);
                index++;
            }
        }
        public bool Eaten(Food f)
        {
            if (body[0].x == f.loc.x && body[0].y == f.loc.y)
                return true;
            else
                return false;
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach(Point p in w.wallbody)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;

        }

        public bool CollisionSnake()
        {
            for(int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
             return false;

        }
    }
}
