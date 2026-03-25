using System;

class ResultAnalyzer
{
    // Method using out parameters
    public static void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
    {
        totalMarks = m1 + m2 + m3;
        averageMarks = totalMarks / 3.0;
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter marks for Subject 1: ");
            int m1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter marks for Subject 2: ");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter marks for Subject 3: ");
            int m3 = Convert.ToInt32(Console.ReadLine());

            // Input validation
            if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
            {
                Console.WriteLine("Invalid marks. Please enter values between 0 and 100.");
                continue;
            }

            int total;
            double average;

            // Calling method
            ResultAnalyzer.CalculateResult(m1, m2, m3, out total, out average);

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average);

            string result = average >= 40 ? "Pass" : "Fail";
            Console.WriteLine("Result: " + result);

            Console.Write("Analyze another student? (y/n): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() != "y")
                break;
        }
    }
}