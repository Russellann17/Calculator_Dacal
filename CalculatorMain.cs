using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Calculator_Dacal.FormDesign;
using CalculatorApp;

namespace Calculator_Dacal
{
    public partial class Calculator : RoundedForm
    {
        private CalculatorFunction calculatorFunction;
        public Calculator()
        {
            InitializeComponent();
            calculatorFunction = new CalculatorFunction();
            txtresult.Text = "0";
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(CalculatorMain_KeyPressed);
            this.KeyDown += new KeyEventHandler(CalculatorMain_KeyDown);

            lbHistory.DrawItem += new DrawItemEventHandler(lbhistory_DrawItem);
            lbHistory.ItemHeight = 25;
        }
        //KeyPress for 0-9 button and operators
        private void CalculatorMain_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.') // Allow numbers from 0 to 9
            {
                Button numberButton = new Button();
                numberButton.Text = e.KeyChar.ToString();
                NumValue_Click(numberButton, e); // Call the existing number handler for input validation
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/') // Allow basic operators (+, -, *, /)
            {
                Button operatorButton = new Button();
                operatorButton.Text = e.KeyChar.ToString();
                OperatorValue_Click(operatorButton, e); // Call the existing operator handler for input validation
            }
            else if (e.KeyChar == '=') // Allow equal sign key to perform calculation
            {
                Equals_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Back) // backspace - to perform the backspace 
            {
                Backspace_Click(sender, e);
            }
            else if (e.KeyChar == 'c') // C - to perform the clear button
            {
                ClearAll_Click(sender, e);
            }
            else if (e.KeyChar == 'h') // H - to perform History button
            {
                History_Click(sender, e);
            }
            else if(e.KeyChar == 'n') // n - to perform negative value button
            {
                Negative_Click(sender, e);
            }
            else
            {
                e.Handled = true; // Ignore invalid input
            }
        }
        //Combination keys for percentage
        private void CalculatorMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D5 && e.Shift) // Shift + D5 - to perform the percentage
                Percent_Click(btnPercent, EventArgs.Empty);
        }
        //Holder or the one who gets the value of decimal and numbers 0-9
        private void NumValue_Click(object sender, EventArgs e)
        {
            Button numValue = (Button)sender;

            if (calculatorFunction.IsEqualClick) //Equal button Handling - resets the calculator to prepare for new input
            {
                ResetCalculator();
            }
            if (calculatorFunction.IsOperatorClick) // Operator Handling - If operator was clicked, it clears the display.
            {
                txtresult.Clear();
                calculatorFunction.IsOperatorClick = false;
            }
            if (numValue.Text != "0" && !calculatorFunction.IsZeroHandle) // Handling Leading 0 - Changing the values when the first value is 0 and without decimal 
            {
                txtresult.Clear();
                calculatorFunction.IsZeroHandle = true;
            }
            if (txtresult.Text == "" && numValue.Text == ".")  // Handling Decimal Point - Checks if the txtresult already contains decimal point you can't add another decimal point
            {
                txtresult.Text = "0" + numValue.Text;
            }
            string currentValue = txtresult.Text.Split(new char[] { '+', '-', '*', '/' }).Last(); // Prevent adding multiple decimal points
            if (numValue.Text == "." && currentValue.Contains("."))
            {
                return;
            }
            if (numValue.Text == "0" && currentValue == "0") return;    //Prevent Multiple 0

            if (numValue.Text == ".")
            {
                // If the last character is already a decimal, prevent adding another
                if (!txtresult.Text.EndsWith("."))
                {
                    txtresult.Text += numValue.Text;
                }
            }
            else
            {
                // If there’s already a decimal point, append the number without further formatting
                if (txtresult.Text.Contains("."))
                {
                    txtresult.Text += numValue.Text;
                }
                else
                {
                    // Remove existing commas for clean parsing
                    string tempValue = txtresult.Text.Replace(",", "");

                    // Append the new digit to the temporary value
                    tempValue += numValue.Text;

                    // Attempt to parse the modified string as a double
                    if (double.TryParse(tempValue, out double parsedValue))
                    {
                        // Format the number with commas and up to 6 decimal places
                        txtresult.Text = parsedValue.ToString("#,0.##########");
                    }
                }
            }
        }
        private void OperatorValue_Click(object sender, EventArgs e)
        {
            Button operatorValue = (Button)sender;
            if (txtresult.Text == "Cannot be divided by 0" || txtresult.Text == "Too large to compute")   //Handling Division by 0 - checks for division by zero and updates the result
            { 
                ResetCalculator();
            }
                if (calculatorFunction.IsEqualClick)    //Equal button Handling - resets the calculator to prepare for new input
            {
                txtDisplay.Clear();
                calculatorFunction.IsEqualClick = false;
            }
            if (calculatorFunction.IsOperatorClick) //Handling Consecutive Operator Clicks - replace with the new operator instead of add
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + operatorValue.Text;
                return;
            }
            if (calculatorFunction.IsLastCharOperator(txtresult.Text)) //Replace the existing last operator with the new operator  
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + operatorValue.Text;
                return;
            }
            // Append the value to txtDisplay & add comma
            double toParse;
            if (double.TryParse(txtresult.Text, out toParse))
            {
                txtDisplay.Text += " " + toParse.ToString("#,0.##########") + " " + operatorValue.Text;
            }
            calculatorFunction.IsOperatorClick = true;
            calculatorFunction.IsZeroHandle = false;
            calculatorFunction.IsCompute = false;
        }
        private void Equals_Click(object sender, EventArgs e)
        {
            string result;

            if (calculatorFunction.IsCompute) { return; }   //Prevent repeated computation
            if (!calculatorFunction.IsEqualClick)   //Handling First Equal Click -  If wla pa naclick ang equal button it will append the value to txtdisplay
            {
                double toParse;
                if (double.TryParse(txtresult.Text, out toParse))
                {
                    txtDisplay.Text += " " + toParse.ToString("#,0.######") + " ";
                }
                calculatorFunction.IsEqualClick = true;
            }
            //For computing of result
            string trimmedExpression = calculatorFunction.TrimExpression(txtDisplay.Text);
            result = calculatorFunction.solveExpression(trimmedExpression);
            calculatorFunction.IsOperatorClick = false;
            calculatorFunction.IsCompute = true;
            string finalResult = result;

            if (result == "Cannot be divided by 0" && result == "Too large to compute")   //Handling Division by 0 - checks for division by zero and updates the result
            {
                txtresult.Text = result;
            }
            else    //Format of the result
            {
                double parsedResult;
                if (double.TryParse(result, out parsedResult))
                {
                    //It checks if parsedResult is an integer if true then it will use No decimal places format, if false it uses custom format
                    txtresult.Text = parsedResult.ToString(parsedResult % 1 == 0 ? "N0" : "#,0.##########");
                }
                else
                {
                    txtresult.Text = result;
                }
            }
            // Updating the History
            if (txtresult.Text != "Cannot be divided by 0" && txtresult.Text != "Too large to compute")
            {
                if (lbHistory.Items.Count == 0 || lbHistory.Items[lbHistory.Items.Count - 2].ToString() != trimmedExpression)
                {
                    lbHistory.Items.Add(txtDisplay.Text + " ="); // Add expression
                    lbHistory.Items.Add(txtresult.Text); // Add result on a new line
                    lbHistory.Items.Add(""); // Add blank line for separation
                }
            }
        }
        //Clear Button
        private void ClearAll_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }
        //Resets the boolean flags and clear the input and output displays
        private void ResetCalculator()
        {
            txtDisplay.Clear();
            txtresult.Text = "0";
            calculatorFunction.IsZeroHandle = false;
            calculatorFunction.IsOperatorClick = false;
            calculatorFunction.IsEqualClick = false;
            calculatorFunction.IsCompute = false;
        }
        //BackSpace Button
        private void Backspace_Click(object sender, EventArgs e)
        {
            //Checking if the textbox is not empty
            if (txtresult.Text.Length > 0)
            {
                //remove the last character
                txtresult.Text = txtresult.Text.Remove(txtresult.Text.Length - 1, 1);

                double toParseValue;

                if (double.TryParse(txtresult.Text.Replace(",", ""), out toParseValue))
                {
                    txtresult.Text = toParseValue.ToString("#,0.##########");
                }
            }
            //If textbox is empty or 0. Clear all boolean methods and refresh to its original value.
            if (txtresult.Text == "0" || txtresult.Text == "" || txtresult.Text == "-")
            {
                ResetCalculator();
            }
        }
        //Percentage Button
        private void Percent_Click(object sender, EventArgs e)
        {
            // Convert the current result to double
            double currentValue;
            // parse the current result from the textbox
            if (double.TryParse(txtresult.Text, out currentValue))
            {
                // Calculate the percentage
                double percentageValue = currentValue / 100;
                // Update the result textbox with the percentage
                txtresult.Text = percentageValue.ToString("#,0.##########"); // Format the output
            }
        }
        //Negative Button
        private void Negative_Click(object sender, EventArgs e)
        {
            double negativeValue = double.Parse(txtresult.Text) - (double.Parse(txtresult.Text) * 2);

            if (txtresult.Text == "0")
            {
                return;
            }
            else
            {
                txtresult.Text = negativeValue.ToString("#,0.##########");
            }
        }
        //History Button Visibility
        private void History_Click(object sender, EventArgs e)
        {
            lbHistory.Visible = !lbHistory.Visible;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Custom Design of lbHistory
        private void lbhistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string text = lbHistory.Items[e.Index].ToString();

            if (string.IsNullOrWhiteSpace(text))
                return;

            bool isResult = double.TryParse(text.Trim(), out _);

            using (Font expressionFont = new Font("Segoe UI", 14, FontStyle.Regular))
            using (Font resultFont = new Font("Segoe UI", 16, FontStyle.Bold))
            {
                SizeF textSize = e.Graphics.MeasureString(text, isResult ? resultFont : expressionFont);
                float rightAlignX = e.Bounds.Right - textSize.Width - 10;

                Brush textBrush = new SolidBrush(isResult ? Color.Black : Color.FromArgb(132, 60, 84));

                e.Graphics.DrawString(text, isResult ? resultFont : expressionFont, textBrush, rightAlignX, e.Bounds.Top);
            }
            e.DrawFocusRectangle();
        }
    }
}