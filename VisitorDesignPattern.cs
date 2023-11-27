using System;
using System.Collections.Generic;

// Visitor interface
interface IVisitor
{
    void Visit(Lion lion);
    void Visit(Monkey monkey);
    void Visit(PlainText plainText);
    void Visit(BoldText boldText);
}

// Element interface
interface IAnimal
{
    void Accept(IVisitor visitor);
}

interface IDocumentElement
{
    void Accept(IVisitor visitor);
}

// Concrete Elements
class Lion : IAnimal
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Roar()
    {
        Console.WriteLine("Lion Roaring");
    }
}

class Monkey : IAnimal
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Jump()
    {
        Console.WriteLine("Monkey Jumping");
    }
}

class PlainText : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Display()
    {
        Console.WriteLine("Plain Text");
    }
}

class BoldText : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Display()
    {
        Console.WriteLine("Bold Text");
    }
}

// Concrete Visitor
class CombinedVisitor : IVisitor
{
    public void Visit(Lion lion)
    {
        lion.Roar();
    }

    public void Visit(Monkey monkey)
    {
        monkey.Jump();
    }

    public void Visit(PlainText plainText)
    {
        plainText.Display();
    }

    public void Visit(BoldText boldText)
    {
        boldText.Display();
    }
}

// Object Structure
class ObjectStructure
{
    private List<IAnimal> animals = new List<IAnimal>();
    private List<IDocumentElement> documentElements = new List<IDocumentElement>();

    public void AddAnimal(IAnimal animal)
    {
        animals.Add(animal);
    }

    public void AddDocumentElement(IDocumentElement element)
    {
        documentElements.Add(element);
    }

    public void PerformOperation(IVisitor visitor)
    {
        foreach (var animal in animals)
        {
            animal.Accept(visitor);
        }

        foreach (var element in documentElements)
        {
            element.Accept(visitor);
        }
    }
}

