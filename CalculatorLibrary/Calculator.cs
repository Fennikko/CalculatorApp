using Newtonsoft.Json;
namespace CalculatorLibrary;
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText(@"c:\temp\calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operation");
            writer.WriteStartArray();
        }
        public void JsonWriter(double firstNumber, double secondNumber, double result)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(firstNumber);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(secondNumber);
            writer.WritePropertyName("Operation");
            writer.WriteValue("Add");
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }


    public void DoOperation(string? op)
    {
        switch (op)
        {
            case "a":
                Addition();
                break;
            case "s":
                Subtraction();
                break;
            case "m":
                Multiplication();
                break;
            case "d":
                Division();
                break;
            default:
                break;
        }
    }

    public static void CalculatorHeader()
    {
        Console.Clear();
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
    }

    public static double ValidateNumbers(string? number)
    {
        double cleanNumber;
        while (!double.TryParse(number, out cleanNumber))
        {
            CalculatorHeader();
            Console.Write("Invalid entry, please enter a number: ");
            number = Console.ReadLine();
        }
        return cleanNumber;
    }

    static double GetFirstNumber()
    {
        var calculations = CalculationDataStore.Results;
        var lastCalculation = calculations.LastOrDefault()!;
        double cleanFirstNumber = double.NaN;

        if (!double.IsNaN(lastCalculation) && calculations.Count != 0)
        {
            while (double.IsNaN(cleanFirstNumber))
            {
                CalculatorHeader();
                Console.Write($"Your last calculation was {lastCalculation}, would you like to use this number in your next calculation? y/n: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                    {
                        cleanFirstNumber = lastCalculation;

                    }
                        break;
                    case ConsoleKey.N:
                    {
                        CalculatorHeader();
                        Console.Write("Enter your first number: ");
                        var firstNumber = Console.ReadLine()?.Trim().ToLower();
                        cleanFirstNumber = ValidateNumbers(firstNumber);
                    }
                        break;
                }
            }
        }
        else
        {
            CalculatorHeader();
            Console.Write("Enter your first number: ");
            var firstNumber = Console.ReadLine()?.Trim().ToLower();
            cleanFirstNumber = ValidateNumbers(firstNumber);
        }

        return cleanFirstNumber;
    }

    void DisplayResults(double result, double cleanFirstNumber, double cleanSecondNumber)
    {
        try
        {
            if (double.IsNaN(result))
            {
                CalculatorHeader();
                Console.WriteLine("This operation will result in a mathematical error. \n");

            }
            else
            {
                CalculatorHeader();
                Console.WriteLine("Your result: {0:0.##}\n", result);
                CalculationDataStore.AddLastCalculation(result);
                JsonWriter(cleanFirstNumber, cleanSecondNumber, result);
            }
        }
        catch (Exception e)
        {
            CalculatorHeader();
            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
        }

    }

    public double Addition()
    {
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber + cleanSecondNumber;
        DisplayResults(result,cleanFirstNumber,cleanSecondNumber);
        return result;
    }
    public double Subtraction()
    {
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber - cleanSecondNumber;
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber);
        return result;
    }
    public double Multiplication()
    {
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber * cleanSecondNumber;
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber);
        return result;
    }
    public double Division()
    {
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        while (cleanSecondNumber == 0)
        {
            CalculatorHeader();
            Console.Write("Second number cannot be zero, please enter your second number: ");
            secondNumber = Console.ReadLine()?.Trim().ToLower();
            cleanSecondNumber = ValidateNumbers(secondNumber);
        }
        result = cleanFirstNumber / cleanSecondNumber;
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber);
        return result;
    }

}