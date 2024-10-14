using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_Dacal
{
    public partial class Form1 : Form
    {
        private string currentExpression;
        public Form1()
        {
            InitializeComponent();
            currentExpression = "";
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            Button zero = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += zero.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Button one = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += one.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            Button two = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += two.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            Button three = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += three.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            Button four = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += four.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            Button five = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += five.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            Button six = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += six.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            Button seven = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }

            currentExpression += seven.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            Button eight = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += eight.Text;
            txtDisplay.Text = currentExpression;
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            Button nine = (Button)sender;
            if (txtDisplay.Text == "0" || txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += nine.Text;
            txtDisplay.Text = currentExpression;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
