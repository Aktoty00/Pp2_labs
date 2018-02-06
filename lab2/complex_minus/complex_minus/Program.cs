using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace complex_minus
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            string q = s.Split(' ')[0];
            string w = s.Split(' ')[1];
            int a_ = int.Parse(q.Split('/')[0]);
            int b_ = int.Parse(q.Split('/')[1]);
            int c_ = int.Parse(w.Split('/')[0]);
            int d_ = int.Parse(w.Split('/')[1]);
            complex_minus a = new complex_minus(a_, b_);
            complex_minus b = new complex_minus(c_, d_);
            complex_minus res = a - b;
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
