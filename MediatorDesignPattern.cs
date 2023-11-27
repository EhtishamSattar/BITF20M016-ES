using System;
using System.Collections.Generic;

// Mediator interface
interface IChatMediator
{
    void AddUser(IUser user);
    void SendMessage(IUser sender, string message);
}

// Colleague interface
interface IUser
{
    void ReceiveMessage(string message);
    void SendMessage(string message);
}

// Concrete Mediator
class CombinedMediator : IChatMediator
{
    private List<IUser> users = new List<IUser>();

    public void AddUser(IUser user)
    {
        users.Add(user);
    }

    public void SendMessage(IUser sender, string message)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.ReceiveMessage($"{sender.GetType().Name}: {message}");
            }
        }
    }
}

// Concrete Colleague (Chat User)
class ChatUser : IUser
{
    private IChatMediator mediator;
    public string Name { get; }

    public ChatUser(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        this.Name = name;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        mediator.SendMessage(this, message);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} receives: {message}");
    }
}

// Concrete Colleague (Aircraft)
abstract class Aircraft : IUser
{
    protected IChatMediator airTrafficControl;

    public Aircraft(IChatMediator airTrafficControl)
    {
        this.airTrafficControl = airTrafficControl;
    }

    public abstract void ReceiveMessage(string message);
    public abstract void SendMessage(string message);
}

// Concrete Colleague (Airplane)
class Airplane : Aircraft
{
    public Airplane(IChatMediator airTrafficControl) : base(airTrafficControl)
    {
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Airplane received: {message}");
    }

    public override void SendMessage(string message)
    {
        airTrafficControl.SendMessage(this, message);
    }

    public void TakeOff()
    {
        SendMessage("Taking off");
    }
}

// Concrete Colleague (Helicopter)
class Helicopter : Aircraft
{
    public Helicopter(IChatMediator airTrafficControl) : base(airTrafficControl)
    {
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Helicopter received: {message}");
    }

    public override void SendMessage(string message)
    {
        airTrafficControl.SendMessage(this, message);
    }

    public void Land()
    {
        SendMessage("Landing");
    }
}


