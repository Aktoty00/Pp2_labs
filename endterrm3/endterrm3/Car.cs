using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace endterrm3
{
    class Car
    {
        public GraphicsPath gp;
        public int direction = 1;
        public int x, y;
        public Car(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
       
        public void Draw(Graphics g)
        {
            gp = new GraphicsPath();
            int w = 60;
            int h = 10;
            gp.AddRectangle(new Rectangle(x, y, w, h));

            Point[] p = { new Point (x +5 , y),  new Point(x+w - 5, y), new Point(x +w-9, y-10),new Point(x + 9, y - 10) };
            gp.AddPolygon(p);
            gp.AddEllipse(new Rectangle( x + 8,y+h-2, 5, 5));
            gp.AddEllipse(new Rectangle(x +w-8,y + h - 2 ,5, 5));

            //direction = 1 ----right

            g.DrawPath(new Pen(Color.Red, 2), gp);
        }
    
    }
}
