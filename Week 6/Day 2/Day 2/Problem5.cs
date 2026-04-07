using System;

namespace Day_2
{
    // Singleton Class
    class ConfigurationManager
    {
        // 1. Static instance (only one)
        private static ConfigurationManager instance;

        // 2. Lock object (for thread safety)
        private static readonly object lockObj = new object();

        // 3. Private constructor (no external object creation)
        private ConfigurationManager()
        {
            ApplicationName = "InventoryApp";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
        }

        // Properties
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string DatabaseConnectionString { get; set; }

        // 4. GetInstance() method
        public static ConfigurationManager GetInstance()
        {
            // Thread-safe Singleton
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
            }
            return instance;
        }
    }

    // Main Class
    class Problem5
    {
        static void Main(string[] args)
        {
            // First call
            ConfigurationManager config1 = ConfigurationManager.GetInstance();

            Console.WriteLine("First Call:");
            Console.WriteLine("App Name: " + config1.ApplicationName);
            Console.WriteLine("Version: " + config1.Version);
            Console.WriteLine("DB: " + config1.DatabaseConnectionString);

            Console.WriteLine("\n------------------\n");

            // Second call
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            Console.WriteLine("Second Call:");
            Console.WriteLine("App Name: " + config2.ApplicationName);
            Console.WriteLine("Version: " + config2.Version);
            Console.WriteLine("DB: " + config2.DatabaseConnectionString);

            // Check same instance
            Console.WriteLine("\nAre both instances same? " + (config1 == config2));
        }
    }
}