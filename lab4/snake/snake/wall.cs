using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1step
{
    class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public Wall()
        {
            sign = '#';
            color = ConsoleColor.DarkYellow;

            body = new List<Point>();
            Level(2);
        }


        public void Level(int a)
        {
            string path = string.Format(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab4\snake\snake\level"+a+".txt");
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            int i = 0;
            int row = 0;
            while (i < 20)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '#')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;

            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }

        }

    }
}