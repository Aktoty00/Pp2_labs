using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mid1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            s = Console.ReadLine();
            int t = 2;
            int output ;
            int n;
            n = int.Parse(s);
            if (n == 0)
            {
                Console.WriteLine('1');
                Console.ReadKey();
            }
            if (n == 1)
            {
                Console.WriteLine('2');
                Console.ReadKey();
            }
            else
            {
                for(int i=2; i <= n; ++i)
                {
                    output = t * 2;
                    t = output;
                    
                }
                Console.WriteLine(t);
                Console.ReadKey();
            }
        }
    }
}
