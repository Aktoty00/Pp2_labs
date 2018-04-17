using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace AsteroidA
{
    class Spaceship
    {
        int x,  y,  dx,  dy;
        public Point[] points;
        public Point[] pointsOfGun;
        public Spaceship(int x, int y)
        {
            dx = 10;
            dy = 10;
            this.x = x;
            this.y = y;
            points = new Point[]
            {
            new Point(x, y),
            new Point(x + 24, y - 12),
            new Point(x + 48, y),
            new Point(x + 48, y + 24),
            new Point(x + 24, y + 36),
            new Point(x, y + 24),
            };
            pointsOfGun = new Point[]
            {
            new Point(x+23, y+1),
            new Point(x + 29, y + 11),
            new Point(x + 26, y + 11),
            new Point(x + 26, y + 23),
            new Point(x +20, y + 23),
            new Point(x +21, y + 11),
            new Point(x +17, y + 11),
        };
        }
        public void Draw_Spaceship(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.Yellow), points);
            g.FillPolygon(new SolidBrush(Color.Green), pointsOfGun);
        }
        public void Move_Spaceship(Graphics g, int k)
        {
            switch (k)
            {
                case 1:
                    y -= dy;
                    break;
                case 2:
                    y += dy;
                    break;
                case 3:
                    x -= dx;
                    break;
                case 4:
                    x += dx;
                    break;
            }

            points = new Point[]
            {
            new Point(x, y),
            new Point(x + 24, y - 12),
            new Point(x + 48, y),
            new Point(x + 48, y + 24),
            new Point(x + 24, y + 36),
            new Point(x, y + 24),
            };
            pointsOfGun = new Point[]
            {
            new Point(x+23, y+1),
            new Point(x + 29, y + 11),
            new Point(x + 26, y + 11),
            new Point(x + 26, y + 23),
            new Point(x +20, y + 23),
            new Point(x +21, y + 11),
            new Point(x +17, y + 11),
        };
            Draw_Spaceship(g);
        }
    }
}