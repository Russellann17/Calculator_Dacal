using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_Dacal
{
    public partial class Calculator : Form
    {
        private CalculatorFunction calculatorFunction;
        private bool isEqualsClicked;

        public Calculator()
        {
            InitializeComponent();
            calculatorFunction = new CalculatorFunction();
            isEqualsClicked = false;
            // Enable form to capture key presses
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Handle numeric keys
            if (char.IsDigit(keyChar))
            {
                PassNumber(keyChar.ToString());
            }
            // Handle decimal point ('.')
            else if (keyChar == '.')
            {
                btnDot_Click(sender, e);
            }
            // Handle operators
            else if (keyChar == '+')
            {
                btnAdd_Click(sender, e);
            }
            else if (keyChar == '-')
            {
                btnSubtract_Click(sender, e);
            }
            else if (keyChar == '*')
            {
                btnMultiply_Click(sender, e);
            }
            else if (keyChar == '/')
            {
                btnDivide_Click(sender, e);
            }
            // Handle Enter key (equals operation)
            else if (keyChar == '=')
            {
                btnEquals_Click(sender, e);
            }
            // Handle Backspace key
            else if (keyChar == (char)Keys.Back)
            {
                btnBackspace_Click(sender, e);
            }
            else
            {
                // Ignore other keys
                e.Handled = true;
            }
        }

        //Numbers
        private void PassNumber(string number)
        {
            if (txtDisplay.Text == "Cannot divide by zero")
            {
                txtDisplay.Clear();
            }
            calculatorFunction.CurrentExpression += number;
            txtDisplay.Text = calculatorFunction.CurrentExpression;
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
        


        private void btnAdd_Click(object sender, EventArgs e) => Operator("+");
        private void btnSubtract_Click(object sender, EventArgs e) => Operator("-");
        private void btnMultiply_Click(object sender, EventArgs e) => Operator("*");
        private void btnDivide_Click(object sender, EventArgs e) => Operator("/");

        private void Operator(string operators)
        {
            // Trim spaces from the current expression
            currentExpression = currentExpression.Trim();

            // If the current expression is empty, just add the operator
            if (string.IsNullOrWhiteSpace(currentExpression))
            {
                currentExpression += " "+ operators + " ";
            }
            else
            {
                // Check if the last character is an operator
                if (IsLastCharOperator())
                {
                    // Replace the last operator with the new operator
                    currentExpression = currentExpression.Substring(0, currentExpression.Length - 1) + operators + " ";
                }
                else
                {
                    // If the last character isn't an operator, just add the new operator
                    currentExpression += " " + operators + " ";
                }
            }

            // Update the display
            txtDisplay.Text = currentExpression;
            txtresult.Text = "";
            isEqualsClicked = false;
        }


        // Equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (currentHistory == txtDisplay.Text || IsLastCharOperator() || txtDisplay.Text == "") return;

            if (currentExpression.Contains("/"))
            {
                string[] parts = currentExpression.Split('/');
                for (int i = 1; i < parts.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(parts[i]) || parts[i].Trim() == "0")
                    {
                        txtresult.Text = "Cannot be divided by 0";
                        currentExpression = "";
                        return;
                    }
                }
            }
            string expressionToEvaluate = currentExpression.Replace(" ", "");

            DataTable table = new DataTable();
            var result = table.Compute(expressionToEvaluate, string.Empty);

            double finalResult = Convert.ToDouble(result);

            txtDisplay.Text = currentExpression;
            txtresult.Text = finalResult.ToString();
            
            currentHistory = result.ToString();
            lbhistory.Items.Add($"{currentExpression} = {finalResult}");
            
            currentExpression = finalResult.ToString();
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