using System;

// Strategy interface
interface IStrategy
{
    void Execute();
}

// Concrete Payment Strategy
class PaymentStrategy : IStrategy
{
    private double amount;

    public PaymentStrategy(double amount)
    {
        this.amount = amount;
    }

    public void Execute()
    {
        Console.WriteLine($"Processing payment of ${amount}");
        // Implement payment logic
    }
}

// Concrete Compression Strategy
class CompressionStrategy : IStrategy
{
    private string filePath;

    public CompressionStrategy(string filePath)
    {
        this.filePath = filePath;
    }

    public void Execute()
    {
        Console.WriteLine($"Compressing file {filePath}");
        // Implement compression logic
    }
}

// Context
class Context
{
    private IStrategy strategy;

    public void SetStrategy(IStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

