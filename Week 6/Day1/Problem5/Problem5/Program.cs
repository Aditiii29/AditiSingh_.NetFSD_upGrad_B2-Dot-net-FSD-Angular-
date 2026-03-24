using System;
using System.Diagnostics;

namespace OrderTracingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure trace to write to file
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("traceLog.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();

                Trace.TraceInformation("Order processed successfully.");
                Console.WriteLine("\nOrder completed successfully!");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine("Order processing failed!");
            }
            finally
            {
                Trace.Flush();
                Trace.Close();
            }
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating order...");
            Console.WriteLine("Validating order...");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing payment...");
            Console.WriteLine("Processing payment...");

            // Simulate error (for debugging demo)
            // Uncomment to test failure
            // throw new Exception("Payment failed!");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating inventory...");
            Console.WriteLine("Updating inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating invoice...");
            Console.WriteLine("Generating invoice...");
        }
    }
}