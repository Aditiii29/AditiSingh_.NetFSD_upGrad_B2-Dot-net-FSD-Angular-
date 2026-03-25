using System;
using System.Threading.Tasks;

namespace EcommerceOrderApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order processing started...\n");

            try
            {
                await ProcessOrderAsync();

                Console.WriteLine("\nOrder completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Main workflow
        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        // Step 1
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000); // simulate delay
            Console.WriteLine("Payment verified ✔");
        }

        // Step 2
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(2000);
            Console.WriteLine("Inventory available ✔");
        }

        // Step 3
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(2000);
            Console.WriteLine("Order confirmed ✔");
        }
    }
}