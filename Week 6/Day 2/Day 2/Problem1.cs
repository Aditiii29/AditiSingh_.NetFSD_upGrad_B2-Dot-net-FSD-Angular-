using System;

namespace Day_2
{
    class Problem1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Student {i + 1} ---");

                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Marks: ");
                double marks = double.Parse(Console.ReadLine());

                string result = marks >= 50 ? "Pass" : "Fail";

                Console.WriteLine("\nResult:");
                Console.WriteLine("ID: " + id);
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Marks: " + marks);
                Console.WriteLine("Result: " + result);
                Console.WriteLine("----------------------");
            }
        }
    }
}