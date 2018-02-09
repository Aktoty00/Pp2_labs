using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1step
{
    class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public Snake()
        {
            sign = 'o';
            body = new List<Point>();
            body.Add(new Point(10, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(12, 10));

            color = ConsoleColor.DarkGreen;
        }

        public void Draw()
        {
            int i = 0;
            foreach (Point p in body)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = color;

                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                i++;
            }
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

        }

        public bool Eat(Food f)
        {
            if (body[0].x == f.loc.x && body[0].y == f.loc.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                return true;
            }
            else
                return false;
        }

        public bool Die1(Wall w)
        {
            for (int i = 0; i < w.body.Count; i++)
            {
                if (body[0].x == w.body[i].x && body[0].y == w.body[i].y)
                    return false;
            }
            return true;
        }

        public bool Die2()
        {
            for (int i = 1; i < body.Count; i++)
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return false;

            return true;
        }

    }
}