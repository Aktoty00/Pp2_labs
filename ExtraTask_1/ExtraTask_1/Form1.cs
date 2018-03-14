using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraTask_1
{
    public partial class Form1 : Form
    {
        int score= 0;
        List<Button> buttonlist = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            Height = 600;
            Width = 600;
            timer1.Start();
            timer2.Start();
            button1.Location = new Point(260, 539);

        }
        private void NewButtons()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 595);
            Button btn = new Button();
            buttonlist.Add(btn);
            btn.Size = new Size(25, 25);
            btn.Location = new Point(x, 0);
            btn.Text = " ";
            btn.BackColor = Color.Coral;
            Controls.Add(btn);
         
        }
        int speed = 5;

        private void Moves()
        {
            foreach (Button b in buttonlist)
            {

                b.Location = new Point(b.Location.X, b.Location.Y + speed);
                if (b.Location.Y == 540)
                {
                    score++;
                }
                
                if (Math.Abs(b.Location.Y - button1.Location.Y) <= b.Height && Math.Abs(b.Location.X - button1.Location.X) <= b.Width)
                {
                    timer1.Stop();
                    timer2.Stop();

                    MessageBox.Show("Game Over!!!\n" + "Score is: " + score);
                    score = 0;
                    button1.Text = (score).ToString();                   
                }
              
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)//timer for creating buttons
        {
            NewButtons(); //creates new bottons
        }

        private void timer2_Tick(object sender, EventArgs e)// timer for button's movement
        {
            button1.Text = (score).ToString();
            Moves();
         
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)49: //if we Press number 1,the button moves to the left
                    button1.Location = new Point(button1.Location.X - 5, button1.Location.Y);
                    break;
                case (char)51: //if we Press number 3,the button moves to the right
                    button1.Location = new Point(button1.Location.X + 5, button1.Location.Y);
                    break;
            }
        }
    }
}
