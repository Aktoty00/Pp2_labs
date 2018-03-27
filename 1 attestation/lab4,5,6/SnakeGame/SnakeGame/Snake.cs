using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace SnakeGame
{
    [Serializable]
    class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public int record, score;
        public Snake()
        {
            record = 0;
            sign = 'o';
            body = new List<Point>();
            body.Add(new Point(10, 10));
            color = ConsoleColor.Yellow;
        }

        public void Move(int dx, int dy)
        {
            int xlast = body[body.Count - 1].x; //we add ' ' to the endpoint of the snake
            int ylast = body[body.Count - 1].y; //we add ' ' to the endpoint of the snake

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x; //this point takes the coordinates of the previous point
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx; //head moves forward
            body[0].y += dy;

            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 1;
            if (body[0].x > Console.WindowWidth - 1)
                body[0].x = 1; //the condition when snake is leaving the playing area

            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 1;
            if (body[0].y > Console.WindowHeight - 1)
                body[0].y = 1; //the condition when snake is leaving the playing area
            Console.SetCursorPosition(xlast, ylast);
            Console.Write(' ');
        }

        public void Draw()
        {
            int index = 0;
            foreach (Point p in body)
            {
                if (index == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; //the color of the head
                }
                else
                    Console.ForegroundColor = color; //the color of the body
                Console.SetCursorPosition(p.x, p.y);
                Console.WriteLine(sign);
                index++;
            }
        }

        public bool Eaten(Food f)
        {
            if (body[0].x == f.loc.x && body[0].y == f.loc.y) // in this condition snake is eating a food
            {
                return true;
            }
            else
                return false;
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach (Point p in w.wallbody)
            {
                if (p.x == body[0].x && p.y == body[0].y) // when snake collide with wall,he dies
                    return true;
            }
            return false;
        }

        public bool CollisionSnake()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y) //// when snake with himself, he dies
                    return true;
            }
            return false;
        }
    }
}