using System;

Console.Write("Enter Name: ");
string name = Console.ReadLine();

Console.Write("Enter Salary: ");
double salary = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter Experience (years): ");
int experience = Convert.ToInt32(Console.ReadLine());

double bonusPercent;

// Determine bonus percentage using if-else
if (experience < 2)
{
    bonusPercent = 0.05;
}
else if (experience <= 5)
{
    bonusPercent = 0.10;
}
else
{
    bonusPercent = 0.15;
}

// Calculate bonus using ternary operator
double bonus = salary > 0 ? salary * bonusPercent : 0;

double finalSalary = salary + bonus;

Console.WriteLine("Employee: " + name);
Console.WriteLine("Bonus: " + bonus.ToString("C"));
Console.WriteLine("Final Salary: " + finalSalary.ToString("C"));