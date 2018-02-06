using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexmulti
{
    class complex_multi
    {

        public int a, b;
        public complex_multi(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
        public static complex_multi operator *(complex_multi c1, complex_multi c2)
        {
            int a_ = c1.a * c2.a;
            int b_ = c1.b * c2.b;
            complex_multi c = new complex_multi(a_, b_);
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