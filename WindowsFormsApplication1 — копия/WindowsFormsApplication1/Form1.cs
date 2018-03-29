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
        bool result_pressed = false;
        bool operation_pressed = false;
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
            /*if (result_pressed)
            {
                textBox1.Text += "";
                operation_pressed = false;
                return;
            }*/
            if (btn.Text == ".")
            {
                if (! textBox1.Text.Contains("."))
                    textBox1.Text += btn.Text;
            }
            else
            textBox1.Text += btn.Text;
            operation_pressed = false;
            result_pressed = false;
        }
        
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (operation_pressed)
            {
                operation = btn.Text;
                label2.Text = value.ToString() + operation;
                return;
            }
            else
            {
                operation = btn.Text;
                value = double.Parse(textBox1.Text);
                label2.Text = value.ToString() + operation;
                textBox1.Text = "";
                result_pressed = false;
                operation_pressed = true;
            }
        }

        private void operation2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            double x = Convert.ToDouble(textBox1.Text);
            
            if (btn.Text == "1/x")
            {
                label2.Text = "1/(" + textBox1.Text + ")";
                textBox1.Text = (1 / x).ToString();
            }
            if (btn.Text == "√")
            {
                label2.Text = "√(" + x + ")";
                if (x < 0)
                    textBox1.Text = "Invalid input";
                else
                    textBox1.Text = (Math.Sqrt(x)).ToString();
            }
            if (btn.Text == "x^2")
            {
                label2.Text = "sqr(" + textBox1.Text + ")";
                textBox1.Text = (x * x).ToString();
            }
            if (btn.Text == "x^3")
            {
                label2.Text = "(" + textBox1.Text + ")^3";
                textBox1.Text = (x * x * x).ToString();
            }
            if (btn.Text == "sin")
            {
                label2.Text = "sin(" + x.ToString() + ")";
                x = (Convert.ToDouble(textBox1.Text) * Math.PI) / 180;
                textBox1.Text = Math.Sin(x).ToString();
            }
            if (btn.Text == "cos")
            {
                label2.Text = "cos(" + x.ToString() + ")";
                x = (Convert.ToDouble(textBox1.Text) * Math.PI) / 180;
                textBox1.Text = Math.Cos(x).ToString();
            }
            if (btn.Text == "tan")
            {
                label2.Text = "tan(" + x.ToString() + ")";
                x = (Convert.ToDouble(textBox1.Text) * Math.PI) / 180;
                textBox1.Text = Math.Tan(x).ToString();
            }
            if (btn.Text == "!")
            {
                double t = 1;
                label2.Text = "fact(" + x.ToString() + ")";
                for (int i = 1; i <= x; ++i)
                {
                    t *= i;
                }
                textBox1.Text = t.ToString();
            }
            if (btn.Text == "log")
            {
                label2.Text = "log(" + x.ToString() + ")";
                textBox1.Text = (Math.Log10(x)).ToString();
            }
            if (btn.Text == "e^x")
            {
                label2.Text = "e^(" + x.ToString() + ")";
                x = Math.Exp(x);
                textBox1.Text = x.ToString();
            }
            if (btn.Text == "10^x")
            {
                label2.Text = "10^(" + x.ToString() + ")";
                x = Math.Pow(10, x);
                textBox1.Text = x.ToString();
            }
            operation_pressed = false;
            result_pressed = false;
        }
        private void operation3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (operation_pressed)
            {
                if (btn.Text == "x^y")
                    operation = "^";
                if (btn.Text == "x^1/y")
                    operation = " yroot";
                if (btn.Text == "%")
                    operation = "%";
                label2.Text = value.ToString() + operation;
                return;
            }
            value = double.Parse(textBox1.Text);
            if (btn.Text == "x^y")
                operation = "^";
            if (btn.Text == "x^1/y")
                operation = " yroot";
            if (btn.Text == "%")
                operation = "%";
            label2.Text = value.ToString() + operation;
            textBox1.Text = "";
            result_pressed = false;
            operation_pressed = true;
        }
        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label2.Text = "";
            value = 0;
            second = 0;
            operation = "";
            result_pressed = false;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        
        private void enter_Click(object sender, EventArgs e)
        {

            label2.Text = "";
            
            if (result_pressed )
            {
                if (operation_pressed)
                {
                    second = value;
                }
                switch (operation)
                {
                    case "+":
                        value = Convert.ToDouble(textBox1.Text);
                        value += second;
                        textBox1.Text = value.ToString();
                        break;
                    case "-":
                        value = Convert.ToDouble(textBox1.Text);
                        value -= second;
                        textBox1.Text = value.ToString();
                        break;
                    case "*":
                        value = Convert.ToDouble(textBox1.Text);
                        value *= second;
                        textBox1.Text = value.ToString();
                        break;
                    case "/":
                        value = Convert.ToDouble(textBox1.Text);
                        value /= second;
                        textBox1.Text = value.ToString();
                         break;
                    case "^":
                        value = Convert.ToDouble(textBox1.Text);
                        value = Math.Pow(value, second);
                        textBox1.Text = value.ToString();
                        break;
                    case " yroot":
                        value = Convert.ToDouble(textBox1.Text);
                        value = Math.Pow(value, 1 / second);
                        textBox1.Text = value.ToString();
                        break;
                }
                result_pressed = true;
                operation_pressed = false;
            }
            else
            {
                if (operation_pressed)
                {
                    second = value;
                }
                else
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
                    case "%":
                        textBox1.Text = ((value * second)/100).ToString();
                        break;
                    case "Mod":
                        textBox1.Text = (value % second).ToString();
                        break;
                    case "^":
                        value = Math.Pow(value,  second);
                        textBox1.Text = value.ToString() ;
                        break;
                    case " yroot":
                        if ((second % 2 == 0) && (value < 0))
                        {
                            textBox1.Text = "Invalid input";
                        }
                        else
                        { 
                            value = Math.Pow(value, 1 / second);
                            textBox1.Text = value.ToString();
                        }
                        break;
                }
                result_pressed = true;
                operation_pressed = false;
            }
        }
        
        private void negate_Click(object sender, EventArgs e)
        {
            textBox1.Text = (0- Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void erase_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
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
            button27.Enabled = true;
            button28.Enabled = true;
            memory = memory + double.Parse(textBox1.Text);
        }
        private void memory_minus(object sender, EventArgs e)
        {
            button27.Enabled = true;
            button28.Enabled = true;
            memory = memory - double.Parse(textBox1.Text);
        }
        private void memory_clear(object sender, EventArgs e)
        {
            button27.Enabled = true;
            button28.Enabled = true;
            memory = 0;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((textBox1.Text == "0"))
            {
                textBox1.Text = "";
            }
            if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 46)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    if (!textBox1.Text.Contains("."))
                        textBox1.Text += ".";
                }
                else
                    textBox1.Text += e.KeyChar.ToString();
            }
            if (e.KeyChar == 42 || e.KeyChar == 43 || e.KeyChar == 45 || e.KeyChar == 47) 
            {
                if (operation_pressed)
                {
                    operation = e.KeyChar.ToString();
                    label2.Text = value.ToString() + operation;
                    return;
                }
                else
                {
                    operation = e.KeyChar.ToString();
                    label2.Text = textBox1.Text;
                    value = double.Parse(textBox1.Text);
                    label2.Text = value.ToString() + operation;
                    textBox1.Text = "";
                    result_pressed = false;
                    operation_pressed = true;
                }
            }
            if ( e.KeyChar == 61 || e.KeyChar == 13)
            {
                label2.Text = "";

                if (result_pressed)
                {
                    if (operation_pressed)
                    {
                        second = value;
                    }
                    switch (operation)
                    {
                        case "+":
                            value = Convert.ToDouble(textBox1.Text);
                            value += second;
                            textBox1.Text = value.ToString();
                            break;
                        case "-":
                            value = Convert.ToDouble(textBox1.Text);
                            value -= second;
                            textBox1.Text = value.ToString();
                            break;
                        case "*":
                            value = Convert.ToDouble(textBox1.Text);
                            value *= second;
                            textBox1.Text = value.ToString();
                            break;
                        case "/":
                            value = Convert.ToDouble(textBox1.Text);
                            value /= second;
                            textBox1.Text = value.ToString();
                            break;
                        case "^":
                            value = Convert.ToDouble(textBox1.Text);
                            value = Math.Pow(value, second);
                            textBox1.Text = value.ToString();
                            break;
                        case " yroot":
                            value = Convert.ToDouble(textBox1.Text);
                            value = Math.Pow(value, 1 / second);
                            textBox1.Text = value.ToString();
                            break;
                    }
                    result_pressed = true;
                    operation_pressed = false;
                }
                else
                {
                    if (operation_pressed)
                    {
                        second = value;
                    }
                    else
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
                        case "%":
                            textBox1.Text = ((value * second) / 100).ToString();
                            break;
                        case "Mod":
                            textBox1.Text = (value % second).ToString();
                            break;
                        case "^":
                            value = Math.Pow(value, second);
                            textBox1.Text = value.ToString();
                            break;
                        case " yroot":
                            if ((second % 2 == 0) && (value < 0))
                            {
                                textBox1.Text = "Invalid input";
                            }
                            else
                            {
                                value = Math.Pow(value, 1 / second);
                                textBox1.Text = value.ToString();
                            }
                            break;
                    }
                    result_pressed = true;
                    operation_pressed = false;
                }
            }
           
            if (e.KeyChar == 8)
            {
                if (textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                if (textBox1.Text == "")
                    textBox1.Text = "0";
            }
        }

        private void PI_Click(object sender, EventArgs e)
        {
            textBox1.Text = "3.14159265359";
        }
    }
}
