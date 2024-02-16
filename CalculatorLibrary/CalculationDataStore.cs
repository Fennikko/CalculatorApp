using CalculatorLibrary.Models;

namespace CalculatorLibrary;

public class CalculationDataStore
{
    public static List<CalculatorData> Data = [];

    public void AddToHistory(double result, CalculationType calculationType)
    {
        Data.Add(new CalculatorData
        {
            Date = DateTime.Now,
            CalculatedResult = result,
            Type = calculationType
        });
    }
}