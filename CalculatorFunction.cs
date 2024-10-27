using System;
using System.Data;

namespace CalculatorApp
{
    public class CalculatorFunction
    {
        public bool IsEqualClick { get; set; } = false;
        public bool IsOperatorClick { get; set; } = false;
        public bool IsZeroHandle { get; set; } = false;
        public bool IsCompute { get; set; } = false;

        //Check if the last character is an operator
        //For Replacing the existing operator with the new operator
        public bool IsLastCharOperator(string value)
        {
            // Check for Null or Empty String
            if (string.IsNullOrEmpty(value)) return false;
            //Trim the Input
            string trimExpression = value.Trim();
            //Get the Last Character
            char lastChar = trimExpression[trimExpression.Length - 1];
            //Check if the Last Character is an Operator
            return lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/';
        }
        //Remove the spaces and commas
        public string TrimExpression(string displayValue)
        {
            displayValue = displayValue.Replace(",", "");
            return displayValue.Replace(" ", "");
        }
        //Evaluate the expression
        public string solveExpression(string trimExpression)
        {
            if (trimExpression.Contains("/0"))  //Check for Division by 0
            {
                return "Cannot be divided by 0";
            }
            try
            {
                DataTable table = new DataTable();
                var result = table.Compute(trimExpression, string.Empty); //solve the expression
                return result.ToString();
            }
            catch (OverflowException) //If the result exceeds the maximum allowable value for a numeric type
            {
                return "Too large to compute";
            }
        }
    }
}
