using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(35, 35);

            int level = 1;
            int score = 0;
            Snake snake = new Snake();
            Wall wall = new Wall(level);
            Food food = new Food();
            while (true)
            {

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Score: " + score + " " + "Level:  " + level);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                if (keyInfo.Key == ConsoleKey.R)
                {
                    level = 1;
                    score = 0;
                    snake = new Snake();
                    wall = new Wall(level);
                }
               
                if (!food.OnTheWall(wall)  || !food.OnTheSnake(snake) ) 
                {                                                                        
                    food.SetRandomPos();
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);
                }
                if (snake.CollisionWithWall(wall) || snake.CollisionSnake())
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("GAME OVER!!!!");
                    Console.ReadKey();
                    snake = new Snake();
                    wall = new Wall(level);
                    level = 1;
                    score = 0;
                }

                if (snake.Eaten(food))
                {
                    snake.body.Add(new Point(snake.body[snake.body.Count - 1].x, snake.body[snake.body.Count - 1].y));
                    food.SetRandomPos();
                    score += 1;
                    
                  
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);
                   

                }
                
                if (score == level*5)
                {
                    level++;
                    wall = new Wall(level);
                }
                Console.Clear();
                snake.Draw();
                food.FoodDraw();
                wall.WallDraw();
            }
        }
    }
}
