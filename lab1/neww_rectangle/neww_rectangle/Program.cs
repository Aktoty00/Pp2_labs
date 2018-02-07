using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neww_rectangle
{
    class rectangle
    {
        public double w;
        public double h;

        public rectangle()
        {
            w = 15;
            h = 15;
        }

        public rectangle(double w, double h)
        {
            this.w = w;
            this.h = h;
        }
        public override string ToString()
        {
            return w + " " + h;
        }
        public double findArea()
        {
            return w * h;
        }
        public double findPerimeter()

        {
            return 2 * (w + h);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double wt = double.Parse(Console.ReadLine());

            double ht = double.Parse(Console.ReadLine());

            rectangle r = new rectangle(wt, ht);

            Console.WriteLine(r);
            Console.WriteLine(r.findArea());
            Console.WriteLine(r.findPerimeter());
            Console.ReadKey();
        }
    }
}
