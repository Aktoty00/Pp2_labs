using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string c = s.Split(' ')[0];
            string d = s.Split(' ')[1];
            int a_ = int.Parse(c.Split('/')[0]);
            int b_ = int.Parse(c.Split('/')[1]);
            int c_ = int.Parse(d.Split('/')[0]);
            int d_ = int.Parse(d.Split('/')[1]);
            complex_number a = new complex_number(a_, b_);
            complex_number b = new complex_number(c_, d_);
            complex_number res = a + b;
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
