using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab2\minmax.txt");
            string[] line1 = line.Split(' ') ;
            int maxx = -123123132;
            int minn = 123123123;

            foreach(string s in line1)
            {
                maxx = Math.Max(maxx, int.Parse(s));
                minn = Math.Min(minn, int.Parse(s));
            }

            StreamWriter sw = new StreamWriter(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab2\result");
            sw.WriteLine("max is " + maxx);
            sw.WriteLine("min is " + minn);
            sw.Close();

            Console.ReadKey();


        }
    }
}
