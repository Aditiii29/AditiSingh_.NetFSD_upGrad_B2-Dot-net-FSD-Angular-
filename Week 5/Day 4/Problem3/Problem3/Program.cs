using System;

namespace EmployeePerformanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Monthly Sales Amount: ");
                double sales = double.Parse(Console.ReadLine());

                Console.Write("Enter Customer Feedback Rating (1-5): ");
                int rating = int.Parse(Console.ReadLine());

                // Input validation
                if (sales < 0 || rating < 1 || rating > 5)
                {
                    Console.WriteLine("Invalid input! Please enter valid values.");
                    return;
                }

                // Get tuple result
                var (empSales, empRating) = GetEmployeeData(sales, rating);

                // Pattern Matching using switch expression
                string performance = (empSales, empRating) switch
                {
                    ( >= 100000, >= 4) => "High Performer",
                    ( >= 50000, >= 3) => "Average Performer",
                    _ => "Needs Improvement"
                };

                // Output
                Console.WriteLine("\n--- Employee Performance ---");
                Console.WriteLine($"Employee Name: {name}");
                Console.WriteLine($"Sales Amount: {empSales}");
                Console.WriteLine($"Rating: {empRating}");
                Console.WriteLine($"Performance: {performance}");
            }
            catch
            {
                Console.WriteLine("Error: Please enter valid numeric inputs.");
            }
        }

        // Method returning Tuple
        static (double, int) GetEmployeeData(double sales, int rating)
        {
            return (sales, rating);
        }
    }
}