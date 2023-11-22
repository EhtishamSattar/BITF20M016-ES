using System;
using System.Collections.Generic;

// Component
interface IComponent
{
    void Operation();
}

// Leaf
class Leaf : IComponent
{
    private readonly string _name;

    public Leaf(string name)
    {
        _name = name;
    }

    public void Operation()
    {
        Console.WriteLine($"Leaf {_name} operation");
    }
}

// Composite
class Composite : IComponent
{
    private readonly List<IComponent> _children = new List<IComponent>();

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Operation()
    {
        Console.WriteLine("Composite operation");
        foreach (var child in _children)
        {
            child.Operation();
        }
    }
}

