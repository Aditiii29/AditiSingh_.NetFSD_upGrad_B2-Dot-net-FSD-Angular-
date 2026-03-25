using System;
using System.IO;

namespace DriveMonitorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get all system drives
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("\n--- Drive Information ---\n");

                foreach (DriveInfo drive in drives)
                {
                    // Ensure drive is ready
                    if (drive.IsReady)
                    {
                        double totalSizeGB = drive.TotalSize / (1024.0 * 1024 * 1024);
                        double freeSpaceGB = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);

                        double freePercentage = (drive.AvailableFreeSpace * 100.0) / drive.TotalSize;

                        Console.WriteLine($"Drive Name: {drive.Name}");
                        Console.WriteLine($"Drive Type: {drive.DriveType}");
                        Console.WriteLine($"Total Size: {totalSizeGB:F2} GB");
                        Console.WriteLine($"Free Space: {freeSpaceGB:F2} GB");

                        // Warning condition
                        if (freePercentage < 15)
                        {
                            Console.WriteLine("⚠ Warning: Low disk space!");
                        }

                        Console.WriteLine("-----------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Drive {drive.Name} is not ready.");
                        Console.WriteLine("-----------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nDrive check completed.");
            }
        }
    }
}