namespace CalculatorLibrary.Models;

public class CalculatorData
    {
        public DateTime Date { get; set; }
        public double CalculatedResult { get; set; }
        public CalculationType Type { get; set; }
    }

    public enum CalculationType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }