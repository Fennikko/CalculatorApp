using CalculatorLibrary;


var endApp = false;
var calculator = new Calculator();
var appUsed = 0;
var menu = new Menu();

//while (!endApp)
//{
//    if (appUsed == 0)
//    {
//        menu.FirstRun(calculator);
//        appUsed++;

//        Console.WriteLine("------------------------\n");

//        Console.Write("Press 'n' to close the app, or press any other key to continue: ");
//        if (Console.ReadKey().Key == ConsoleKey.N) endApp = true;

//        Console.WriteLine("\n");
//    }
//    else
//    {
//        menu.NotFirstRun(calculator);
//        appUsed++;

//        Console.WriteLine("------------------------\n");

//        Console.Write("Press 'n' to close the app, or press any other key to continue: ");
//        if (Console.ReadKey().Key == ConsoleKey.N) endApp = true;
//    }

//}

calculator.Division();
calculator.Finish();