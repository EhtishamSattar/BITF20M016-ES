using System;
using System.Collections;
using System.Collections.Generic;

// Common Iterator interface
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Concrete Iterator for ArrayList
class ConcreteIterator<T> : IIterator<T>
{
    private List<T> items;
    private int index = 0;

    public ConcreteIterator(List<T> items)
    {
        this.items = items;
    }

    public bool HasNext()
    {
        return index < items.Count;
    }

    public T Next()
    {
        if (HasNext())
        {
            return items[index++];
        }
        throw new InvalidOperationException("No more elements");
    }
}

// Concrete Iterator for Custom Collection
class CustomIterator<T> : IIterator<T>
{
    private List<T> items;
    private int index = 0;

    public CustomIterator(List<T> items)
    {
        this.items = items;
    }

    public bool HasNext()
    {
        return index < items.Count;
    }

    public T Next()
    {
        if (HasNext())
        {
            return items[index++];
        }
        throw new InvalidOperationException("No more elements");
    }
}

