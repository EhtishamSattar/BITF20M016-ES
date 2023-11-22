using System;

// Subsystem components
class Amplifier
{
    public void TurnOn()
    {
        Console.WriteLine("Amplifier is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Amplifier is OFF");
    }
}

class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVD Player is playing");
    }

    public void Stop()
    {
        Console.WriteLine("DVD Player stopped");
    }
}

class Projector
{
    public void TurnOn()
    {
        Console.WriteLine("Projector is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Projector is OFF");
    }
}

// Facade
class HomeTheaterFacade
{
    private readonly Amplifier _amplifier;
    private readonly DVDPlayer _dvdPlayer;
    private readonly Projector _projector;

    public HomeTheaterFacade(Amplifier amplifier, DVDPlayer dvdPlayer, Projector projector)
    {
        _amplifier = amplifier;
        _dvdPlayer = dvdPlayer;
        _projector = projector;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Get ready to watch a movie...");
        _amplifier.TurnOn();
        _dvdPlayer.Play();
        _projector.TurnOn();
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down the home theater...");
        _projector.TurnOff();
        _dvdPlayer.Stop();
        _amplifier.TurnOff();
    }
}

// Subsystem components
class InventorySystem
{
    public void CheckStock(string product)
    {
        Console.WriteLine($"Checking stock for {product}");
    }
}

class PaymentSystem
{
    public void ProcessPayment(string method, double amount)
    {
        Console.WriteLine($"Processing {method} payment of ${amount}");
    }
}

class ShippingSystem
{
    public void ShipProduct(string product, string address)
    {
        Console.WriteLine($"Shipping {product} to {address}");
    }
}

// Facade
class OnlineShoppingFacade
{
    private readonly InventorySystem _inventorySystem;
    private readonly PaymentSystem _paymentSystem;
    private readonly ShippingSystem _shippingSystem;

    public OnlineShoppingFacade(InventorySystem inventorySystem, PaymentSystem paymentSystem, ShippingSystem shippingSystem)
    {
        _inventorySystem = inventorySystem;
        _paymentSystem = paymentSystem;
        _shippingSystem = shippingSystem;
    }

    public void PurchaseProduct(string product, string paymentMethod, double amount, string shippingAddress)
    {
        Console.WriteLine("Processing online purchase...");
        _inventorySystem.CheckStock(product);
        _paymentSystem.ProcessPayment(paymentMethod, amount);
        _shippingSystem.ShipProduct(product, shippingAddress);
    }
}

