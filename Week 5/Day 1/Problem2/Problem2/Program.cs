using System;

// Base Class
class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    // Virtual method
    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

// Derived Class - Manager
class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (0.20 * BaseSalary); // 20% bonus
    }
}

// Derived Class - Developer
class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (0.10 * BaseSalary); // 10% bonus
    }
}

class Program
{
    static void Main()
    {
        double baseSalary = 50000;

        // Polymorphism (base class reference)
        Employee emp1 = new Manager();
        emp1.BaseSalary = baseSalary;

        Employee emp2 = new Developer();
        emp2.BaseSalary = baseSalary;

        Console.WriteLine("Manager Salary = " + emp1.CalculateSalary());
        Console.WriteLine("Developer Salary = " + emp2.CalculateSalary());
    }
}