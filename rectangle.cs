using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectanglee.cs
{
   class rectangle{
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
            return w + " "+ h;
        }
        public static double findArea(double width, double height)
        {
            return width * height;
        }
        public static double findPerimeter(double width, double height)
        {
            return 2*(width + height);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            rectangle r = new rectangle();
            double widthth = double.Parse(Console.ReadLine());
            r.w = widthth;
            double heightght = double.Parse(Console.ReadLine());
            r.h = heightght;

            Console.WriteLine(r);
            Console.WriteLine(rectangle.findArea(widthth,heightght));
            Console.WriteLine(rectangle.findPerimeter(widthth, heightght));
            Console.ReadKey();


        }
    }
}
