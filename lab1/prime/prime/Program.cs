using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string line;
            line = Console.ReadLine(); // we read numbers
           
            args = line.Split(' ');*/
            foreach (string s in args)
            {
                int a = int.Parse(s);
                int n = 0;//counter of deviders
                for (int i = 1; i <= a; ++i)//int.Parse-> converting from string to int
                {
                    
                    if (a % i == 0)
                    {
                        n++; //a number of deviders
                    }
                }
                if (n == 2) //if there are only 1 and the number
                    Console.WriteLine(int.Parse(s));

            }
            

            Console.ReadKey();
        }
    }
}
