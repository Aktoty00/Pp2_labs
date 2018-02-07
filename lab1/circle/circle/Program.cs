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
            radius = 2;
        }
        public circle(double radius)
        {
            this.radius = radius;
        }
        public override string ToString()
        {
            return "radius=" + radius;
        }
        public  double diameter()
        {
            return 2 * radius;
        }
        public  double area()
        {
            return Math.PI * radius * radius;
        }
        public  double perimeter( )
        {
            return 2 * Math.PI * radius;
        }

        class Program
        {
            static void Main(string[] args)
            {
                //circle one = new circle();
                double r = double.Parse(Console.ReadLine());
               
                circle one = new circle(r);

                Console.WriteLine(one);
                Console.WriteLine(one.diameter());
                Console.WriteLine(one.area());
                Console.WriteLine(one.perimeter());

                Console.ReadKey();
            }
        }
    }
} 
