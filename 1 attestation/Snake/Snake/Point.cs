using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Snake
{
    [Serializable]
    class Point
    {
        public int x, y;
        public Point(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
    }
}
