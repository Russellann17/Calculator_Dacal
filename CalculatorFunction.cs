using System;
using System.Data;

namespace Calculator_Dacal
{
    public class CalculatorFunction
    {
        public string currentExpression { get; set; }
        public bool IsEqualsClicked { get; set; }

        public CalculatorFunction()
        {
            currentExpression = "";
            IsEqualsClicked = false;
        }
        public bool IsLastCharOperator()
        {
            if (string.IsNullOrEmpty(currentExpression)) return false;

            string trimExpression = currentExpression.Trim();
            char lastChar = trimExpression[trimExpression.Length - 1];

            return lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/';
        }

        public bool HasMultipleDecimalPoints()
        {
            int lastOperatorIndex = currentExpression.LastIndexOfAny(new char[] { '+', '-', '*', '/' });
            string currentNumber = lastOperatorIndex == -1 ? currentExpression : currentExpression.Substring(lastOperatorIndex + 1);
            
            if (currentExpression.EndsWith("."))
            {
                return true; // Do not allow adding another decimal after a '.'
            }

            if (currentNumber.Contains("."))
            {
                return true;
            }

            return false;
        }
        public void PassNumber(string number)
        {
            if (string.IsNullOrEmpty(currentExpression) || number != "0")
            {
                currentExpression += number;
            }
            else if (currentExpression != "0") // Prevent multiple leading zeros
            {
                currentExpression += number;
            }
            else if (!currentExpression.EndsWith("0") || number != "0")
            {
                currentExpression += number;
            }

            IsEqualsClicked = false;
        }

        public string GetCurrentNumber()
        {
            var parts = currentExpression.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 0 ? parts[parts.Length - 1] : "0";
        }
        public void Operator(string operators)
        {
            currentExpression = currentExpression.Trim();

            if (IsLastCharOperator())
            {
                currentExpression = currentExpression.Substring(0, currentExpression.Length - 1).Trim() + " " + operators + " ";
            }
            else if (!string.IsNullOrEmpty(currentExpression))
            {
                currentExpression += " " + operators + " ";
            }
        }

        public string EvaluateExpression(string currentExpression, out double res)
        {
            res = 0;
            currentExpression = currentExpression.Trim();

            if (string.IsNullOrWhiteSpace(currentExpression) || IsLastCharOperator())
            {
                return "Incomplete expression";
            }

            if (currentExpression.Contains("/"))
            {
                string[] parts = currentExpression.Split('/');
                for (int i = 1; i < parts.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(parts[i]) || parts[i].Trim() == "0")
                    {
                        return "Cannot be divided by 0";
                    }
                }
            }
            try
            {
                string expressionToCompute = currentExpression.Replace(" ", "");
                DataTable table = new DataTable();
                var result = table.Compute(expressionToCompute, string.Empty);

                res = Convert.ToDouble(result);

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Error evaluating expressions: {ex.Message}";
            }
        }

        public void Clear()
        {
            currentExpression = "";
            IsEqualsClicked = false;
        }

        public void Backspace()
        {
            if (!string.IsNullOrEmpty(currentExpression))
            {
                currentExpression = currentExpression.Remove(currentExpression.Length - 1, 1);
            }
        }

        public void CalculatePercentage()
        {
            if (string.IsNullOrWhiteSpace(currentExpression)) return;

            int i = currentExpression.Length - 1;

            // Find the last number in the expression
            while (i >= 0 && (char.IsDigit(currentExpression[i]) || currentExpression[i] == '.'))
            {
                i--;
            }

            string lastNumber = currentExpression.Substring(i + 1);

            // Calculate the percentage
            if (double.TryParse(lastNumber, out double num))
            {
                double percentage = num / 100; // Calculate the percentage
                currentExpression = currentExpression.Remove(i + 1); // Remove last number
                currentExpression += percentage.ToString(); // Append percentage to the expression
            }
        }



    }
}
