using System;

// Command interface
interface ICommand
{
    void Execute();
}

// Concrete Command - Light Command
class LightCommand : ICommand
{
    private Light light;
    private bool turnOn;

    public LightCommand(Light light, bool turnOn)
    {
        this.light = light;
        this.turnOn = turnOn;
    }

    public void Execute()
    {
        if (turnOn)
        {
            light.TurnOn();
        }
        else
        {
            light.TurnOff();
        }
    }
}

// Concrete Command - Bold Command
class BoldCommand : ICommand
{
    private Document document;
    private bool toggleBold;

    public BoldCommand(Document document, bool toggleBold)
    {
        this.document = document;
        this.toggleBold = toggleBold;
    }

    public void Execute()
    {
        if (toggleBold)
        {
            document.ToggleBold();
        }
        // Additional commands can be added for different formatting actions
    }
}

// Receiver - Light
class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Receiver - Document
class Document
{
    private bool isBold = false;

    public void ToggleBold()
    {
        isBold = !isBold;
        Console.WriteLine($"Text is {(isBold ? "Bold" : "Not Bold")}");
    }
}

// Invoker
class RemoteEditor
{
    private ICommand lightCommand;
    private ICommand boldCommand;

    public RemoteEditor(ICommand lightCommand, ICommand boldCommand)
    {
        this.lightCommand = lightCommand;
        this.boldCommand = boldCommand;
    }

    public void PressLightButton()
    {
        lightCommand.Execute();
    }

    public void PressBoldButton()
    {
        boldCommand.Execute();
    }
}
