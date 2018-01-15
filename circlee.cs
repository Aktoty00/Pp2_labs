using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class circle
    {
        public double radius;
        public circle()
        {
            radius = 55;
        }
        public circle(double radius)
        {
            this.radius = radius;
        }
        public override string ToString()
        {
            return "radius=" + radius;
        }
        public static double diameter(double radius)
        {
            return 2 * radius;
        }
        public static double area(double radius)
        {
            return Math.PI * radius * radius;
        }
        public static double perimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }

        class Program
        {
            static void Main(string[] args)
            {
                circle c = new circle();
                double r = double.Parse(Console.ReadLine());
                c.radius = r;
                Console.WriteLine(c);
                Console.WriteLine(circle.diameter(r));
                Console.WriteLine(circle.area(r));
                Console.WriteLine(circle.perimeter(r));

                Console.ReadKey();
            }
        }
    }
}