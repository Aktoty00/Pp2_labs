using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        double value= 0;  //first number
        double second=0;  //second number
        string operation = "";
        double memory = 0;
        bool resultispressed = false;
        public Form1()
        {
            InitializeComponent();
        }
               
        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0")) 
            {
                textBox1.Text = "";
            }
           
            Button btn = sender as Button;
            if (btn.Text == ".")
            {
                if (! textBox1.Text.Contains("."))
                    textBox1.Text += btn.Text;
            }
            else
            textBox1.Text += btn.Text;
          
        }
        
        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label2.Text = "";
            value = 0;
            second = 0;
            operation = "";
            resultispressed = false;
        }
        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        private void oneoverx_Click(object sender, EventArgs e)
        {
            double overx = Convert.ToDouble(textBox1.Text);
            label2.Text = "1/(" + textBox1.Text + ")";
            textBox1.Text = (1 / overx).ToString() ;
        }

        private void poweroftwo_Click(object sender, EventArgs e)
        {
            double powerx = Convert.ToDouble(textBox1.Text);
            label2.Text = "sqr("+ textBox1.Text + ")";
            textBox1.Text = (powerx * powerx).ToString();
        }

        private void Cubeofx_Click(object sender, EventArgs e)
        {
            double cubex = Convert.ToDouble(textBox1.Text);
            label2.Text = "(" + textBox1.Text + ")^3";
            textBox1.Text = (cubex * cubex * cubex).ToString();
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            double sqrt = Convert.ToDouble(textBox1.Text);
            label2.Text = "√(" + sqrt + ")";
            if (sqrt < 0)
                textBox1.Text = "Invalid input";
            else
                textBox1.Text = (Math.Sqrt(sqrt)).ToString(); 
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn  = sender as Button;
            operation = btn.Text;
            value = double.Parse(textBox1.Text);
            label2.Text = value.ToString() + operation;
           
            textBox1.Text = "";
            resultispressed = false;
        }

        private void enter_Click(object sender, EventArgs e)
        {
            label2.Text = "";
      
            if (resultispressed)
            {
                switch (operation)
                {
                    case "+":
                        value += second;
                        textBox1.Text = value.ToString();
                        break;
                    case "-":
                        value -= second;
                        textBox1.Text = value.ToString();
                        break;
                    case "*":
                        value *= second;
                        textBox1.Text = value.ToString();
                        break;
                    case "/":
                        value /= second;
                        textBox1.Text = value.ToString();
                         break;
                }
            }
            else
            {
                second = Convert.ToDouble(textBox1.Text);
                switch (operation)
                {
                    case "+":
                        
                        textBox1.Text = (value + second).ToString();
                        break;
                    case "-":
                        textBox1.Text = (value - second).ToString();
                        break;
                    case "*":
                        textBox1.Text = (value * second).ToString();
                        break;
                    case "/":
                        textBox1.Text = (value / second).ToString();
                        break;
                }
                resultispressed = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = (0- Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void mod_Click(object sender, EventArgs e)
        {/*
            value = Convert.ToDouble(textBox1.Text);
            label2.Text += (value/100).ToString();
            operation = "%";
            textBox1.Text = "";*/
        }

        private void MS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(textBox1.Text);
        }

        private void memory_read(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void memory_plus(object sender, EventArgs e)
        {
            memory = memory + double.Parse(textBox1.Text);
        }

        private void memory_minus(object sender, EventArgs e)
        {
            memory = memory - double.Parse(textBox1.Text);
        }

        private void memory_clear(object sender, EventArgs e)
        {
            memory = 0;
        }
    }
}
