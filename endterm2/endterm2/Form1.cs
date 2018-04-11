using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace endterm2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        int x, y, r;
        Color color;
        Color[] clr;
        bool clicked;
        public Form1()
        {
            InitializeComponent();
            r = 5;
            color = Color.Black;
            clicked = false;
            pen = new Pen(color, 2);
            g = CreateGraphics();
            timer1.Start();
            clr = new Color[] { Color.Red, Color.Black, Color.Blue, Color.Gray, Color.Green, Color.HotPink};
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
             x = e.X;
             y = e.Y;
            draw();
            g.Clear(Color.White);

           // g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
        }
        public void draw()
        {
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicked)
            {
                r = 5;
            }
            Random rnd = new Random();
            int q = rnd.Next(0, 6);
            color = clr[q];
            pen = new Pen(color, 2);
            r += 5;
            draw();clicked = false;
        }
    }
}
