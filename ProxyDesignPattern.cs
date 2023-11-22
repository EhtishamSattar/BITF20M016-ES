using System;

// Subject interface
interface IRealSubject
{
    void Request();
}

// RealSubject
class RealSubject : IRealSubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject handles the request");
    }
}

// Proxy
class Proxy : IRealSubject
{
    private RealSubject _realSubject;

    public void Request()
    {
        if (_realSubject == null)
        {
            Console.WriteLine("Proxy creates an instance of RealSubject");
            _realSubject = new RealSubject();
        }

        _realSubject.Request();
    }
}

// Protection Proxy
class ProtectionProxy : IRealSubject
{
    private readonly string _password = "secret";
    private RealSubject _realSubject;

    public void Authenticate(string password)
    {
        if (password == _password)
        {
            _realSubject = new RealSubject();
            Console.WriteLine("Authentication successful. Proxy grants access.");
        }
        else
        {
            Console.WriteLine("Authentication failed. Proxy denies access.");
        }
    }

    public void Request()
    {
        if (_realSubject != null)
        {
            _realSubject.Request();
        }
        else
        {
            Console.WriteLine("Unauthorized access. Please authenticate.");
        }
    }
}

// Client code
