
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snake
{
    [Serializable]
    class wall
    {
        public List<point> body;
        public string sign;
        public ConsoleColor color;

        public void Readlevel(int level)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab4\snake\snake\level" + level + ".txt");
            int n = int.Parse(sr.ReadLine());
            for (int i=0; i<n; ++i)
            {
                string a = sr.ReadLine();
                for (int j = 0; j < a.Length; ++j)
                {
                    if (a[j] == '*')
                    {
                        body.Add(new point(j, i));
                    }
                }
            }
            sr.Close();
        }
         public wall (int level)
        {
            body = new List<point>();
            sign = "o";
            color = ConsoleColor.DarkRed;
            Readlevel(level);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
