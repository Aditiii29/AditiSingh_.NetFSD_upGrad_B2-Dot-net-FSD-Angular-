using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Marks list
        List<int> marks = new List<int> { 78, 85, 90, 67, 88 };

        int threshold = 80;

        // 1️⃣ Total (reduce equivalent)
        int total = marks.Sum();

        // 2️⃣ Average
        double average = marks.Average();

        // 3️⃣ Students above threshold (filter equivalent)
        var aboveThreshold = marks.Where(m => m > threshold).ToList();

        // 4️⃣ Highest score
        int highest = marks.Max();

        // 5️⃣ Dictionary (Map equivalent)
        List<string> subjects = new List<string>
        {
            "Math", "Science", "English", "History", "Computer"
        };

        Dictionary<string, int> subjectMap = new Dictionary<string, int>();

        for (int i = 0; i < marks.Count; i++)
        {
            subjectMap[subjects[i]] = marks[i];
        }

        // Output
        Console.WriteLine("Total Marks: " + total);
        Console.WriteLine("Average Marks: " + average);
        Console.WriteLine("Students above " + threshold + ": " + aboveThreshold.Count);
        Console.WriteLine("Highest Score: " + highest);

        Console.WriteLine("\nSubject-wise Marks:");
        foreach (var item in subjectMap)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }
}