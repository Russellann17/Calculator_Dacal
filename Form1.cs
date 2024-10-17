using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_Dacal
{
    public partial class Form1 : Form
    {
        private string currentExpression;
        private bool isEqualsClicked;
        private string currentHistory;

        public Form1()
        {
            InitializeComponent();
            currentExpression = "";
            isEqualsClicked = false;
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
            isEqualsClicked = false;
        }
        private void btn0_Click(object sender, EventArgs e) => PassNumber("0");
        private void btn1_Click(object sender, EventArgs e) => PassNumber("1");
        private void btn2_Click(object sender, EventArgs e) => PassNumber("2");
        private void btn3_Click(object sender, EventArgs e) => PassNumber("3");
        private void btn4_Click(object sender, EventArgs e) => PassNumber("4");
        private void btn5_Click(object sender, EventArgs e) => PassNumber("5");
        private void btn6_Click(object sender, EventArgs e) => PassNumber("6");
        private void btn7_Click(object sender, EventArgs e) => PassNumber("7");
        private void btn8_Click(object sender, EventArgs e) => PassNumber("8");
        private void btn9_Click(object sender, EventArgs e) => PassNumber("9");
        //Decimal Point
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentExpression) || IsLastCharOperator())
            {
                PassNumber("0.");
            }
            else if (!HasMultipleDecimalPoints())
            {
                PassNumber(".");
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
                isEqualsClicked = false;
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
            if (currentHistory == txtDisplay.Text || IsLastCharOperator()) return;

            if (currentExpression.Contains("/"))
            {
                string[] parts = currentExpression.Split('/');
                for (int i = 1; i < parts.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(parts[i]) || parts[i].Trim() == "0")
                    {
                        txtDisplay.Text = "Cannot divide by zero";
                        txtresult.Text = "";
                        currentExpression = "";
                        return;
                    }
                }
            }

            DataTable table = new DataTable();
            var result = table.Compute(currentExpression, string.Empty);

            txtDisplay.Text = currentExpression;
            txtresult.Text = result.ToString();
            
            currentHistory = result.ToString();
            lbhistory.Items.Add($"{currentExpression} = {result}");
            
            currentExpression = result.ToString();
        }
        // Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            txtresult.Text = "";
            currentExpression = "";
            isEqualsClicked = false;
        }
        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                currentExpression = currentExpression.Remove(currentExpression.Length - 1);
                txtDisplay.Text = currentExpression;
            }
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentExpression)) return;

            int i = currentExpression.Length - 1;
            while (i >= 0 && (char.IsDigit(currentExpression[i]) || currentExpression[i] == '.'))
            {
                i--;
            }

            string lastNumber = currentExpression.Substring(i + 1);
            if (double.TryParse(lastNumber, out double num))
            {
                currentExpression = currentExpression.Substring(0, i + 1) + (num / 100).ToString();
                txtDisplay.Text = currentExpression;
            }
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            lbhistory.Visible = !lbhistory.Visible;
        }
    }
}