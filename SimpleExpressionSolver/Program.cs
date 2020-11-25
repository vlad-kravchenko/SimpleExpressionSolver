using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExpressionSolver
{
    class Program
    {
        static string expression = "-1,17-4-5,45+4+3,234-2+5-2+12,4-";

        static void Main(string[] args)
        {
            CorrectString();
            var numbers = GetNumbers();
            var operators = GetOperators();
            var result = GetResult(numbers, operators);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static void CorrectString()
        {
            if (!char.IsDigit(expression[0])) expression = "0" + expression;
            if (!char.IsDigit(expression[expression.Length - 1])) expression = expression.Substring(0, expression.Length - 1);
        }

        private static List<double> GetNumbers()
        {
            string[] dividers = new[] {"-", "+"};
            var numStrings = expression.Split(dividers, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<double> numbers = new List<double>();
            numStrings.ForEach(s => numbers.Add(double.Parse(s.Replace(".",","))));
            return numbers;
        }

        private static List<string> GetOperators()
        {
            List<string> operators = new List<string>();
            foreach (var symbol in expression.ToCharArray())
            {
                if (symbol == '-' || symbol == '+')
                {
                    operators.Add(symbol.ToString());
                }
            }

            return operators;
        }

        private static double GetResult(List<double> numbers, List<string> operators)
        {
            double result = numbers[0];
            int opId = 0;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (operators[opId] == "-")
                {
                    result = result - numbers[i];
                }
                else
                {
                    result = result + numbers[i];
                }

                opId++;
            }

            return result;
        }
    }
}