using System;

abstract class CoffeeTemplate
{
    public void MakeCoffee()
    {
        BoilWater();
        BrewCoffeeGrounds();
        PourInCup();
        AddCondiments();
        Console.WriteLine("Coffee is ready!");
    }

    protected abstract void BoilWater();
    protected abstract void BrewCoffeeGrounds();
    protected abstract void PourInCup();

    protected virtual void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

class CoffeeWithHook : CoffeeTemplate
{
    protected override void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    protected override void BrewCoffeeGrounds()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    protected override void PourInCup()
    {
        Console.WriteLine("Pouring coffee into cup");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding honey and cream");
    }
}

class CoffeeWithoutHook : CoffeeTemplate
{
    protected override void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    protected override void BrewCoffeeGrounds()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    protected override void PourInCup()
    {
        Console.WriteLine("Pouring coffee into cup");
    }
}

abstract class DocumentProcessor
{
    public void ProcessDocument()
    {
        OpenDocument();
        ReadDocument();
        ProcessContent();
        SaveDocument();
        Console.WriteLine("Document processing complete!");
    }

    protected abstract void OpenDocument();
    protected abstract void ReadDocument();

    protected virtual void ProcessContent()
    {
        Console.WriteLine("Default content processing");
    }

    protected abstract void SaveDocument();
}

class PdfDocumentProcessor : DocumentProcessor
{
    protected override void OpenDocument()
    {
        Console.WriteLine("Opening PDF document");
    }

    protected override void ReadDocument()
    {
        Console.WriteLine("Reading PDF document");
    }

    protected override void SaveDocument()
    {
        Console.WriteLine("Saving PDF document");
    }
}

class WordDocumentProcessor : DocumentProcessor
{
    protected override void OpenDocument()
    {
        Console.WriteLine("Opening Word document");
    }

    protected override void ReadDocument()
    {
        Console.WriteLine("Reading Word document");
    }

    protected override void ProcessContent()
    {
        Console.WriteLine("Custom content processing for Word document");
    }

    protected override void SaveDocument()
    {
        Console.WriteLine("Saving Word document");
    }
}

