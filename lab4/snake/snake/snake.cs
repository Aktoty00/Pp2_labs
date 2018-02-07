using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    [Serializable]
    class snake
    {
        List<point> body;
        string sign;
        ConsoleColor color;
        public int cnt;

        public snake()
        {
            body = new List<point>();
            body.Add(new point(12, 12)); 
            sign = "*";
            color = ConsoleColor.Yellow;
            cnt = 0;
        }

        public void Move(int dx, int dy)
        {
            cnt++;
            
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 1;
            if (body[0].x > Console.WindowWidth - 1)
                body[0].x = 1;
            if (body[0].y < 1)
                body[0].x = Console.WindowHeight - 1;
            if (body[0].y > Console.WindowHeight - 1)
                body[0].y = 1;
        }

        public void Adding()
        {
            body.Add(new point(0, 0));
        }
    

        public void Draw()
        {
            int index = 0;
            foreach( point p in body)
            {
                if (index == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                index++;
            }
        }
         public bool CollisionWithWall (wall w)
        {
            foreach(point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }

        public bool Collision()
        {
            for(int i=1; i < body.Count; ++i)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }

        public bool CollisionWithFruit(fruit f)
        {
            if (body[0].x == f.x && body[0].y == f.y)
                return true;
            else
                return false;
        }
        public bool UpLevel(int level)
        {
            if (body.Count >= level * 5)
            {
                return true;
            }
            return false;
        }

    }
    }
