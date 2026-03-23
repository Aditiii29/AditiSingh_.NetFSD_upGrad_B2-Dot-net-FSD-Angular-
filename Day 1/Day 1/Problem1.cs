using System;
using System.Threading.Tasks;

namespace AsyncLoggingApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application started...\n");

            try
            {
                // Calling async logging multiple times
                Task t1 = WriteLogAsync("User logged in");
                Task t2 = WriteLogAsync("File uploaded");
                Task t3 = WriteLogAsync("Data processed");

                // Main thread continues working
                Console.WriteLine("Main thread is free to do other work...\n");

                // Wait for all logging tasks to complete
                await Task.WhenAll(t1, t2, t3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nAll logging operations completed.");
            }
        }

        // Async method to simulate file writing
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");

            // Simulate file I/O delay
            await Task.Delay(2000);

            Console.WriteLine($"Log written: {message}");
        }
    }
}