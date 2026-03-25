using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "log.txt";

        try
        {
            while (true)
            {
                Console.Write("Enter message (type 'exit' to stop): ");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                    break;

                // Convert string to byte array
                byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                // FileStream for append mode
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message written successfully!\n");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access to the file is denied.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("File Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("File operation completed.");
        }
    }
}