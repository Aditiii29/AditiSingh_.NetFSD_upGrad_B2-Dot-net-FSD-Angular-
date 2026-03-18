using System;

// Custom Exception Class
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

// BankAccount Class
class BankAccount
{
    private double balance;

    public BankAccount(double balance)
    {
        this.balance = balance;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
        }

        balance -= amount;
        Console.WriteLine("Withdrawal successful. Remaining Balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdraw Amount: ");
            double amount = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(balance);
            account.Withdraw(amount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction process completed.");
        }

        Console.WriteLine("Program continues...");
    }
}
