using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SnakeGame
{
    class Program
    {
        static void F1(Snake snake)
        {
            FileStream v = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, snake);
            v.Close();
        }
        static Snake F2()
        {

            FileStream v = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Snake snake2 = bf.Deserialize(v) as Snake;
            v.Close();
            return snake2;
        }
        static void F3(Wall wall)
        {
            FileStream v = new FileStream("data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, wall);
            v.Close();

        }
        static Wall F4()
        {

            FileStream v = new FileStream("data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall wall = bf.Deserialize(v) as Wall;
            v.Close();
            return wall;
        }
        static void F5(int b)
        {
            StreamWriter a = new StreamWriter(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab4\SnakeGame\SnakeGame\record.txt");
            a.WriteLine(b);
            a.Close();
        }
        static int F6()
        {
            StreamReader a = new StreamReader(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab4\SnakeGame\SnakeGame\record.txt");
            string s = a.ReadLine();
            a.Close();
            return int.Parse(s);
        }
        static void F7(Food food)
        {
            FileStream v = new FileStream("date3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, food);
            v.Close();

        }
        static Food F8()
        {

            FileStream v = new FileStream("date3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Food food = bf.Deserialize(v) as Food;
            v.Close();
            return food;

        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(35, 35);
            

            int level = 1;
            int score = 1;
            int record1 = F6();
            Snake snake = new Snake();
            
           
            Console.Clear();
            Wall wall = new Wall(level);
            
           
            Food food = new Food();
            
         
            Console.WriteLine("If you want to start again press R");
            Console.WriteLine("If you want to continue press 2");
            ConsoleKeyInfo keyinfo1 = Console.ReadKey();
            ConsoleKeyInfo keyinfo2;


            if (keyinfo1.Key == ConsoleKey.NumPad2)
            {
                
                snake =  F2();
                wall =  F4();
                record1 =  F6();
                food  =  F8();
                score = snake.score;
            }
            Console.Clear();
            wall.WallDraw();
            snake.Draw();
            food.FoodDraw();
            while (true)
            {

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("High score : " + record1 + " Score: " + score + " Level:  " + level + " food is here: " + food.loc.x + " " + food.loc.y);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("If you want to safe,please type SpaceBar " + "      If you want to exit,please type Esc ");
               
                 keyinfo2= Console.ReadKey();
                if (keyinfo2.Key == ConsoleKey.DownArrow)
                    snake.Move(0, 1);
                if (keyinfo2.Key == ConsoleKey.UpArrow)
                    snake.Move(0, -1);
                if (keyinfo2.Key == ConsoleKey.LeftArrow)
                    snake.Move(-1, 0);
                if (keyinfo2.Key == ConsoleKey.RightArrow)
                    snake.Move(1, 0);
                if (keyinfo2.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    level = 1;
                    score = 0;
                    snake = new Snake();
                    wall = new Wall(level);
                }
                if (keyinfo2.Key == ConsoleKey.Spacebar)
                {
                    snake.score = score;
                    F1(snake);
                    F3(wall);
                    F5(record1);
                    F7(food);
               
                }
                if (keyinfo2.Key == ConsoleKey.Escape)
                {
                    return;
                }
                int k = 0;
                while (!food.OnTheWall(wall) || !food.OnTheSnake(snake))
                {  
                    food.SetRandomPos();
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);

                }
               
                if (snake.CollisionWithWall(wall) || snake.CollisionSnake())
                {
                    Console.Clear();
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine(" GAME OVER ! ! ! ");
                    Console.SetCursorPosition(10, 11);
                    Console.WriteLine("High score : " + record1 + " Your score is  " + score);

                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    score = 0;
                    wall = new Wall(level);
                    
                }

                if (snake.Eaten(food))
                {
                    score +=1;
                    record1 = Math.Max(record1, score); 

                    snake.body.Add(new Point(snake.body[snake.body.Count - 1].x, snake.body[snake.body.Count - 1].y));
                    food.SetRandomPos();
                   
                                    
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);
                  
                }
                
                if (score == level*5)
                {
                    Console.Clear();
                    level++;
                    int xx = 7;
                    wall = new Wall(level);
                    for (int i = 0; i < snake.body.Count; ++i)
                    {
                        snake.body[i].y = 18;
                        snake.body[i].x = xx;
                        xx++;
                            }

                }
                
                
                
                food.FoodDraw();
                wall.WallDraw();
                snake.Draw();


            }
        }
    }
}
