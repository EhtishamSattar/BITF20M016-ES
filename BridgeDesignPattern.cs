using System;

// Implementor interface
interface IDrawAPI
{
    void DrawCircle(int radius, int x, int y);
    void DrawSquare(int side, int x, int y);
}

// Concrete Implementor
class DrawAPI : IDrawAPI
{
    public void DrawCircle(int radius, int x, int y)
    {
        Console.WriteLine($"Drawing Circle[Radius: {radius}, X: {x}, Y: {y}]");
    }

    public void DrawSquare(int side, int x, int y)
    {
        Console.WriteLine($"Drawing Square[Side: {side}, X: {x}, Y: {y}]");
    }
}

// Abstraction
abstract class Shape
{
    protected IDrawAPI drawAPI;

    protected Shape(IDrawAPI drawAPI)
    {
        this.drawAPI = drawAPI;
    }

    public abstract void Draw();
}

// Refined Abstraction
class Circle : Shape
{
    private int radius;
    private int x;
    private int y;

    public Circle(int radius, int x, int y, IDrawAPI drawAPI) : base(drawAPI)
    {
        this.radius = radius;
        this.x = x;
        this.y = y;
    }

    public override void Draw()
    {
        drawAPI.DrawCircle(radius, x, y);
    }
}

// Refined Abstraction
class Square : Shape
{
    private int side;
    private int x;
    private int y;

    public Square(int side, int x, int y, IDrawAPI drawAPI) : base(drawAPI)
    {
        this.side = side;
        this.x = x;
        this.y = y;
    }

    public override void Draw()
    {
        drawAPI.DrawSquare(side, x, y);
    }
}

// Implementor interface
interface IDevice
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

// Concrete Implementor
class TV : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("TV is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is OFF");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine($"Setting TV channel to {channel}");
    }
}

// Concrete Implementor
class Radio : IDevice
{
    public void TurnOn()
    {
        Console.WriteLine("Radio is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Radio is OFF");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine($"Setting Radio channel to {channel}");
    }
}

// Abstraction
abstract class RemoteControl
{
    protected IDevice device;

    protected RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract void SetChannel(int channel);
}

// Refined Abstraction
class BasicRemoteControl : RemoteControl
{
    public BasicRemoteControl(IDevice device) : base(device)
    {
    }

    public override void TurnOn()
    {
        device.TurnOn();
    }

    public override void TurnOff()
    {
        device.TurnOff();
    }

    public override void SetChannel(int channel)
    {
        device.SetChannel(channel);
    }
}

