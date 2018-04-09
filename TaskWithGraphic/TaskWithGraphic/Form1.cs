using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskWithGraphic
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Pen pen;
        float x1 = 0, y1 = 0, y2 = 0;
        float q = 200, w = 40;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black);
            g.DrawLine(pen, 0, pictureBox1.Height/2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2,pictureBox1.Height);
        }

        private void sin_Click(object sender, EventArgs e)
        {
            Drawcoord();
            
            for(float i = 0; i< 20; i += 0.1F)
            {
                y2 = (float)Math.Sin(i);

                g.DrawLine(pen, x1 * w, y1 * w + q, x1 * w, y2 * w + q);
                x1 = i;
                y1 = y2;
            }
        }

        public void Drawcoord()
        {
            for(int i=pictureBox1.Width/2; i<=pictureBox1.Width; i+=30)
            {
                g.DrawLine(pen,i,pictureBox1.Height/2 - 3, i, pictureBox1.Height/2 + 3);
                pictureBox1.Refresh();
            }
            for (int i = pictureBox1.Width / 2; i >= 0; i -= 30)
            {
                g.DrawLine(pen, i, pictureBox1.Height / 2 - 3, i, pictureBox1.Height / 2 + 3);
                pictureBox1.Refresh();
            }
            for (int i = pictureBox1.Height / 2; i <= pictureBox1.Height; i += 30)
            {
                g.DrawLine(pen, pictureBox1.Width / 2 - 3, i, pictureBox1.Width / 2 + 3, i);
                pictureBox1.Refresh();
            }
            for (int i = pictureBox1.Height / 2; i >= 0; i -= 30)
            {
                g.DrawLine(pen, pictureBox1.Width / 2 - 3, i, pictureBox1.Width / 2 + 3, i);
                pictureBox1.Refresh();
            }
        }
    }
}
