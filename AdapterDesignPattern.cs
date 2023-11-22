using System;

// Target interface
interface ITarget
{
    void Request();
}

// Adaptee
class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request");
    }
}

// Adapter (Class Adapter)
class ClassAdapter : Adaptee, ITarget
{
    public void Request()
    {
        SpecificRequest();
    }
}


// Example 2
// Adapter (Object Adapter)
class ObjectAdapter : ITarget
{
    private readonly Adaptee _adaptee;

    public ObjectAdapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}
