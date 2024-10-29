using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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
        //--------- KeyPress ---------
        private async void TempButtonColor(Button button, Color tempColor, int delay, Color finalColor)
        {
            if (button == null) return;

            var originalColor = button.BackColor; // Store original color
            button.BackColor = tempColor; // Set to temporary color

            await Task.Delay(delay); // Wait for the specified delay

            button.BackColor = finalColor; // Reset to the final color
        }
        private Button GetButtonByChar(char c)
        {
            switch (c)
            {
                case '0': return btn0;
                case '1': return btn1;
                case '2': return btn2;
                case '3': return btn3;
                case '4': return btn4;
                case '5': return btn5;
                case '6': return btn6;
                case '7': return btn7;
                case '8': return btn8;
                case '9': return btn9;
                case '.': return btnDecimal; 
                case '+': return btnAdd;
                case '-': return btnSubtract;
                case '*': return btnMultiply;
                case '/': return btnDivide;
                default: return null;
            }
        }
        private void CalculatorMain_KeyPressed(object sender, KeyPressEventArgs e)
        {
            Button buttonToPress = null;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.') // Allow numbers from 0 to 9
            {
                buttonToPress = GetButtonByChar(e.KeyChar); // Get the corresponding button based on the pressed character
                if (buttonToPress != null)
                {
                    TempButtonColor(buttonToPress, Color.FromArgb(211, 47, 105), 200, Color.FromArgb(240, 98, 146)); // Change color temporarily
                    NumValue_Click(buttonToPress, e);
                }
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/') // Allow basic operators (+, -, *, /)
            {
                buttonToPress = GetButtonByChar(e.KeyChar);
                if (buttonToPress != null)
                {
                    TempButtonColor(buttonToPress, Color.FromArgb(173, 20, 87), 200, Color.FromArgb(194, 24, 92));
                    OperatorValue_Click(buttonToPress, e);
                }
            }
            else if (e.KeyChar == '=') // Allow equal sign key to perform calculation
            {
                Button equalButton = btnEquals; // Reference to the Equals button
                TempButtonColor(equalButton, Color.FromArgb(173, 20, 87), 200, Color.FromArgb(194, 24, 92));
                Equals_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Back) // backspace - to perform the backspace 
            {
                Button backspaceButton = btnBackspace;
                TempButtonColor(backspaceButton, Color.FromArgb(173, 20, 87), 200, Color.FromArgb(194, 24, 92));
                Backspace_Click(sender, e);
            }
            else if (e.KeyChar == 'c') // C - to perform the clear button
            {
                Button clearButton = btnClear;
                TempButtonColor(clearButton, Color.FromArgb(173, 20, 87), 200, Color.FromArgb(194, 24, 92));
                ClearAll_Click(sender, e);
            }
            else if (e.KeyChar == 'h') // H - to perform History button
            {
                Button historyButton = btnHistory;
                TempButtonColor(historyButton, Color.FromArgb(224, 224, 224), 200, Color.FromArgb(255, 251, 253));
                History_Click(sender, e);
            }
            else if(e.KeyChar == 'n') // n - to perform negative value button
            {
                Button negativeButton = btnNegative;
                TempButtonColor(negativeButton, Color.FromArgb(211, 47, 105), 200, Color.FromArgb(240, 98, 146));
                Negative_Click(sender, e);
            }
            else
            {
                e.Handled = true; // Ignore invalid input
            }
        }
        private void CalculatorMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D5 && e.Shift) // Shift + D5 - to perform the percentage
            {
                TempButtonColor(btnPercent, Color.FromArgb(173, 20, 87), 100, Color.FromArgb(194, 24, 92));
                Percent_Click(btnPercent, EventArgs.Empty);
            }
        }
        //--------- Number Buttons ---------
        private void NumValue_Click(object sender, EventArgs e)
        {
            Button numValue = (Button)sender;

            if (calculatorFunction.IsEqualClick) 
            {
                ResetCalculator();
            }   //Equal button Handling
            if (calculatorFunction.IsOperatorClick) 
            {
                txtresult.Clear();
                calculatorFunction.IsOperatorClick = false;
            }   //Operator Handling
            if (numValue.Text != "0" && !calculatorFunction.IsZeroHandle) 
            {
                txtresult.Clear();
                calculatorFunction.IsZeroHandle = true;
            }   //Handling Leading 0
            //---- Handling Decimal Point ----
            if (txtresult.Text == "" && numValue.Text == ".")  
            {
                txtresult.Text = "0" + numValue.Text;
            }
            string currentValue = txtresult.Text.Split(new char[] { '+', '-', '*', '/' }).Last(); //Prevent adding multiple decimal points
            if (numValue.Text == "." && currentValue.Contains("."))
            {
                return;
            }
            if (numValue.Text == "0" && currentValue == "0") return;  //Prevent Multiple 0
            if (numValue.Text == ".")
            {
                if (!txtresult.Text.EndsWith("."))  // If the last character is already a decimal, prevent adding another
                {
                    txtresult.Text += numValue.Text;
                }
            }
            else
            {   
                if (txtresult.Text.Contains("."))   // If there’s already a decimal point, append the number without formatting
                {
                    txtresult.Text += numValue.Text;
                }
                else
                {
                    string tempValue = txtresult.Text.Replace(",", "");     // Remove existing commas for clean parsing
                    tempValue += numValue.Text;     // Append the new digit to the temporary value
                    
                    if (double.TryParse(tempValue, out double parsedValue))    // Parse the modified string as a double
                    {
                        txtresult.Text = parsedValue.ToString("#,0.##########");    // Format the number with commas and up to 6 decimal places
                    }
                }
            }
        }
        //--------- Operator Buttons ---------
        private void OperatorValue_Click(object sender, EventArgs e)
        {
            Button operatorValue = (Button)sender;
            if (txtresult.Text == "Cannot be divided by 0" || txtresult.Text == "Too large to compute")   
            { 
                ResetCalculator();
            } //Handling Division by 0
            if (calculatorFunction.IsEqualClick)    
            {
                txtDisplay.Clear();
                calculatorFunction.IsEqualClick = false;
            } //Equal button Handling
            //--- Handling Multiple Operator Clicks ---
            if (calculatorFunction.IsOperatorClick) 
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + operatorValue.Text;
                return;
            }
            if (calculatorFunction.IsLastCharOperator(txtresult.Text))  
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + operatorValue.Text;
                return;
            }
            if (double.TryParse(txtresult.Text, out double toParse))
            {
                txtDisplay.Text += " " + toParse.ToString("#,0.##########") + " " + operatorValue.Text;
            } // Append the value to txtDisplay & add comma
            calculatorFunction.IsOperatorClick = true;
            calculatorFunction.IsZeroHandle = false;
            calculatorFunction.IsCompute = false;
        }
        private void Equals_Click(object sender, EventArgs e)
        {
            string result;

            if (calculatorFunction.IsCompute) { return; }   //Prevent repeated computation
            if (!calculatorFunction.IsEqualClick)   
            {
                if (double.TryParse(txtresult.Text, out double toParse))
                {
                    txtDisplay.Text += " " + toParse.ToString("#,0.######") + " ";
                }
                calculatorFunction.IsEqualClick = true;
            } //Handling First Equal Click
            //----- For computing of result -----
            string trimmedExpression = calculatorFunction.TrimExpression(txtDisplay.Text);
            result = calculatorFunction.solveExpression(trimmedExpression);
            calculatorFunction.IsOperatorClick = false;
            calculatorFunction.IsCompute = true;
            string finalResult = result;

            if (result == "Cannot be divided by 0" && result == "Too large to compute")
            {
                txtresult.Text = result;
            } //Handling Division by 0
            else
            {
                double parsedResult;
                if (double.TryParse(result, out parsedResult))
                {
                    txtresult.Text = parsedResult.ToString(parsedResult % 1 == 0 ? "N0" : "#,0.##########");
                }
                else
                {
                    txtresult.Text = result;
                }
            } //Format of the result
            if (txtresult.Text != "Cannot be divided by 0" && txtresult.Text != "Too large to compute")
            {
                if (lbHistory.Items.Count == 0 || lbHistory.Items[lbHistory.Items.Count - 2].ToString() != trimmedExpression)
                {
                    lbHistory.Items.AddRange(new object[] { txtDisplay.Text + " =", txtresult.Text, "" });
                }
            } // Update the History
        }
        //--------- Clear Button ---------
        private void ClearAll_Click(object sender, EventArgs e)
        {
            ResetCalculator();
        }
        //--------- Reset and Clear ---------
        private void ResetCalculator()
        {
            txtDisplay.Clear();
            txtresult.Text = "0";
            calculatorFunction.ResetBoolean();
        }
        //--------- BackSpace Button ---------
        private void Backspace_Click(object sender, EventArgs e)
        {
            if (txtresult.Text == "Cannot be divided by 0" || txtresult.Text == "Too large to compute")
            {
                ResetCalculator();
            } //Handling Division by 0
            if (txtresult.Text.Length > 0)
            {
                txtresult.Text = txtresult.Text.Remove(txtresult.Text.Length - 1, 1);   //remove the last character
                if (double.TryParse(txtresult.Text.Replace(",", ""), out double toParseValue))
                {
                    txtresult.Text = toParseValue.ToString("#,0.##########");
                }
            }   //Checking if the textbox is not empty
            if (txtresult.Text == "0" || txtresult.Text == "" || txtresult.Text == "-")
            {
                ResetCalculator();
            }   //If textbox is empty or 0. Clear all boolean methods and refresh to its original value.
        }
        // --------- Percentage Button ---------
        private void Percent_Click(object sender, EventArgs e)
        {
            //---- Convert the current result to double ----
            double currentValue;   
            if (double.TryParse(txtresult.Text, out currentValue))
            {
                double percentageValue = currentValue / 100;    // Calculate the percentage
                txtresult.Text = percentageValue.ToString("#,0.##########"); //Update the result textbox with the percentage
            }   // parse the current result from the textbox
        }
        //Negative Button
        private void Negative_Click(object sender, EventArgs e)
        {
            txtresult.Text = calculatorFunction.ToggleNegative(txtresult.Text);
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