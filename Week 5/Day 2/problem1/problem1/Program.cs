using System;
using System.Collections.Generic;
using System.Linq;

// Define Record
public record Student(int RollNo, string Name, string Course, int Marks);

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DisplayStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 4);
    }

    // Add Student
    static void AddStudent()
    {
        try
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            if (students.Any(s => s.RollNo == roll))
            {
                Console.WriteLine("Roll Number already exists!");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Marks must be between 0 and 100!");
                return;
            }

            students.Add(new Student(roll, name, course, marks));
            Console.WriteLine("Student added successfully!");
        }
        catch
        {
            Console.WriteLine("Invalid input! Please try again.");
        }
    }

    // Display Students
    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nStudent Records:");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    // Search Student
    static void SearchStudent()
    {
        Console.Write("Enter Roll Number to search: ");
        int roll;

        if (!int.TryParse(Console.ReadLine(), out roll))
        {
            Console.WriteLine("Invalid Roll Number!");
            return;
        }

        var student = students.FirstOrDefault(s => s.RollNo == roll);

        if (student != null)
        {
            Console.WriteLine("\nStudent Found:");
            Console.WriteLine($"Roll No: {student.RollNo} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
