using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SnakeGame
{
    [Serializable]
    class Wall
    {
        public List<Point> wallbody;
        public string wallsign;
        public ConsoleColor wallcolor;

        public void Readlevel(int level)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab4\SnakeGame\SnakeGame\levels\level"+level+".txt");
            //reading walls from the text
            int n = int.Parse(sr.ReadLine()); // in the .txt file we write number of lines firstly
            for(int i=0; i<n; ++i)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < s.Length; ++j)
                    if (s[j] == 'o') //in the .txt file we determine the wall as a sign 'o'
                        wallbody.Add(new Point(j, i));
            }
            sr.Close();
        }
        
        public Wall(int level)
        {
            wallbody = new List<Point>();
            wallsign = "0"; //wall's sign
            wallcolor = ConsoleColor.Blue;
            Readlevel(level);
        }

        public void WallDraw()
        {
            Console.ForegroundColor = wallcolor;
            foreach (Point p in wallbody)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(wallsign);
            }
        
        }
    }
}
