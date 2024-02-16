using CalculatorLibrary;

Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");
var endApp = false;
var calculator = new Calculator();
var appUsed = 0;

while (!endApp)
{
    Console.Write("Enter a number: ");
    var numInput1 = Console.ReadLine()?.Trim();
    double cleanNum1;
    while (!double.TryParse(numInput1, out cleanNum1))
    {
        Console.Write("This is not a valid number, please enter a number: ");
        numInput1 = Console.ReadLine()?.Trim();
    }

    Console.Write("Enter another number: ");
    var numInput2 = Console.ReadLine();
    double cleanNum2;
    while (!double.TryParse(numInput2, out cleanNum2))
    {
        Console.Write("This is not a valid entry, please enter a number: ");
        numInput2 = Console.ReadLine();
    }

    Console.WriteLine(@"Choose an operator from the following list: 
A - Add
S - Subtract
M - Multiply
D - Divide");
    Console.WriteLine("----------------------------------------------------------------------------");
    var op = Console.ReadLine()?.Trim().ToLower();

    try
    {
        var result = calculator.DoOperation(cleanNum1, cleanNum2, op);
        if (double.IsNaN(result))
                        Console.WriteLine("This operation will result in a mathematical error.\n");
        else
        {
            Console.WriteLine("your result: {0:0.##}\n", result);
            appUsed++;
            Console.WriteLine($"You've used the calculator {appUsed} times!");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
    }

    Console.WriteLine("------------------------\n");

    Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") endApp = true;

    Console.WriteLine("\n");
}
calculator.Finish();
        
