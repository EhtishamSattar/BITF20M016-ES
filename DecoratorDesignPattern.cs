using System;

// Example 1: Coffee Shop

// Component interface
interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 2.0;
    }
}

// Decorator
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee decoratedCoffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.decoratedCoffee = coffee;
    }

    public virtual string GetDescription()
    {
        return decoratedCoffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return decoratedCoffee.GetCost();
    }
}

// Concrete Decorator
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Milk";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }
}

// Concrete Decorator
class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, with Sugar";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.2;
    }
}

// Example 2: Text Formatting

// Component interface
interface IText
{
    string Format();
}

// Concrete Component
class PlainText : IText
{
    private string content;

    public PlainText(string content)
    {
        this.content = content;
    }

    public string Format()
    {
        return content;
    }
}

// Decorator
abstract class TextDecorator : IText
{
    protected IText decoratedText;

    public TextDecorator(IText text)
    {
        this.decoratedText = text;
    }

    public virtual string Format()
    {
        return decoratedText.Format();
    }
}

// Concrete Decorator
class BoldTextDecorator : TextDecorator
{
    public BoldTextDecorator(IText text) : base(text)
    {
    }

    public override string Format()
    {
        return $"<b>{base.Format()}</b>";
    }
}

// Concrete Decorator
class ItalicTextDecorator : TextDecorator
{
    public ItalicTextDecorator(IText text) : base(text)
    {
    }

    public override string Format()
    {
        return $"<i>{base.Format()}</i>";
    }
}
