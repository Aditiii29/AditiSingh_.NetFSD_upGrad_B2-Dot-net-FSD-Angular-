using System;

namespace Day_2
{
    // Interfaces (Top of Diagram)
    interface IPrinter
    {
        void Print();
    }

    interface IScanner
    {
        void Scan();
    }

    interface IFax
    {
        void Fax();
    }

    // BasicPrinter → Only Print (Left box in diagram)
    class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("BasicPrinter: Printing...");
        }
    }

    // AdvancedPrinter → Print + Scan + Fax (Right box in diagram)
    class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("AdvancedPrinter: Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("AdvancedPrinter: Scanning...");
        }

        public void Fax()
        {
            Console.WriteLine("AdvancedPrinter: Faxing...");
        }
    }

    // Main Class
    class Problem4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Printer Type:");
            Console.WriteLine("1. Basic Printer");
            Console.WriteLine("2. Advanced Printer");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                IPrinter printer = new BasicPrinter();
                printer.Print();
            }
            else if (choice == 2)
            {
                AdvancedPrinter adv = new AdvancedPrinter();
                adv.Print();
                adv.Scan();
                adv.Fax();
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }
}