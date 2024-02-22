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
        public void JsonWriter(double firstNumber, double? secondNumber, double result, string operationType)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(firstNumber);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(secondNumber);
            writer.WritePropertyName("Operation");
            writer.WriteValue(operationType);
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
            case "sqrt":
                SquareRoot();
                break;
            case "p":
                PowerOf();
                break;
            case "p10":
                PowerOfTen();
                break;
            case "t":
                Trigonometry();
                break;

            default:
                break;
        }
    }

    public void CalculatorHeader()
    {
        Console.Clear();
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");
    }

    public double ValidateNumbers(string? number)
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

    double GetFirstNumber()
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
                        Console.Write("Enter a number: ");
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
            Console.Write("Enter a number: ");
            var firstNumber = Console.ReadLine()?.Trim().ToLower();
            cleanFirstNumber = ValidateNumbers(firstNumber);
        }

        return cleanFirstNumber;
    }

    void DisplayResults(double result, double cleanFirstNumber, double? cleanSecondNumber,string operationType)
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
                JsonWriter(cleanFirstNumber, cleanSecondNumber, result, operationType);
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
        var operationType = "Add";
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber + cleanSecondNumber;
        DisplayResults(result,cleanFirstNumber,cleanSecondNumber, operationType);
        return result;
    }
    public double Subtraction()
    {
        var operationType = "Subtract";
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber - cleanSecondNumber;
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber, operationType);
        return result;
    }
    public double Multiplication()
    {
        var operationType = "Multiply";
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = cleanFirstNumber * cleanSecondNumber;
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber, operationType);
        return result;
    }
    public double Division()
    {
        var operationType = "Divide";
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
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber, operationType);
        return result;
    }

    public double SquareRoot()
    {
        var operationType = "Square Root";
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        double? secondNumberPlaceHolder = null;
        CalculatorHeader();
        result = Math.Sqrt(cleanFirstNumber);
        DisplayResults(result,cleanFirstNumber,secondNumberPlaceHolder, operationType);
        return result;
    }

    public double PowerOf()
    {
        var operationType = "Power of";
        double result = double.NaN;
        var cleanFirstNumber = GetFirstNumber();
        CalculatorHeader();
        Console.Write("Enter your second number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = Math.Pow(cleanFirstNumber, cleanSecondNumber);
        DisplayResults(result,cleanFirstNumber,cleanSecondNumber,operationType);
        return result;
    }

    public double PowerOfTen()
    {
        var operationType = "Power of 10";
        double result = double.NaN;
        var cleanFirstNumber = 10;
        CalculatorHeader();
        Console.Write("Enter your number: ");
        var secondNumber = Console.ReadLine()?.Trim().ToLower();
        var cleanSecondNumber = ValidateNumbers(secondNumber);
        result = Math.Pow(cleanFirstNumber, cleanSecondNumber);
        DisplayResults(result, cleanFirstNumber, cleanSecondNumber, operationType);
        return result;
    }

    public double Trigonometry()
    {
        var operationType = "";
        double result = double.NaN;
        var trigRunning = true;
        var cleanFirstNumber = GetFirstNumber();
        double? secondNumberPlaceHolder = null;
        double radians = cleanFirstNumber * Math.PI / 180;
        while (trigRunning)
        {
            CalculatorHeader();
            Console.WriteLine($@"Choose your trigonometry function from the list below: 
sin - Sine
cos - Cosine
tan - Tangent
cot - Cotangent
sec - Secant
csc - Cosecant");
            Console.WriteLine("--------------------------------------------------------");
            var trigSelection = Console.ReadLine()?.Trim().ToLower();
            switch (trigSelection)
            {
                case "sin":
                {
                    operationType = "Sine";
                    result = Math.Sin(radians);
                    trigRunning = false;
                } break;
                case "cos":
                {
                    operationType = "Cosine";
                    result = Math.Cos(radians);
                    trigRunning = false;
                } break;
                case "tan":
                {
                    operationType = "Tangent";
                    result = Math.Tan(radians);
                    trigRunning = false;
                } break;
                case "cot":
                {
                    operationType = "Cotangent";
                    result = 1 / Math.Tan(radians);
                    trigRunning = false;
                } break;
                case "sec":
                {
                    operationType = "Secant";
                    result = 1 / Math.Cos(radians);
                    trigRunning = false;
                } break;
                case "csc":
                {
                    operationType = "Cosecant";
                    result = 1 / Math.Sin(radians);
                    trigRunning = false;
                } break;
                default:
                {
                    Console.WriteLine("Invalid selection, please select a trigonometry function");
                    Thread.Sleep(3000);
                    continue;
                }

            }
        }
        DisplayResults(result, cleanFirstNumber, secondNumberPlaceHolder, operationType);

        return result;

    }
}