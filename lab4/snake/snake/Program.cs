using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1step
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(85, 35);
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall();


            while (true)
            {
                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();


                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                }

                if (snake.body[0].x < 0)
                    snake.body[0].x = 69;
                if (snake.body[0].x > 69)
                    snake.body[0].x = 0;
                if (snake.body[0].y < 0)
                    snake.body[0].y = 19;
                if (snake.body[0].y > 19)
                    snake.body[0].y = 0;

                if (snake.Eat(food))
                {
                    food.SetRandomPos();
                }

                if (snake.Die1(wall) == false)
                {
                    Console.SetCursorPosition(70, 33);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Game Over!!!");
                    Console.ReadKey();
                    return;
                }
                if (snake.Die2() == false)
                {
                    Console.SetCursorPosition(70, 35);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Game Over!!!");
                    Console.ReadKey();
                    return;
                }
            }

        }
    }
}