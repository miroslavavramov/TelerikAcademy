using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.XExpression
{
    class XExpression
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            string simplifiedExpression = "";
            double inBrackets = 0d;
            double sum = 0;

            //check for brackets 
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    inBrackets = char.GetNumericValue(expression[i+1]);
                    for (int k = i+1; k < expression.Length; k++)
                    {
                        switch (expression[k-1])
                        {
                            case '+': inBrackets += char.GetNumericValue(expression[k]);
                                break;
                            case '-': inBrackets -= char.GetNumericValue(expression[k]);
                                break;
                            case '/': inBrackets /= char.GetNumericValue(expression[k]);
                                break;
                            case '*': inBrackets *= char.GetNumericValue(expression[k]);
                                break;
                        }
                        if (expression[k+1] == ')')
                        {
                            i += k-i+1;
                            simplifiedExpression += inBrackets.ToString();
                            inBrackets = 0;
                            break;
                        }
                    }
                }
                else
                {
                    simplifiedExpression += expression[i];    
                }
            }
            //Console.WriteLine(simplifiedExpression);


            List<double> numbers = new List<double>();
            //get numbers
            string s = "";
            for (int i = 0; i < simplifiedExpression.Length; i++)
            {
                if (simplifiedExpression[0] == '-')
                {
                    s += simplifiedExpression[i].ToString();
                }
                if (simplifiedExpression[i] == '+' || simplifiedExpression[i] == '-' || simplifiedExpression[i] == '/' || simplifiedExpression[i] == '*' || simplifiedExpression[i] == '=')
                {
                    numbers.Add(double.Parse(s));
                    s = "";
                    continue;
                }
                s += simplifiedExpression[i].ToString();
            }
            //get signs
            List<char> signs = new List<char>();
            for (int i = 0; i < simplifiedExpression.Length; i++)
            {
                if (simplifiedExpression[i] == '+' || simplifiedExpression[i] == '-' || simplifiedExpression[i] == '/' || simplifiedExpression[i] == '*' || simplifiedExpression[i] == '=')
                {
                    signs.Add(simplifiedExpression[i]);
                    continue;
                }
            }
            sum = numbers[0];
            for (int i = 0; i < signs.Count-1; i++)
            {
                switch (signs[i])
                {
                    case '+': sum += numbers[i + 1];
                        break;
                    case '-': sum -= numbers[i+1];
                        break;
                    case '/': sum /= numbers[i+1];
                        break;
                    case '*': sum *= numbers[i+1];
                        break;
                }
            }
            Console.WriteLine("{0:F2}", sum);
        }
    }
}
