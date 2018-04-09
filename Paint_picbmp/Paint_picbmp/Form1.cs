using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_picbmp
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics bmp_g;
        bool clicked, pboxleft_clicked, pboxright_clicked ;
        Pen pen;
        public enum Tool
        {
            PEN, RECTANGLE, CIRCLE, ERASE, TRIANGLE, FILL
        };
        Tool tool;
        int a;
        Point prev, cur;
        SolidBrush solidbrush;
        Color color1, color2, clr = Color.Black;
        Queue <Point> q;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap (pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            bmp_g = Graphics.FromImage(bmp);
            clicked = false;
            pboxleft_clicked = true;
            pboxright_clicked = false;
            pen = new Pen(Color.Black);
            q = new Queue<Point>(); 
            solidbrush = new SolidBrush(Color.White);
            a = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
            if (tool == Tool.FILL)
            {
                q.Enqueue(e.Location);
                color1 = bmp.GetPixel(e.X, e.Y);
                if(e.Button == MouseButtons.Left)
                    color2 = pBoxleft.BackColor;
                if (e.Button == MouseButtons.Right)
                    color2 = pBoxright.BackColor;
                while (q.Count > 0)
                {
                    int x = q.First().X;
                    int y = q.First().Y;
                    Fill(x, y + 1);
                    Fill(x, y - 1);
                    Fill(x - 1, y);
                    Fill(x + 1, y);
                    q.Dequeue();

                }
            }
            pictureBox1.Image = bmp;
        }

        void Fill(int x, int y)
        {
            if (x >= bmp.Width)
                return;
            if (x < 0)
                return;
            if (y >= bmp.Height)
                return;
            if (y < 0)
                return;
            if (bmp.GetPixel(x, y) != color1)
                return;
            bmp.SetPixel(x, y, color2);
            q.Enqueue(new Point(x, y));
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "penn")
                tool = Tool.PEN;
            if (btn.Name == "rectanglee")
                tool = Tool.RECTANGLE;
            if (btn.Name == "circlee")
                tool = Tool.CIRCLE;
            if (btn.Name == "erasee")
                tool = Tool.ERASE;
            if (btn.Name == "filll")
                tool = Tool.FILL;
            if (btn.Name == "trianglee")
                tool = Tool.TRIANGLE;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Math.Min(prev.X, e.X);
            int y = Math.Min(prev.Y, e.Y);
            int w = Math.Abs(prev.X - e.X);
            int h = Math.Abs(prev.Y - e.Y);
            if(tool == Tool.RECTANGLE)
            {
                if (e.Button == MouseButtons.Left)
                    bmp_g.DrawRectangle(new Pen(pBoxleft.BackColor, a), x, y, w, h);
                if (e.Button == MouseButtons.Right)
                    bmp_g.DrawRectangle(new Pen(pBoxright.BackColor, a), x, y, w, h);
                pictureBox1.Refresh();
            }
            if (tool == Tool.CIRCLE)
            {
                if(e.Button == MouseButtons.Left)
                    bmp_g.DrawEllipse(new Pen(pBoxleft.BackColor, a), x, y, w, h);
                if ((e.Button == MouseButtons.Right))
                    bmp_g.DrawEllipse(new Pen(pBoxright.BackColor, a), x, y, w, h);
                pictureBox1.Refresh();
            }
            if(tool == Tool.TRIANGLE)
            {
                Point[] poly = { new Point(w/2 + x, y), new Point(x, Math.Max(prev.Y, cur.Y)), new Point(Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y)) };
                if (e.Button == MouseButtons.Left)
                {
                    bmp_g.DrawPolygon(new Pen(pBoxleft.BackColor, a), poly);
                }
                if (e.Button == MouseButtons.Right)
                {
                    bmp_g.DrawPolygon(new Pen(pBoxright.BackColor, a), poly);
                }
                pictureBox1.Refresh();
            }
            clicked = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = Math.Min(prev.X, cur.X);
            int y = Math.Min(prev.Y, cur.Y);
            int w = Math.Abs(prev.X - cur.X);
            int h = Math.Abs(prev.Y - cur.Y);
            if (tool == Tool.RECTANGLE)
            {
                if( MouseButtons == MouseButtons.Left )
                    e.Graphics.DrawRectangle(new Pen(pBoxleft.BackColor, a), x, y, w, h);
                if (MouseButtons == MouseButtons.Right)
                    e.Graphics.DrawRectangle(new Pen(pBoxright.BackColor, a), x, y, w, h);
            }
            if (tool == Tool.CIRCLE)
            {
                if (MouseButtons == MouseButtons.Left)
                    e.Graphics.DrawEllipse(new Pen(pBoxleft.BackColor, a), x, y, w, h);
                if (MouseButtons == MouseButtons.Right)
                    e.Graphics.DrawEllipse(new Pen(pBoxright.BackColor, a), x, y, w, h);
            }
            if (tool == Tool.TRIANGLE)
            {
                Point[] poly = { new Point(w / 2 + x, y), new Point(x, Math.Max(prev.Y, cur.Y)), new Point(Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y)) };
                if (MouseButtons == MouseButtons.Left)
                {
                    e.Graphics.DrawPolygon(new Pen(pBoxleft.BackColor, a), poly);
                }
                if (MouseButtons == MouseButtons.Right)
                {
                    e.Graphics.DrawPolygon(new Pen(pBoxright.BackColor, a), poly);
                }
            }
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = trackBar1.Value;
        }
        
        private void save_button_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

        private void open_button_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                bmp_g = Graphics.FromImage(bmp);
            }
        }

        private void Color_CLick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pboxleft_clicked)
                {
                    pBoxleft.BackColor = colorDialog1.Color;
                    pen = new Pen(pBoxleft.BackColor, trackBar1.Value);
                }
                if (pboxright_clicked)
                {
                    pBoxright.BackColor = colorDialog1.Color;
                    pen = new Pen(pBoxright.BackColor, trackBar1.Value);
                }
           }
        }

        private void Penal_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pboxleft_clicked)
            {
                pBoxleft.BackColor = pb.BackColor;
            }
            if (pboxright_clicked)
            {
                pBoxright.BackColor = pb.BackColor;
            }
        }

        private void pboxright_Click(object sender, EventArgs e)
        {
            pboxright_clicked = true;
            pboxleft_clicked = false;
        }

        private void pBoxleft_Click(object sender, EventArgs e)
        {
            pboxleft_clicked = true;
            pboxright_clicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            if (clicked)
            {
                if (tool == Tool.PEN)
                {
                    if(e.Button == MouseButtons.Left)
                    bmp_g.DrawLine(new Pen(pBoxleft.BackColor, a), prev.X, prev.Y, cur.X, cur.Y);
                    if(e.Button == MouseButtons.Right)
                    bmp_g.DrawLine(new Pen(pBoxright.BackColor, a), prev.X, prev.Y, cur.X, cur.Y);
                    prev = cur;
                }
                if (tool == Tool.ERASE)
                {
                    bmp_g.DrawLine(new Pen(Color.White ,a), prev.X, prev.Y, cur.X, cur.Y);
                    prev = cur;
                }
                    pictureBox1.Refresh();
            }
        }
    }
}