using System;

class Calculator
{
    // Method for addition
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method for subtraction
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter First Number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        // Create object of Calculator
        Calculator calc = new Calculator();

        // Call methods
        int addition = calc.Add(num1, num2);
        int subtraction = calc.Subtract(num1, num2);

        // Display results
        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}