public class Program
{
    public static void Main()
    {
        string expression = "3 5 +"; // Пример выражения в польской форме
        double result = CalculateExpression(expression);
        Console.WriteLine("Результат: " + result);
    }

    public static double CalculateExpression(string expression)
    {
        string[] tokens = expression.Split(' ');
        Stack<double> stack = new Stack<double>();

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double operand))
            {
                stack.Push(operand);
            }
            else
            {
                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Недостаточно операндов для операции.");
                }

                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                double result = PerformOperation(token, operand1, operand2);
                stack.Push(result);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Неверное выражение.");
        }

        return stack.Pop();
    }

    static double PerformOperation(string operation, double operand1, double operand2)
    {
        switch (operation)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                {
                    throw new InvalidOperationException("Деление на ноль.");
                }
                return operand1 / operand2;
            default:
                throw new ArgumentException("Недопустимая операция: " + operation);
        }
    }
}