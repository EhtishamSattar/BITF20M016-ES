using System;

// Handler interface
interface IHandler
{
    void SetNextHandler(IHandler nextHandler);
    void HandleRequest(Request request);
}

// Request class
class Request
{
    public string Content { get; }
    public LogLevel Level { get; }

    public Request(string content, LogLevel level)
    {
        Content = content;
        Level = level;
    }
}

// Log levels
enum LogLevel
{
    Info,
    Warning,
    Error
}

// Concrete Handler
class CombinedLogger : IHandler
{
    private IHandler nextHandler;

    public void SetNextHandler(IHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public void HandleRequest(Request request)
    {
        Console.WriteLine($"Handling Request: {request.Content} - {request.Level}");
        nextHandler?.HandleRequest(request);
    }
}

// Concrete Handler
class PurchaseApprover : IHandler
{
    private IHandler nextHandler;

    public void SetNextHandler(IHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public void HandleRequest(Request request)
    {
        Console.WriteLine($"Handling Purchase Request: {request.Content} - {request.Level}");
        nextHandler?.HandleRequest(request);
    }
}

