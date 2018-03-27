using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void F1(Snake snake)
        {
            //Serialization of the snake
            FileStream v = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, snake);
            v.Close();
        }
        static Snake F2()
        {
            //Deserialization of the snake
            FileStream v = new FileStream("data1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Snake snake2 = bf.Deserialize(v) as Snake;
            v.Close();
            return snake2;
        }
        static void F3(Wall wall)
        {
            //Serialization of the wall
            FileStream v = new FileStream("data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, wall);
            v.Close();

        }
        static Wall F4()
        {
            //Deserialization of the wall
            FileStream v = new FileStream("data2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Wall wall = bf.Deserialize(v) as Wall;
            v.Close();
            return wall;
        }
        static void F5(int b)
        {
            // writing the record to record.txt
            StreamWriter sw = new StreamWriter(@"C:\levels\record.txt");
            sw.WriteLine(b);
            sw.Close();
        }
        static int F6()
        {
            // reading the record from record.txt
            StreamReader a = new StreamReader(@"C:\levels\record.txt");
            string s = a.ReadLine();
            a.Close();
            return int.Parse(s);
        }
        static void F7(Food food)
        {
            //Serialization of the food
            FileStream v = new FileStream("date3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(v, food);
            v.Close();

        }
        static Food F8()
        {
            //Deserialization of the food
            FileStream v = new FileStream("date3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Food food = bf.Deserialize(v) as Food;
            v.Close();
            return food;
        }

        static Snake snake;
        static Food food;
        static int level;
        static Wall wall;
        static int score;
        static int direction; //right is 1, left is 2, down is 3, up is 4
        static bool gameover;
        static int speed;
        static int record1;


        static void Game()
        {
            while (!gameover)
            {


                if (score == level * 5)
                {
                    //to go to the next level, the score must be equal to the 5*level
                    Console.Clear();
                    level++;
                    // next level

                    int xx = 7; // we use it to move snake to safe place when it changes levels
                    wall = new Wall(level);

                    speed = Math.Max(1, speed - 50);
                    for (int i = 0; i < snake.body.Count; ++i)
                    {
                        snake.body[i].y = 24; // y of safe place
                        snake.body[i].x = xx; // x of safe place
                        xx++;

                    }

                }

                if (direction == 1)
                {
                    snake.Move(1, 0);
                }
                if (direction == 2)
                {
                    snake.Move(-1, 0);
                }
                if (direction == 3)
                {
                    snake.Move(0, 1);
                }
                if (direction == 4)
                {
                    snake.Move(0, -1);
                }
                Console.SetCursorPosition(1, 28);
                Console.WriteLine("High score : " + record1 + "          Score: " + score + "          Level:  " + level);
                Console.SetCursorPosition(1, 27);
                Console.WriteLine("If you want to safe, please press SpaceBar    " + "        If you want to exit, please press Esc ");

                while (!food.OnTheWall(wall) || !food.OnTheSnake(snake))
                {
                    //if food appears on the wall or snake, we call the SetRandomPos function again to create new food
                    food.SetRandomPos();
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);
                }
                if (snake.CollisionWithWall(wall) || snake.CollisionSnake())
                {
                    //if snake collides to the wall or himself, we do write "Game Over" and score, high score
                    Console.Clear();
                    Console.SetCursorPosition(24, 14);
                    Console.WriteLine(" GAME OVER ! ! ! ");
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("High score : " + record1 + " Your score is  " + score);

                    Console.ReadKey();
                    //after pressing some key, we start the game from the beginning
                    Console.Clear();
                    snake = new Snake();
                    level = 1;
                    score = 0;
                    speed = 350;
                    wall = new Wall(level);
                }

                if (snake.Eaten(food))
                {
                    //if snake eats food, the score will be increased
                    score += 1;
                    //record is the max value of the score and saved record
                    record1 = Math.Max(record1, score);
                    //if snake eats food, we add one additional point to the of the snake
                    snake.body.Add(new Point(snake.body[snake.body.Count - 1].x, snake.body[snake.body.Count - 1].y));
                    //we call SetRandomPos to create new food after eatting the previous
                    food.SetRandomPos();
                    Console.SetCursorPosition(food.loc.x, food.loc.y);
                    Console.Write(food.foodsign);
                }

                snake.Draw();
                food.FoodDraw();
                wall.WallDraw();
                Thread.Sleep(speed);
            }
        }


        static void Main(string[] args)
        {
            snake = new Snake();
            food = new Food();
            level = 1;
            wall = new Wall(1);
            score = 0;
            direction = 1; //right is 1, left is 2, down is 3, up is 4
            gameover = false;
            speed = 350;
            record1 = F6();


            Thread thread = new Thread(Game);
            Console.CursorVisible = false; //to hide the cursor
            Console.SetWindowSize(44, 44);

            Console.WriteLine("If you want to start again press R");
            Console.WriteLine("If you want to continue press C");

            ConsoleKeyInfo keyinfo1 = Console.ReadKey();
            ConsoleKeyInfo keyinfo2;


            if (keyinfo1.Key == ConsoleKey.C)
            {

                //to continue the game , we call the Deserialized sanke, wall, food, and record
                snake = F2();
                wall = F4();
                record1 = F6();
                food = F8();
                score = snake.score;

            }
            Console.Clear();

            thread.Start();

            while (!gameover)
            {
                keyinfo2 = Console.ReadKey();
                if (keyinfo2.Key == ConsoleKey.DownArrow && direction != 4)
                    direction = 3;
                if (keyinfo2.Key == ConsoleKey.UpArrow && direction != 3)
                    direction = 4;
                if (keyinfo2.Key == ConsoleKey.LeftArrow && direction != 1)
                    direction = 2;
                if (keyinfo2.Key == ConsoleKey.RightArrow && direction != 2)
                    direction = 1;
                if (keyinfo2.Key == ConsoleKey.R)
                {

                    //we use 'R' to restart the game
                    Console.Clear();
                    //we return the initial values of the level, score. 
                    level = 1;
                    score = 0;
                    speed = 350;
                    //then we create a new snake and wall depending on the level
                    snake = new Snake();
                    wall = new Wall(level);

                }
                if (keyinfo2.Key == ConsoleKey.Spacebar)
                {
                    //we use 'R' to save the game
                    snake.score = score; // saving the score
                    //serialize the snake, food, wall and record to keep information of the saved game
                    F1(snake);
                    F3(wall);
                    F5(record1);
                    F7(food);

                }
                if (keyinfo2.Key == ConsoleKey.Escape)
                {
                    gameover = true;
                }

            }
           
        }
    }
}