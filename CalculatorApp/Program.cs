Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

Console.WriteLine("Type a number, and then press Enter");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Type another number, and then press Enter");
double num2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($@"Choose an option from the following list: 
A - Add
S - Subtract
M - Multiply
D - Divide");
Console.WriteLine("---------------------------------------------");

switch (Console.ReadLine()?.Trim().ToUpper())
{
    case "A":
        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
        break;
    case "S":
        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 - num2));
        break;
    case "M":
        Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
        break;
    case "D":
        while (num2 == 0)
        {
            Console.WriteLine("Enter a non-zero divisor");
            num2 = Convert.ToDouble(Console.ReadLine());
        }
        Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
        break;
    //default:
    //    Console.WriteLine("Invalid entry, please make a selection");
    //    Thread.Sleep(2000);
    //    break;
}

Console.WriteLine("Press any key to close the Calculator console app");
Console.ReadKey();