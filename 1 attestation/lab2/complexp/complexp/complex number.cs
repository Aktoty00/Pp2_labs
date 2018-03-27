using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace complexp
{
    class complex_number
    {
            public int a, b;
            public complex_number (int _a, int _b)
            {
                a = _a;
                b = _b;
            }
            public override string ToString()
            {
                return a + "/" + b;
            }
            public static complex_number operator +(complex_number c1, complex_number c2)
            {
                int a_ = c1.a * c2.b + c2.a * c1.b;
                int b_ = c1.b* c2.b;
            complex_number c = new complex_number(a_, b_);
                c.Simplify();
                return c;
            }
            public static int gcd(int x, int y)
            {
                if(x < y)
            {
                int a = x;
                x = y;
                y = a;
            }
            int p = x % y; 
            if(p == 0)
            {
                return y;
            }
            else
            {
                return gcd(y, p); 
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