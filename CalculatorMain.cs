using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator_Dacal
{
    public partial class Calculator : Form
    {
        private CalculatorFunction calculatorFunction;
        public Calculator()
        {
            InitializeComponent();
            calculatorFunction = new CalculatorFunction();
            txtresult.Text = "0";

            // Enable form to capture key presses
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
            this.KeyDown += new KeyEventHandler(Calculator_KeyDown);

            lbHistory.DrawItem += new DrawItemEventHandler(lbhistory_DrawItem); // Attach event handler
            lbHistory.ItemHeight = 25;

        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            // Handle numeric keys
            if (char.IsDigit(keyChar))
            {
                PassNumber(keyChar.ToString()); 
            }
            else if (keyChar == '%')
            {
                btnPercent_Click(sender, e);
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
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle Escape key to clear
            if (e.KeyCode == Keys.Escape)
            {
                btnClear_Click(sender, e); // Call the Clear button's click event to clear the input
            }
            if (e.Shift && e.KeyCode == Keys.D5)
            {
                // Simulate pressing the % button
                btnPercent.PerformClick();

                // Mark the event as handled
                e.Handled = true;
            }
        }

        // Custom drawing of ListBox items
        private void lbhistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Get the current item text
            string text = lbHistory.Items[e.Index].ToString();

            // Skip drawing for empty lines (blank spaces)
            if (string.IsNullOrWhiteSpace(text))
                return;

            // Determine if the item is an expression or result based on its format
            bool isResult = double.TryParse(text.Trim(), out _); // Check if it's a result

            // Create the fonts for drawing
            using (Font expressionFont = new Font("Gadugi", 12, FontStyle.Regular))
            using (Font resultFont = new Font("Gadugi", 15, FontStyle.Bold))
            {
                // Measure the width of the text
                SizeF textSize = e.Graphics.MeasureString(text, isResult ? resultFont : expressionFont);

                // Calculate the x position for right alignment
                float rightAlignX = e.Bounds.Right - textSize.Width - 10; // 10 pixels padding from the right edge

                // Draw the text at the calculated position
                e.Graphics.DrawString(text, isResult ? resultFont : expressionFont, Brushes.Black, rightAlignX, e.Bounds.Top);
            }

            e.DrawFocusRectangle(); // Optional: show focus rectangle for selected item
        }





        //Numbers
        private void PassNumber(string number)
        {
            calculatorFunction.PassNumber(number);

            // Only show the current number in txtResult
            txtresult.Text = calculatorFunction.GetCurrentNumber();

            // Do not update txtDisplay until an operator is clicked
            calculatorFunction.IsEqualsClicked = false;
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
            if (string.IsNullOrEmpty(calculatorFunction.currentExpression) || calculatorFunction.IsLastCharOperator())
            {
                PassNumber("0.");
            }
            else if (!calculatorFunction.HasMultipleDecimalPoints())
            {
                PassNumber(".");
            }
        }

        // Operations button
        private void btnAdd_Click(object sender, EventArgs e) => PassOperator("+");
        private void btnSubtract_Click(object sender, EventArgs e) => PassOperator("-");
        private void btnMultiply_Click(object sender, EventArgs e) => PassOperator("*");
        private void btnDivide_Click(object sender, EventArgs e) => PassOperator("/");
        private void PassOperator(string operators)
        {
            calculatorFunction.Operator(operators);

            // Update txtDisplay to show the complete expression
            txtDisplay.Text = calculatorFunction.currentExpression;

            // Show the last number in txtResult
            txtresult.Text = calculatorFunction.GetCurrentNumber();
            calculatorFunction.IsEqualsClicked = false; // Reset equals flag
        
        }

        // Equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            // Get the current expression and calculate the result
            string expression = calculatorFunction.currentExpression;
            double finalResult;
            string result = calculatorFunction.EvaluateExpression(expression, out finalResult);

            if (result == "Success")
            {
                // Display the expression and the result
                txtDisplay.Text = expression; // Show the current expression
                txtresult.Text = finalResult.ToString(); // Show the result

                // Format the history entry for the expression
                string historyEntry = $"{expression} = "; // Entry for the expression

                // Add the expression entry to ListBox (history)
                lbHistory.Items.Add(historyEntry); // Add expression

                // Add the result entry to ListBox (history)
                lbHistory.Items.Add(finalResult.ToString()); // Add result on a new line

                // Add a blank entry for spacing
                lbHistory.Items.Add(""); // This creates a blank line for separation

                // Update the current expression for future calculations
                calculatorFunction.currentExpression = finalResult.ToString(); // Set the current expression to the result
            }
            else
            {
                // Display error message
                txtresult.Text = result;
                calculatorFunction.Clear(); // Reset the calculator for next input
            }
        }



        // Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            txtresult.Text = "";
            calculatorFunction.Clear();
        }

        // Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            calculatorFunction.Backspace();
            txtresult.Text = calculatorFunction.currentExpression;
        }
        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(calculatorFunction.currentExpression))
            {
                calculatorFunction.CalculatePercentage();

                // Update the display with the current number
                txtresult.Text = calculatorFunction.GetCurrentNumber();

                // Do not immediately update txtDisplay, only update it when the next operator is clicked
            }
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            lbHistory.Visible = !lbHistory.Visible;
        }
    }
}