
using System.Linq;

public class ConsoleCalculator
{
    public static void Main()
    {
        Console.WriteLine("Console Calculator in C#\r\n" + "Options\n" + "1. If you want to end, type 'end'\n");
        Console.WriteLine("------------------------\n");

        while (true)
        {
            Console.WriteLine("Enter numbers separated by space: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "end") break;

            string[] parts = input.Split(' ');
            double[] numbers = new double[parts.Length];
            bool validInput = true;

            for (int i = 0; i < parts.Length; i++)
            {
                if (!double.TryParse(parts[i], out numbers[i]))
                {
                    Console.WriteLine("Invalid input. Please enter numbers separated by space.");
                    validInput = false;
                    break;
                }
            }

            if (!validInput) continue;

            Console.WriteLine("Enter operators (+, -, *, /) separated by space: ");
            string operatorsInput = Console.ReadLine();
            string[] operators = operatorsInput.Split(' ');

            if (operators.Length != numbers.Length - 1)
            {
                Console.WriteLine("The number of operators must be one less than the number of numbers.");
                continue;
            }

            double result = numbers[0];
            bool validOperation = true;

            for (int i = 0; i < operators.Length; i++)
            {
                switch (operators[i])
                {
                    case "+":
                        result += numbers[i + 1];
                        break;
                    case "-":
                        result -= numbers[i + 1];
                        break;
                    case "*":
                        result *= numbers[i + 1];
                        break;
                    case "/":
                        if (numbers[i + 1] != 0)
                        {
                            result /= numbers[i + 1];
                        }
                        else
                        {
                            Console.WriteLine("Error: division by zero.");
                            validOperation = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator. Please enter one of the following operators: +, -, *, /.");
                        validOperation = false;
                        break;
                }

                if (!validOperation) break;
            }

            if (validOperation)
            {
                Console.WriteLine($"Result: {result}\n");
            }
        }

        Console.WriteLine("Calculator has finished working.");
    }
}