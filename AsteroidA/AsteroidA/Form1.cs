using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidA
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Star> starlist = new List<Star>();
        List<Asteroid> asteroidlist = new List<Asteroid>();
        Star star;
        Asteroid asteroid;
        Spaceship spaceship;

        public Form1()
        {
            InitializeComponent();
            star = new Star();
            asteroid = new Asteroid();
            spaceship = new Spaceship(350, 250);
            Random t = new Random();

            for (int i = 0; i < 8; i++)
            {
                int x = t.Next(0, 650);
                int y = t.Next(0, 550);

                starlist.Add(new Star(x, y));
            }

            for (int i = 0; i < 4; i++)
            {
                int _x = t.Next(0, 650);
                int _y = t.Next(0, 550);

                asteroidlist.Add(new Asteroid(_x, _y));
            }
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < starlist.Count; i++)
                starlist[i].Move_Star(g);
            for (int i = 0; i < asteroidlist.Count; i++)
                asteroidlist[i].Move_Asterod(g);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 6), 0, 0, 650, 550);
            spaceship.Draw_Spaceship(g);

            for (int i = 0; i < starlist.Count; i++)
                starlist[i].Draw_Star(g);
            for (int i = 0; i < asteroidlist.Count; i++)
                asteroidlist[i].Draw_Asteroid(g);
            for (int i = 0; i < starlist.Count; i++)
            {
                if (starlist[i].Colision(starlist, star) == true)
                {
                    starlist[i].dx *= -1;
                    starlist[i].dy *= -1;
                    star.dx *= -1;
                    star.dy *= -1;

                    starlist[i].collided = false;
                }
            }
            for (int i = 0; i < asteroidlist.Count; i++)
            {
                if (asteroidlist[i].Colision(asteroidlist, asteroid) == true)
                {
                    asteroidlist[i].dx *= -1;
                    asteroidlist[i].dy *= -1;
                    asteroid.dx *= -1;
                    asteroid.dy *= -1;

                    asteroidlist[i].collided = false;
                }
            }
            g.FillRectangle(new SolidBrush(Color.White), 500, 20, 140, 30);
            g.DrawRectangle(new Pen(Color.Yellow, 3), 500, 20, 140, 30);
            g.DrawString("Level:1 Score:200 Live:***", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, 502, 30);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    spaceship.Move_Spaceship(g, 1);
                    break;
                case Keys.Down:
                    spaceship.Move_Spaceship(g, 2);
                    break;
                case Keys.Left:
                    spaceship.Move_Spaceship(g, 3);
                    break;
                case Keys.Right:
                    spaceship.Move_Spaceship(g, 4);
                    break;
            }
            Refresh();
        }
        
    }
}
