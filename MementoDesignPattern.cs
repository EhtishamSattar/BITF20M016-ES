using System;
using System.Collections.Generic;

// Common Memento interface
interface IMemento
{
    string GetState();
}

// Concrete Memento
class Memento : IMemento
{
    private string state;

    public Memento(string state)
    {
        this.state = state;
    }

    public string GetState()
    {
        return state;
    }
}

// Originator
class Originator
{
    private string content;

    public string Content
    {
        get { return content; }
        set
        {
            Console.WriteLine($"Setting content to: {value}");
            content = value;
        }
    }

    public IMemento CreateMemento()
    {
        Console.WriteLine("Creating Memento");
        return new Memento(content);
    }

    public void RestoreMemento(IMemento memento)
    {
        content = ((Memento)memento).GetState();
        Console.WriteLine($"Restoring content to: {content}");
    }
}

// Caretaker
class Caretaker
{
    public List<IMemento> Mementos { get; } = new List<IMemento>();
}
