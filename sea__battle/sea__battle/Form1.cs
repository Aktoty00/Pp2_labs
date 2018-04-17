using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sea__battle
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 2);
        bool boat_clicked;
        bool start_clicked;
        Bitmap bmp1, bmp2;
        Graphics g1, g2;
        Point current, picbox2;
        bool horizontal, vertical;
        public enum Tool
        {
            biggest, big, midle ,small
        };
        public enum State
        {
            Start, Finish, Missed
        };
        Tool tool;
        State state;
        public Form1()
        {
            InitializeComponent();
            bmp1 = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            g1 = Graphics.FromImage(bmp1);
            pictureBox1.Image = bmp1;
            bmp2 = new Bitmap(pictureBox2.Size.Width, pictureBox2.Size.Height);
            g2 = Graphics.FromImage(bmp2);
            pictureBox2.Image = bmp2;
            Draw();
            tool = Tool.biggest;
            horizontal = true;
            vertical = false;
            start_clicked = false;
        }
        public void Draw()
        {
            for (int i = 0; i < 11; i++)
                g1.DrawLine(pen, 35 * i, 0, 35 * i, 350);
            for (int i = 0; i < 11; i++)
                g1.DrawLine(pen, 0, 35 * i, 350, 35 * i);
            for (int i = 0; i < 11; i++)
                g2.DrawLine(pen, 35 * i, 0, 35 * i, 350);
            for (int i = 0; i < 11; i++)
                g2.DrawLine(pen, 0, 35 * i, 350, 35 * i);
        }
        private void Boat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Text == "Biggest(4)")
                tool = Tool.biggest;
            if (btn.Text == "Big(3)")
                tool = Tool.big;
            if (btn.Text == "Midle(2)")
                tool = Tool.midle;
            if (btn.Text == "Small(1)")
                tool = Tool.small;
        }
        private void horizontal_Click(object sender, EventArgs e)
        {
            horizontal = true;
            vertical = false;
            label1.Text = "Horizontal";
        }

        private void vertical_Click(object sender, EventArgs e)
        {
            horizontal = false;
            vertical = true;
            label1.Text = "Vertical";
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            boat_clicked = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            picbox2 = e.Location;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            int x, y;
            x = picbox2.X / 35 *35;
            y = picbox2.Y / 35 * 35;
            if (start_clicked)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), x, y, x + 35, y + 35);
                e.Graphics.DrawLine(new Pen(Color.Red, 2), x, y + 35, x + 35, y);
                pictureBox2.Refresh();
            }
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            start_clicked = true;
            state = State.Start;
            biggest_button.Enabled = false;
            big_button.Enabled = false;
            midle_button.Enabled = false;
            small_button.Enabled = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            int x, y;
            x = picbox2.X / 35 * 35;
            y = picbox2.Y / 35 *35;
            if (start_clicked)
            {
                g2.DrawLine(new Pen(Color.Red, 2), x, y, x + 35, y + 35);
                g2.DrawLine(new Pen(Color.Red, 2), x, y + 35, x + 35, y);
                pictureBox2.Refresh();
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            current = e.Location;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x, y;
            x = current.X / 35;
            x *= 35;
            y = current.Y / 35;
            y *= 35;
            if (boat_clicked && horizontal)
            {
                if (tool == Tool.biggest)
                {
                    if (current.X > 210)
                        x = 210;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 140, 35);
                }
                if (tool == Tool.big)
                {
                    if (current.X > 245)
                        x = 245;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 105, 35);
                }
                if (tool == Tool.midle)
                {
                    if (current.X > 280)
                        x = 280;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 70, 35);
                }
                if (tool == Tool.small)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 35);
                }
            }
            if (boat_clicked && vertical)
            {
                if (tool == Tool.biggest)
                {
                    if (current.Y > 210)
                        y = 210;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 140);
                }
                if (tool == Tool.big)
                {
                    if (current.Y > 245)
                        y = 245;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 105);
                }
                if (tool == Tool.midle)
                {
                    if (current.Y > 280)
                        y = 280;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 70);
                }
                if (tool == Tool.small)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 35);
                }
            }
            pictureBox1.Refresh();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int x, y;
            x = current.X / 35;
            x *= 35;
            y = current.Y / 35;
            y *= 35;
            if (boat_clicked && horizontal)
            {
                if (tool == Tool.biggest)
                {
                    if (current.X > 210)//6*35
                        x = 210;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 140, 35);
                }
                if (tool == Tool.big)
                {
                    if (current.X > 245)//7*35
                        x = 245;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 105, 35);
                }
                if (tool == Tool.midle)
                {
                    if (current.X > 280)//8*35
                        x = 280;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 70, 35);
                }
                if (tool == Tool.small)
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 35);
            }
            if (boat_clicked && vertical)
            {
                if (tool == Tool.biggest)
                {
                    if (current.Y > 210)//6*35
                        y = 210;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 140);
                }
                if (tool == Tool.big)
                {
                    if (current.Y > 245)//7*35
                        y = 245;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 105);
                }
                if (tool == Tool.midle)
                {
                    if (current.Y > 280)//8*35
                        y = 280;
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 70);
                }
                if (tool == Tool.small)
                    g1.FillRectangle(new SolidBrush(Color.Black), x, y, 35, 35);
            }
            boat_clicked = false;
        }
    }
}
