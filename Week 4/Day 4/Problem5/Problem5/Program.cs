using System;

class PowerCalculator
{
    // Recursive method
    public static int CalculatePower(int baseNum, int exponent)
    {
        // Base case
        if (exponent == 0)
            return 1;

        // Recursive call
        return baseNum * CalculatePower(baseNum, exponent - 1);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Base: ");
        int baseNum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Exponent: ");
        int exponent = Convert.ToInt32(Console.ReadLine());

        if (exponent < 0)
        {
            Console.WriteLine("Exponent must be a positive integer.");
            return;
        }

        int result = PowerCalculator.CalculatePower(baseNum, exponent);

        Console.WriteLine("Base: " + baseNum);
        Console.WriteLine("Exponent: " + exponent);
        Console.WriteLine("Result: " + result);
    }
}