using System;
using System.IO;

namespace DirectoryAnalyzerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            try
            {
                // Validate directory
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Error: Directory does not exist.");
                    return;
                }

                DirectoryInfo rootDir = new DirectoryInfo(path);

                // Get all subdirectories
                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                Console.WriteLine("\n--- Directory Analysis ---\n");

                // Loop through each directory
                foreach (DirectoryInfo dir in subDirs)
                {
                    // Get files inside each directory
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine($"Folder: {dir.Name}");
                    Console.WriteLine($"Number of Files: {files.Length}");
                    Console.WriteLine("-----------------------------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access denied to this directory.");
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
}