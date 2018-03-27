using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex_minus
{
    class complex_minus
    {
        int a, b;
        public complex_minus() { }
        public complex_minus(int a_, int b_)
        {
            this.a = a_;
            this.b = b_;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
        public static complex_minus operator -(complex_minus c1, complex_minus c2)
        {
            int a1 = ((c1.a * c2.b) - (c2.a * c1.b));
            int b1 = c1.b*c2.b;
            complex_minus c = new complex_minus(a1, b1);
            c.Simplify();
            return c;
        }
        public static int gcd(int x, int y)
        {
            if (y == 0)
            {
                return x;
            }
            else
            {
                return gcd(y, x % y);
            }
        }
        public void Simplify()
        {
            int z = gcd(a, b);
            a /= z;
            b /= z;
        }
    }
}
