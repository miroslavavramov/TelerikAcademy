using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
class ArithmeticalExpression
{
    static List<char> arithmeticOperations = new List<char>() { '+', '-', '*', '/' };
    static List<char> brackets = new List<char>() { '(', ')' };
    static List<string> functions = new List<string>() { "pow", "ln", "sqrt" };
  
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        //TODO : Add Sin, Cos f's

        string input = Console.ReadLine();
        input = input.Replace(" ", String.Empty);

        try
        {
            List<string> tokens = GetTokens(input);
            Queue<string> reversePolishNotation = ConvertToReversePolishNotation(tokens);

            Console.WriteLine(CalculateResult(reversePolishNotation));
        }
        catch(ArgumentException aE) 
        {
            Console.WriteLine(aE.Message);
        }
     
    }
    static List<string> GetTokens(string input)
    {
        List<string> tokens = new List<string>();
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' && (i == 0 || input[i-1] == ',' || input[i-1] == '('))
            {
                number.Append('-');
            }
            else if (char.IsDigit(input[i]) || input[i] == '.')
            {
                number.Append(input[i]);
            }
            else if (!char.IsDigit(input[i])  && input[i] != '.' && number.Length != 0 )
            {
                tokens.Add(number.ToString());
                number.Clear();
                i--;
            }
            else if (arithmeticOperations.Contains(input[i]))
            {
                tokens.Add(input[i].ToString());
            }
            else if (brackets.Contains(input[i]))
            {
                tokens.Add(input[i].ToString());
            }
            else if (input[i] == ',')
            {
                tokens.Add(input[i].ToString());
            }
            else if (i + 1 < input.Length && input.Substring(i,2).ToLower() == "ln")
            {
                tokens.Add("ln");
                i++;
            }
            else if (i + 2 < input.Length && input.Substring(i, 3).ToLower() == "pow")
            {
                tokens.Add("pow");
                i += 2;
            }
            else if (i + 3 < input.Length && input.Substring(i, 4).ToLower() == "sqrt")
            {
                tokens.Add("sqrt");
                i += 3;
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
        }
        if (number.Length != 0)
        {
            tokens.Add(number.ToString());
        }
        return tokens;
    }
    static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
    {
        Stack<string> stack = new Stack<string>();
        Queue<string> queue = new Queue<string>();
        double num;

        for (int i = 0; i < tokens.Count; i++)
        {
            if (double.TryParse(tokens[i],out num))
            {
                queue.Enqueue(tokens[i]);
            }
            else if(functions.Contains(tokens[i]))
            {
                stack.Push(tokens[i]);
            }
            else if (tokens[i] == ",")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            else if (arithmeticOperations.Contains(tokens[i][0]))
            {
                while (stack.Count > 0
                    && arithmeticOperations.Contains(stack.Peek()[0])
                    && CheckPrecedence(tokens[i]) <= CheckPrecedence(stack.Peek()))
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(tokens[i]);
            }
            else if (tokens[i] == "(")
            {
                stack.Push(tokens[i]);
            }
            else if (tokens[i] == ")")
            {
                if (!stack.Contains("(") || stack.Count == 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                while (stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();
                if (stack.Count > 0 && functions.Contains(stack.Peek())) 
                {
                    queue.Enqueue(stack.Pop());
                }
            }
        }
        while (stack.Count != 0)
        {
            if (brackets.Contains(stack.Peek()[0]))
            {
                throw new ArgumentException("Invalid brackets position!");
            }
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }
    static double CalculateResult(Queue<string> queue)
    {
        Stack<double> stack = new Stack<double>();

        while (queue.Count > 0)
        {
            string currentToken = queue.Dequeue();
            double num;

            if (double.TryParse(currentToken, out num))
            {
                stack.Push(num);
            }
            else if (arithmeticOperations.Contains(currentToken[0]) || functions.Contains(currentToken))
            {
                if (currentToken == "+")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double firstNum = stack.Pop();
                    double secondNum = stack.Pop();

                    stack.Push(firstNum + secondNum);
                }
                else if (currentToken == "-")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double firstNum = stack.Pop();
                    double secondNum = stack.Pop();

                    stack.Push(secondNum - firstNum);
                }
                else if (currentToken == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double firstNum = stack.Pop();
                    double secondNum = stack.Pop();

                    stack.Push(firstNum * secondNum);
                }
                else if (currentToken == "/")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double firstNum = stack.Pop();
                    double secondNum = stack.Pop();

                    stack.Push(secondNum / firstNum);
                }
                else if (currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double firstNum = stack.Pop();
                    double secondNum = stack.Pop();

                    stack.Push(Math.Pow(secondNum, firstNum));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double number = stack.Pop();

                    stack.Push(Math.Sqrt(number));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid Input!");
                    }

                    double number = stack.Pop();

                    stack.Push(Math.Log(number));
                }
            }
        }
        if (stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid Input");
        }
    }
    static int CheckPrecedence(string arithmeticOperator)
    {
        if (arithmeticOperator == "+" || arithmeticOperator == "-")
        {
            return 1;
        }
        return 2;
    }
}

