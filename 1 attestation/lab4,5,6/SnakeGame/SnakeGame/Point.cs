using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    [Serializable]
    class Point
    {
        public int x, y; //coordinates

        public Point(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
    }
}