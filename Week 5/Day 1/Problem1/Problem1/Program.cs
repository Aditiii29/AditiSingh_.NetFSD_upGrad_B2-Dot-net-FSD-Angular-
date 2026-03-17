using System;

class BankAccount
{
    // Private fields
    private string accountNumber;
    private double balance;

    // Property for Account Number
    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    // Property for Balance (read-only outside)
    public double Balance
    {
        get { return balance; }
    }

    // Deposit method
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount");
        }
        else
        {
            balance += amount;
            Console.WriteLine("Deposited: " + amount);
            Console.WriteLine("Current Balance = " + balance);
        }
    }

    // Withdraw method
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
            Console.WriteLine("Current Balance = " + balance);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.AccountNumber = "ACC123";

        acc.Deposit(5000);
        acc.Withdraw(2000);

        Console.WriteLine("Final Balance = " + acc.Balance);
    }
}