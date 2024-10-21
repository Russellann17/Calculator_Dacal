using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Dacal
{
    public class CalculatorFunction
    {
        private string currentExpression;
        private string currentHistory;

        public CalculatorFunction()
        {
            currentExpression = string.Empty;
            currentHistory = string.Empty;
        }

        public string CurrentExpression { get => currentExpression; set => currentExpression = value; }
        public string CurrentHistory { get => currentHistory; set => currentHistory = value; }

        public bool IsLastCharOperator()
        {
            if (string.IsNullOrEmpty(currentHistory)) return false;

            string trimExpression = currentExpression.Trim();
            char lastChar = trimExpression[trimExpression.Length - 1];

            return lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/';
        }

        public bool HasMultipleDecimalPoints()
        {
            // Find the last operator (+, -, *, or /) in the expression
            int lastOperatorIndex = currentExpression.LastIndexOfAny(new char[] { '+', '-', '*', '/' });

            // If no operator is found, the current number is the whole expression
            // Otherwise, we take the number that comes after the last operator
            string currentNumber = lastOperatorIndex == -1 ? currentExpression : currentExpression.Substring(lastOperatorIndex + 1);

            // Prevent two consecutive decimal points
            // If the last character in the current expression is already a decimal point, return true
            if (currentExpression.EndsWith("."))
            {
                return true; // Do not allow adding another decimal after a '.'
            }

            // Check if the current number already has one decimal point
            // If it does, return true to prevent adding another one
            if (currentNumber.Contains("."))
            {
                return true;
            }

            // No multiple decimal points detected, allow adding a decimal
            return false;
        }

        public string EvaluateExpression()
        {
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

            string expressionToCompute = currentExpression.Replace(" ", "");
            DataTable table = new DataTable();
            var result = table.Compute(expressionToCompute, string.Empty);

            return Convert.ToDouble(result).ToString();
        }

        public void Clear()
        {
            currentExpression = string.Empty;
        }
    }
}
