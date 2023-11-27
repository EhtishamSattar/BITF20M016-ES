using System;

// State interface
interface IState
{
    void Handle();
}

// Concrete States
class RedLightState : IState
{
    public void Handle()
    {
        Console.WriteLine("RED Light - Stop!");
    }
}

class GreenLightState : IState
{
    public void Handle()
    {
        Console.WriteLine("GREEN Light - Go!");
    }
}

class YellowLightState : IState
{
    public void Handle()
    {
        Console.WriteLine("YELLOW Light - Prepare to Stop!");
    }
}

class OffFanState : IState
{
    public void Handle()
    {
        Console.WriteLine("Fan is OFF");
    }
}

class LowFanState : IState
{
    public void Handle()
    {
        Console.WriteLine("Fan is on LOW speed");
    }
}

class MediumFanState : IState
{
    public void Handle()
    {
        Console.WriteLine("Fan is on MEDIUM speed");
    }
}

class HighFanState : IState
{
    public void Handle()
    {
        Console.WriteLine("Fan is on HIGH speed");
    }
}

// Context
class Context2
{
    private IState state;

    public void SetState(IState newState)
    {
        state = newState;
    }

    public void Request()
    {
        state.Handle();
    }
}

