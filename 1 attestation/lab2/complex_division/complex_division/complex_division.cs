using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complex_division
{
    class complex_division
    {
        public int a, b;
        public complex_division(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
        public static complex_division operator /(complex_division c1, complex_division c2)
        {
            int a_ = c1.a * c2.b;
            int b_ = c2.a * c1.b;
            complex_division c = new complex_division(a_, b_);
            c.Simplify();
            return c;
        }
        public static int gcd(int x, int y)
        {
            if (y == 0)
            {
                return x;
            }
            return gcd(y, x % y);
        }
        public void Simplify()
        {
            int z = gcd(a, b);
            a /= z;
            b /= z;
        }
    }
}
