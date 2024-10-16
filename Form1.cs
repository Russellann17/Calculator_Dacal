using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_Dacal
{
    public partial class Form1 : Form
    {
        private string currentExpression;
        private bool isEqualsPressed;

        public Form1()
        {
            InitializeComponent();
            currentExpression = "";
            isEqualsPressed = false;
        }

        private bool IsLastCharOperator()
        {
            if (string.IsNullOrWhiteSpace(currentExpression))
                return false;

            char lastChar = currentExpression[currentExpression.Length - 1];
            return lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/';
        }

        private bool HasMultipleDecimalPoints()
        {
            string[] numbers = currentExpression.Split(new char[] { '+', '-', '*', '/' });
            foreach (string number in numbers)
            {
                if (number.Split('.').Length > 1)
                    return true;
            }
            return false;
        }

        //Numbers
        private void PassNumber(string number)
        {
            if (txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += number;
            txtDisplay.Text = currentExpression;
            isEqualsPressed = false;
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            currentExpression += "0";
            txtDisplay.Text = currentExpression;
            isEqualsPressed = false;
        }
        private void btn1_Click(object sender, EventArgs e) => PassNumber("1");
        private void btn2_Click(object sender, EventArgs e) => PassNumber("2");
        private void btn3_Click(object sender, EventArgs e) => PassNumber("3");
        private void btn4_Click(object sender, EventArgs e) => PassNumber("4");
        private void btn5_Click(object sender, EventArgs e) => PassNumber("5");
        private void btn6_Click(object sender, EventArgs e) => PassNumber("6");
        private void btn7_Click(object sender, EventArgs e) => PassNumber("7");
        private void btn8_Click(object sender, EventArgs e) => PassNumber("8");
        private void btn9_Click(object sender, EventArgs e) => PassNumber("9");
       
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!HasMultipleDecimalPoints())
            {
                PassNumber(".");
            }
            else
            {
                return;
            }
        }
        // Operations button
        private void Operator(string operators)
        {
            if (!IsLastCharOperator() && !string.IsNullOrWhiteSpace(currentExpression))
            {
                currentExpression += operators;
                txtDisplay.Text = currentExpression;
                txtresult.Text = "";
                isEqualsPressed = false;
            }
            else
            {
                return;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) => Operator("+");
        private void btnSubtract_Click(object sender, EventArgs e) => Operator("-");
        private void btnMultiply_Click(object sender, EventArgs e) => Operator("*");
        private void btnDivide_Click(object sender, EventArgs e) => Operator("/");

        // Equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                var result = table.Compute(currentExpression, string.Empty);

                txtDisplay.Text = currentExpression;

                txtresult.Text = result.ToString();

                lbhistory.Items.Add($"{currentExpression} = {result}");

                currentExpression = result.ToString();
            }
            catch
            {
                txtDisplay.Text = "Error";
                txtresult.Text = "";
                currentExpression = "";
            }
        }
        // Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            txtresult.Text = "";
            currentExpression = "";
            isEqualsPressed = false;
        }
        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
        }
    }
}
