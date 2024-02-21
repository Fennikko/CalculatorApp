using CalculatorLibrary;

public class Menu
{
//    public void FirstRun(Calculator calculator)
//    {
//        Console.Clear();
//        Console.WriteLine("Console Calculator in C#\r");
//        Console.WriteLine("------------------------\n");

//        Console.Write("Enter a number: ");
//        var numberInput1 = Console.ReadLine()?.Trim();
//        var cleanNumber1 = Calculator.ValidateNumbers(numberInput1);

//        Console.Write("Enter another number: ");
//        var numberInput2 = Console.ReadLine();
//        var cleanNumber2 = Calculator.ValidateNumbers(numberInput2);

//        Console.WriteLine(@"Choose an operator from the following list: 
//A - Add
//S - Subtract
//M - Multiply
//D - Divide");
//        Console.WriteLine("----------------------------------------------------------------------------");
//        var op = Console.ReadLine()?.Trim().ToLower();

//        try
//        {
//            var result = calculator.DoOperation(op);
//            if (double.IsNaN(result))
//                Console.WriteLine("This operation will result in a mathematical error.\n");
//            else
//            {
//                Console.WriteLine("your result: {0:0.##}\n", result);
//            }
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
//        }
//    }

//    public void NotFirstRun(Calculator calculator)
//    {
//        Console.Clear();
//        Console.WriteLine("Console Calculator in C#\r");
//        Console.WriteLine("------------------------\n");
//        var calculations = CalculationDataStore.Results;
//        var lastCalculation = calculations.LastOrDefault()!;
//        var anotherRunEngaged = true;

//        while (anotherRunEngaged)
//        {
//            Console.Clear();
//            Console.WriteLine("Console Calculator in C#\r");
//            Console.WriteLine("------------------------\n");

//            Console.Write($"Your last calculation was {lastCalculation}, would you like to use this number in your next calculation? y/n: ");

//            switch (Console.ReadKey().Key)
//            {
//                case ConsoleKey.Y:
//                    {
//                        Console.Clear();
//                        Console.WriteLine("Console Calculator in C#\r");
//                        Console.WriteLine("------------------------\n");
//                        var cleanNumber1 = lastCalculation;

//                        Console.Write("Enter another number: ");
//                        var numberInput2 = Console.ReadLine();
//                        var cleanNumber2 = Calculator.ValidateNumbers(numberInput2);

//                        Console.WriteLine(@"Choose an operator from the following list: 
//A - Add
//S - Subtract
//M - Multiply
//D - Divide");
//                        Console.WriteLine("----------------------------------------------------------------------------");
//                        var op = Console.ReadLine()?.Trim().ToLower();

//                        try
//                        {
//                            var result = calculator.DoOperation(op);
//                            if (double.IsNaN(result))
//                                Console.WriteLine("This operation will result in a mathematical error.\n");
//                            else
//                            {
//                                Console.WriteLine("your result: {0:0.##}\n", result);
//                            }
//                        }
//                        catch (Exception e)
//                        {
//                            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
//                        }

//                        anotherRunEngaged = false;
//                    }
//                    break;
//                case ConsoleKey.N:
//                    {
//                        Console.Clear();
//                        Console.WriteLine("Console Calculator in C#\r");
//                        Console.WriteLine("------------------------\n");
//                        CalculationDataStore.Results.Clear();

//                        Console.Write("Enter a number: ");
//                        var numberInput1 = Console.ReadLine()?.Trim();
//                        var cleanNumber1 = Calculator.ValidateNumbers(numberInput1);

//                        Console.Write("Enter another number: ");
//                        var numberInput2 = Console.ReadLine();
//                        var cleanNumber2 = Calculator.ValidateNumbers(numberInput2);

//                        Console.WriteLine(@"Choose an operator from the following list: 
//A - Add
//S - Subtract
//M - Multiply
//D - Divide");
//                        Console.WriteLine("----------------------------------------------------------------------------");
//                        var op = Console.ReadLine()?.Trim().ToLower();

//                        try
//                        {
//                            var result = calculator.DoOperation(op);
//                            if (double.IsNaN(result))
//                                Console.WriteLine("This operation will result in a mathematical error.\n");
//                            else
//                            {
//                                Console.WriteLine("your result: {0:0.##}\n", result);
//                            }
//                        }
//                        catch (Exception e)
//                        {
//                            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
//                        }

//                        anotherRunEngaged = false;
//                    }
//                    break;
//                default:
//                    Console.Clear();
//                    Console.WriteLine("Console Calculator in C#\r");
//                    Console.WriteLine("------------------------\n");
//                    Console.WriteLine("Invalid entry, press any key to continue");
//                    Console.ReadKey();
//                    break;
//            }
//        }


//    }
}