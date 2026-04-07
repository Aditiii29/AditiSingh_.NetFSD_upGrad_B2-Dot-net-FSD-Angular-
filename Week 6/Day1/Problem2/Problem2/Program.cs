using System;

namespace DiscountDebugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Enter Discount Percentage: ");
                double discount = double.Parse(Console.ReadLine());

                // Correct formula
                double discountAmount = (price * discount) / 100;
                double finalPrice = price - discountAmount;

                Console.WriteLine("\n--- Final Details ---");
                Console.WriteLine($"Product: {name}");
                Console.WriteLine($"Original Price: {price}");
                Console.WriteLine($"Discount: {discount}%");
                Console.WriteLine($"Final Price: {finalPrice}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}