using System;

namespace Day_2
{
    // 1. Interface (OCP)
    interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // 2. Regular Discount
    class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05;
        }
    }

    // 3. Premium Discount
    class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }

    // 4. VIP Discount
    class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }

    // 5. Price Calculator (Uses Strategy)
    class PriceCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy strategy)
        {
            double discount = strategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    // 6. Main Program
    class Problem2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine("\nSelect Customer Type:");
            Console.WriteLine("1. Regular");
            Console.WriteLine("2. Premium");
            Console.WriteLine("3. VIP");

            int choice = int.Parse(Console.ReadLine());

            IDiscountStrategy strategy = null;

            if (choice == 1)
                strategy = new RegularCustomerDiscount();
            else if (choice == 2)
                strategy = new PremiumCustomerDiscount();
            else if (choice == 3)
                strategy = new VipCustomerDiscount();
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            PriceCalculator calculator = new PriceCalculator();
            double finalPrice = calculator.GetFinalPrice(amount, strategy);

            Console.WriteLine("\nFinal Price: " + finalPrice);
        }
    }
}