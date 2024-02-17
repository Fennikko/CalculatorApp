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
        public double DoOperation(double number1, double number2, string? op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(number1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(number2);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = number1 + number2;
                    CalculationDataStore.AddLastCalculation(result);
                    var calculations = CalculationDataStore.Results;
                    foreach (var calculation in calculations)
                    {
                        Console.WriteLine($"{calculation}");
                    }
                    var lastCalculation = calculations.LastOrDefault();
                    Console.WriteLine($"The last calculation done is: {lastCalculation}");
                    Console.WriteLine("Would you like to empty the list?");
                    var input = Console.ReadLine();
                    if (input == "y")
                        CalculationDataStore.Results.Clear();
                    writer.WriteValue("Add");
                    Console.ReadKey();
                    break;
                case "s":
                    result = number1 - number2;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = number1 * number2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (number2 != 0)
                    {
                        result = number1 / number2;
                    }
                    writer.WriteValue("Divide");
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
            return result;
        }

        public static double ValidateNumbers(string? number)
        {
            double cleanNumber;
            while (!double.TryParse(number, out cleanNumber))
            {
                Console.Write("Invalid entry, please enter a number: ");
                number = Console.ReadLine();
            }
            return cleanNumber;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }