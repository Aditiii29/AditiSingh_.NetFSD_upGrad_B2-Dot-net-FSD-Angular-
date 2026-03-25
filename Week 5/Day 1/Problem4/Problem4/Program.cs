using System;

// Base Class
class Vehicle
{
    private double rentalRatePerDay;

    public string Brand { get; set; }

    // Property with validation
    public double RentalRatePerDay
    {
        get { return rentalRatePerDay; }
        set
        {
            if (value < 0)
                Console.WriteLine("Invalid rental rate");
            else
                rentalRatePerDay = value;
        }
    }

    // Virtual method
    public virtual double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid number of days");
            return 0;
        }

        return RentalRatePerDay * days;
    }
}

// Derived Class - Car
class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        double baseCost = base.CalculateRental(days);
        return baseCost + 500; // Insurance charge
    }
}

// Derived Class - Bike
class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        double baseCost = base.CalculateRental(days);
        return baseCost - (0.05 * baseCost); // 5% discount
    }
}

class Program
{
    static void Main()
    {
        // Polymorphism
        Vehicle v1 = new Car();
        v1.Brand = "Honda";
        v1.RentalRatePerDay = 2000;

        Vehicle v2 = new Bike();
        v2.Brand = "Yamaha";
        v2.RentalRatePerDay = 500;

        Console.WriteLine("Car Total Rental = " + v1.CalculateRental(3));
        Console.WriteLine("Bike Total Rental = " + v2.CalculateRental(3));
    }
}