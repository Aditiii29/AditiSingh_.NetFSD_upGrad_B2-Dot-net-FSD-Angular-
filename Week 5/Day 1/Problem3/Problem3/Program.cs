using System;

// Base Class
class Product
{
    private double price; // encapsulated field

    public string Name { get; set; }

    // Property with validation
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Price cannot be negative");
            }
            else
            {
                price = value;
            }
        }
    }

    // Virtual method
    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

// Derived Class - Electronics
class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (0.05 * Price); // 5% discount
    }
}

// Derived Class - Clothing
class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (0.15 * Price); // 15% discount
    }
}

class Program
{
    static void Main()
    {
        // Polymorphism
        Product p1 = new Electronics();
        p1.Name = "Laptop";
        p1.Price = 20000;

        Product p2 = new Clothing();
        p2.Name = "T-Shirt";
        p2.Price = 2000;

        Console.WriteLine("Electronics Final Price after 5% discount = " + p1.CalculateDiscount());
        Console.WriteLine("Clothing Final Price after 15% discount = " + p2.CalculateDiscount());
    }
}