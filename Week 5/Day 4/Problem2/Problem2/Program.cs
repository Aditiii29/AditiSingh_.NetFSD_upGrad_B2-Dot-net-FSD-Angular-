using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();

        try
        {
            // Check if directory exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Error: Directory does not exist.");
                return;
            }

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] files = dir.GetFiles();

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in the directory.");
                return;
            }

            Console.WriteLine("\nFile Details:\n");

            foreach (FileInfo file in files)
            {
                Console.WriteLine($"Name: {file.Name}");
                Console.WriteLine($"Size: {file.Length} bytes");
                Console.WriteLine($"Created On: {file.CreationTime}");
                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine($"\nTotal Files: {files.Length}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied to this folder.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("\nOperation completed.");
        }
    }
}