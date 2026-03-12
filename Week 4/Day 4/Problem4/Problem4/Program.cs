using System;

class OrderCalculator
{
    // Method with optional parameters
    public static double CalculateFinalAmount(double price, int quantity, double discountPercent = 0, double shippingCharge = 50)
    {
        double subtotal = price * quantity;
        double discount = subtotal * discountPercent / 100;
        double amountAfterDiscount = subtotal - discount;
        double finalAmount = amountAfterDiscount + shippingCharge;

        Console.WriteLine("Subtotal: " + subtotal);
        Console.WriteLine("Discount Applied: " + discount);
        Console.WriteLine("Shipping Charge: " + shippingCharge);
        Console.WriteLine("Final Amount: " + finalAmount);

        return finalAmount;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Product Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\n--- Order with Default Discount and Shipping ---");
        OrderCalculator.CalculateFinalAmount(price, quantity);

        Console.WriteLine("\n--- Order with Discount Only ---");
        OrderCalculator.CalculateFinalAmount(price, quantity, 10);

        Console.WriteLine("\n--- Order with Discount and Custom Shipping ---");
        OrderCalculator.CalculateFinalAmount(price, quantity, 10, 20);
    }
}