using System;
using System.Collections.Generic;

// Subject interface
interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
class CombinedSubject : ISubject
{
    private double stockPrice;
    private int temperature;
    private List<IObserver> observers = new List<IObserver>();

    public double StockPrice
    {
        get { return stockPrice; }
        set
        {
            stockPrice = value;
            Notify();
        }
    }

    public int Temperature
    {
        get { return temperature; }
        set
        {
            temperature = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}

// Observer interface
interface IObserver
{
    void Update(ISubject subject);
}

// Concrete Observer
class CombinedObserver : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is CombinedSubject combinedSubject)
        {
            if (combinedSubject is CombinedSubject)
            {
                Console.WriteLine($"Combined Observer: Stock price changed to ${combinedSubject.StockPrice}");
            }

            if (combinedSubject is CombinedSubject)
            {
                Console.WriteLine($"Combined Observer: Temperature changed to {combinedSubject.Temperature}°C");
            }
        }
    }
}


