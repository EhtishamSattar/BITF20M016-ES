using System;
using System.IO;

namespace Assignment_07
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("\n  2 examples of Adapter design pattern.\n");
            Console.WriteLine("--------------------------------------------");
            // Example 1: Class Adapter
            ITarget classAdapterTarget = new ClassAdapter();
            classAdapterTarget.Request(); // Uses the Adaptee's specific request through the Class Adapter

            // Example 2: Object Adapter
            Adaptee adaptee = new Adaptee();
            ITarget objectAdapterTarget = new ObjectAdapter(adaptee);
            objectAdapterTarget.Request(); // Uses the Adaptee's specific request through the Object Adapter



            //2.
            Console.WriteLine("\n 2 examples of Composite design pattern \n");
            Console.WriteLine("--------------------------------------------");
            // Example 1: Basic Composite Structure
            IComponent leaf1 = new Leaf("A");
            IComponent leaf2 = new Leaf("B");

            Composite composite = new Composite();
            composite.Add(leaf1);
            composite.Add(leaf2);

            composite.Operation(); // Executes both Leaf A and Leaf B operations through Composite

            // Example 2: Composite for Graphics Hierarchy
            IComponent dot1 = new Leaf("Dot1");
            IComponent dot2 = new Leaf("Dot2");

            Composite compositeGraphic = new Composite();
            compositeGraphic.Add(dot1);
            compositeGraphic.Add(dot2);

            compositeGraphic.Operation(); // Draws both Dots through CompositeGraphic



            //3 .
            Console.WriteLine(" \n 2 examples of Proxy design pattern \n");
            Console.WriteLine("--------------------------------------------");
            // Example 1: Virtual Proxy
            IRealSubject virtualProxy = new Proxy();
            virtualProxy.Request(); // Proxy controls access to the RealSubject

            // Example 2: Protection Proxy
            ProtectionProxy protectionProxy = new ProtectionProxy();

            // Unauthorized request
            protectionProxy.Request();

            // Authenticate
            protectionProxy.Authenticate("wrongpassword");

            // Authorized request
            protectionProxy.Authenticate("secret");
            protectionProxy.Request();




            //4.
            Console.WriteLine("\n 2 examples of Flyweight design pattern \n");
            Console.WriteLine("--------------------------------------------");


            // Example 1: Text Formatting
            TextFormatFactory textFormatFactory = new TextFormatFactory();

            ITextFormat boldFormat = textFormatFactory.GetCharacterFormat('*');
            ITextFormat underlineFormat = textFormatFactory.GetCharacterFormat('_');
            ITextFormat italicFormat = textFormatFactory.GetCharacterFormat('/');

            boldFormat.Apply("Bold");
            underlineFormat.Apply("Underline");
            italicFormat.Apply("Italic");

            Console.WriteLine(); // Separating the two examples in the output

            // Example 2: Document Editor
            FontStyleFactory fontStyleFactory = new FontStyleFactory();

            IFontStyle boldStyle = fontStyleFactory.GetFontStyle("Bold");
            IFontStyle italicStyle = fontStyleFactory.GetFontStyle("Italic");
            IFontStyle underlineStyle = fontStyleFactory.GetFontStyle("Underline");

            boldStyle.Apply("This is Bold");
            italicStyle.Apply("This is Italic");
            underlineStyle.Apply("This is Underlined");



            // 5.
            Console.WriteLine("\n 2 examples of Facade design pattern \n");
            Console.WriteLine("--------------------------------------------");

            // Example 1: Home Theater System
            Amplifier amplifier = new Amplifier();
            DVDPlayer dvdPlayer = new DVDPlayer();
            Projector projector = new Projector();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer, projector);

            // Watch a movie using the facade
            homeTheater.WatchMovie();

            Console.WriteLine(); // Separating the two examples in the output

            // End the movie using the facade
            homeTheater.EndMovie();

            Console.WriteLine(); // Separating the two examples in the output

            // Example 2: Online Shopping System
            InventorySystem inventorySystem = new InventorySystem();
            PaymentSystem paymentSystem = new PaymentSystem();
            ShippingSystem shippingSystem = new ShippingSystem();

            OnlineShoppingFacade onlineShoppingFacade = new OnlineShoppingFacade(inventorySystem, paymentSystem, shippingSystem);

            // Purchase a product using the facade
            onlineShoppingFacade.PurchaseProduct("Laptop", "Credit Card", 1200.00, "123 Main St");

            Console.WriteLine(); // Separating the two examples in the output

            // Purchase another product using the facade
            onlineShoppingFacade.PurchaseProduct("Headphones", "PayPal", 100.00, "456 Oak Ave");


            //6
            Console.WriteLine("\n 2 examples of Bridge design pattern \n");
            Console.WriteLine("--------------------------------------------");

            IDrawAPI drawAPI = new DrawAPI();

            Shape circle = new Circle(5, 2, 3, drawAPI);
            Shape square = new Square(4, 6, 8, drawAPI);

            circle.Draw();
            square.Draw();

            Console.WriteLine(); // Separating the two examples in the output

            // Example 2: Remote Control for Devices
            IDevice tv = new TV();
            IDevice radio = new Radio();

            RemoteControl tvRemote = new BasicRemoteControl(tv);
            RemoteControl radioRemote = new BasicRemoteControl(radio);

            // Using the remote controls
            tvRemote.TurnOn();
            tvRemote.SetChannel(5);
            tvRemote.TurnOff();

            Console.WriteLine(); // Separating the two examples in the output

            radioRemote.TurnOn();
            radioRemote.SetChannel(101);
            radioRemote.TurnOff();


            //7.
            Console.WriteLine("\n 2 examples of Decorator design pattern \n");
            Console.WriteLine("--------------------------------------------");

            // Creating a simple coffee
            ICoffee simpleCoffee = new SimpleCoffee();
            Console.WriteLine($"Cost: {simpleCoffee.GetCost()}, Description: {simpleCoffee.GetDescription()}");

            // Adding milk to the coffee
            ICoffee milkCoffee = new MilkDecorator(simpleCoffee);
            Console.WriteLine($"Cost: {milkCoffee.GetCost()}, Description: {milkCoffee.GetDescription()}");

            // Adding sugar to the coffee
            ICoffee sugarCoffee = new SugarDecorator(simpleCoffee);
            Console.WriteLine($"Cost: {sugarCoffee.GetCost()}, Description: {sugarCoffee.GetDescription()}");

            // Adding both milk and sugar to the coffee
            ICoffee milkSugarCoffee = new SugarDecorator(new MilkDecorator(simpleCoffee));
            Console.WriteLine($"Cost: {milkSugarCoffee.GetCost()}, Description: {milkSugarCoffee.GetDescription()}");

            // Creating a plain text
            IText plainText = new PlainText("Hello, Decorator Pattern!");
            Console.WriteLine($"Original Text: {plainText.Format()}");

            // Decorating with bold
            IText boldText = new BoldTextDecorator(plainText);
            Console.WriteLine($"Bold Text: {boldText.Format()}");

            // Decorating with italic
            IText italicText = new ItalicTextDecorator(plainText);
            Console.WriteLine($"Italic Text: {italicText.Format()}");

            // Decorating with both bold and italic
            IText boldItalicText = new BoldTextDecorator(new ItalicTextDecorator(plainText));
            Console.WriteLine($"Bold Italic Text: {boldItalicText.Format()}");
        }
    }
}