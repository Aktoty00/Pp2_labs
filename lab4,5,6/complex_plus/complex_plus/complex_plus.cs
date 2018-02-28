using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace complex_plus
{ [Serializable]
    public class complex_plus
    {
        public int a, b;
        public complex_plus() { }
        public complex_plus(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
        public static complex_plus operator +(complex_plus c1, complex_plus c2)
        {
            int lcm = (c1.b * c2.b) / gcd(c1.b, c2.b);
            int t1 = lcm / c1.b;
            int t2 = lcm / c2.b;
            int a_ = c1.a * t1 + c2.a * t2;
            int b_ = lcm;
            complex_plus c = new complex_plus(a_, b_);
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
