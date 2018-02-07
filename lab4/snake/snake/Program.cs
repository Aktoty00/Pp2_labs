using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 30);
            Random rnd = new Random();
            int n = rnd.Next(2, 75);
            int m = rnd.Next(2, 28);
            int level = 1;
            wall wall = new wall(level);
            snake snake = new snake();

            fruit eat = new fruit(n, m);

            while (true)
            {

                ConsoleKeyInfo keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (keyinfo.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (keyinfo.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (keyinfo.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                if (keyinfo.Key == ConsoleKey.R)
                {
                    level = 1;
                    snake = new snake();
                    wall = new wall(level);
                    n = rnd.Next(2, 78);
                    m = rnd.Next(2, 28);
                    eat = new fruit(n, m);
                    if (snake.CollisionWithFruit(eat))
                    {
                        snake.Adding();
                        n = rnd.Next(2, 78);
                        m = rnd.Next(2, 28);
                        eat = new fruit(n, m);
                    }
                    if (snake.CollisionWithWall(wall) || snake.Collision())
                    {
                        Console.Clear();
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine("GAME OVER!!!!");
                        Console.ReadKey();
                        snake = new snake();
                        level = 1;
                        n = rnd.Next(2, 78);
                        m = rnd.Next(2, 28);
                        wall = new wall(level);
                        eat = new fruit(n, m);
                    }
                    if (snake.UpLevel(level))
                    {
                        level++;
                        snake = new snake();
                        wall = new wall(level);
                        n = rnd.Next(2, 78);
                        m = rnd.Next(2, 18);
                        eat = new fruit(n, m);
                    }

                    Console.Clear();
                    fruit.Showfood(n, m);
                    snake.Draw();
                    wall.Draw();
                }
            }

            }
        }
}
