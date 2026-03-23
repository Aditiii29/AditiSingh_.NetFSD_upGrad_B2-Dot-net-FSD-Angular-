using System;

namespace DiscountCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = double.Parse(Console.ReadLine());

            // Correct formula
            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("\n--- Final Details ---");
            Console.WriteLine($"Product: {name}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: {finalPrice}");
        }
    }
}