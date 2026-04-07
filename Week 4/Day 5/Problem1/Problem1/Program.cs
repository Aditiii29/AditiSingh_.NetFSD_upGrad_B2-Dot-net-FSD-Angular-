using System;

class BankAccount
{
    // Private field
    private double balance;

    // Deposit method
    public void Deposit(double amount)
    {
        balance += amount;
    }

    // Withdraw method
    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            balance -= amount;
        }
    }

    // GetBalance method
    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.Deposit(1000);
        account.Withdraw(300);

        Console.WriteLine("Current Balance = " + account.GetBalance());
    }
}
