using System;
using System.IO;

namespace Assignment_07
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\tTemplate Method Design pattern\t\n");
            Console.WriteLine("Making coffee with hook:");
            CoffeeTemplate coffeeWithHook = new CoffeeWithHook();
            coffeeWithHook.MakeCoffee();

            Console.WriteLine("\nMaking coffee without hook:");
            CoffeeTemplate coffeeWithoutHook = new CoffeeWithoutHook();
            coffeeWithoutHook.MakeCoffee();

            Console.WriteLine("\nProcessing PDF document:");
            DocumentProcessor pdfProcessor = new PdfDocumentProcessor();
            pdfProcessor.ProcessDocument();

            Console.WriteLine("\nProcessing Word document:");
            DocumentProcessor wordProcessor = new WordDocumentProcessor();
            wordProcessor.ProcessDocument();
            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tMediator Design Pattern\t\n");

            IChatMediator combinedMediator = new CombinedMediator();

            IUser user1 = new ChatUser(combinedMediator, "User1");
            IUser user2 = new ChatUser(combinedMediator, "User2");
            IUser user3 = new ChatUser(combinedMediator, "User3");

            combinedMediator.AddUser(user1);
            combinedMediator.AddUser(user2);
            combinedMediator.AddUser(user3);

            user1.SendMessage("Hello, everyone!");
            user2.SendMessage("Hi there!");

            Aircraft airplane = new Airplane(combinedMediator);
            Aircraft helicopter = new Helicopter(combinedMediator);

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tChain of Responsibility Design Pattern\t\n");


            IHandler combinedHandler = new CombinedLogger();
            IHandler purchaseApprover = new PurchaseApprover();

            combinedHandler.SetNextHandler(purchaseApprover);

            Request logRequest = new Request("This is a log message.", LogLevel.Info);
            Request warningRequest = new Request("This is a warning message.", LogLevel.Warning);
            Request purchaseRequest = new Request("Purchase approval request.", LogLevel.Info);

            combinedHandler.HandleRequest(logRequest);
            combinedHandler.HandleRequest(warningRequest);
            combinedHandler.HandleRequest(purchaseRequest);


            Console.WriteLine("-------------------------------\n");



            Console.WriteLine("\tObserver Design Pattern\t\n");

            CombinedSubject combinedSubject = new CombinedSubject();

            CombinedObserver combinedObserver = new CombinedObserver();
            combinedSubject.Attach(combinedObserver);

            // Simulate changes
            combinedSubject.StockPrice = 150.75;
            combinedSubject.Temperature = 25;

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tStrategy Design Pattern\t\n");

            // Payment Strategy
            Context paymentContext = new Context();
            paymentContext.SetStrategy(new PaymentStrategy(100.50));
            paymentContext.ExecuteStrategy();

            // Compression Strategy
            Context compressionContext = new Context();
            compressionContext.SetStrategy(new CompressionStrategy("document.txt"));
            compressionContext.ExecuteStrategy();


            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tCommmand Design Pattern\t\n");

            Light light = new Light();
            LightCommand lightOnCommand = new LightCommand(light, true);
            LightCommand lightOffCommand = new LightCommand(light, false);

            Document document = new Document();
            BoldCommand boldCommand = new BoldCommand(document, true);

            RemoteEditor remoteEditor = new RemoteEditor(lightOnCommand, boldCommand);

            remoteEditor.PressLightButton(); // Turns on the light
            remoteEditor.PressBoldButton();  // Toggles bold in the document
            remoteEditor.PressLightButton(); // Turns off the light

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tState Design Pattern\t\n");

            Context2 trafficLight = new Context2();
            Context2 fan = new Context2();

            trafficLight.SetState(new RedLightState());
            trafficLight.Request(); // RED Light - Stop!

            trafficLight.SetState(new GreenLightState());
            trafficLight.Request(); // GREEN Light - Go!

            trafficLight.SetState(new YellowLightState());
            trafficLight.Request(); // YELLOW Light - Prepare to Stop!

            fan.SetState(new OffFanState());
            fan.Request(); // Fan is OFF

            fan.SetState(new LowFanState());
            fan.Request(); // Fan is on LOW speed

            fan.SetState(new MediumFanState());
            fan.Request(); // Fan is on MEDIUM speed

            fan.SetState(new HighFanState());
            fan.Request(); // Fan is on HIGH speed

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tVisitor Design Pattern\t\n");

            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.AddAnimal(new Lion());
            objectStructure.AddAnimal(new Monkey());
            objectStructure.AddDocumentElement(new PlainText());
            objectStructure.AddDocumentElement(new BoldText());

            CombinedVisitor combinedVisitor = new CombinedVisitor();
            objectStructure.PerformOperation(combinedVisitor);

            Console.WriteLine("-------------------------------\n");


            Console.WriteLine("\tInterpreter Design Pattern\t\n");

            CombinedContext context = new CombinedContext();
            context.SetVariable("x", 5);
            context.SetVariable("y", 10);

            ICombinedExpression expression = new CombinedAdditionExpression(
                new CombinedVariableExpression("x"),
                new CombinedNumberExpression(20)
            );

            int result = expression.Interpret(context);
            Console.WriteLine("Arithmetic Result: " + result); // Output: Arithmetic Result: 25

            ICombinedExpression romanExpression = new CombinedRomanNumberExpression();
            ((CombinedRomanNumberExpression)romanExpression).AddPart(new CombinedRomanDigitExpression('X'));
            ((CombinedRomanNumberExpression)romanExpression).AddPart(new CombinedRomanDigitExpression('I'));

            int romanResult = romanExpression.Interpret(context);
            Console.WriteLine("Roman Result: " + romanResult);

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tIterator Design Pattern\t\n");

            // Example 1: Iterator for ArrayList
            List<string> arrayListItems = new List<string> { "Item 1", "Item 2", "Item 3" };
            IIterator<string> arrayListIterator = new ConcreteIterator<string>(arrayListItems);

            Console.WriteLine("Example 1: Iterator for ArrayList");
            while (arrayListIterator.HasNext())
            {
                Console.WriteLine(arrayListIterator.Next());
            }
            Console.WriteLine();

            // Example 2: Iterator for Custom Collection
            List<string> customCollectionItems = new List<string> { "Item A", "Item B", "Item C" };
            IIterator<string> customCollectionIterator = new CustomIterator<string>(customCollectionItems);

            Console.WriteLine("Example 2: Iterator for Custom Collection");
            while (customCollectionIterator.HasNext())
            {
                Console.WriteLine(customCollectionIterator.Next());
            }

            Console.WriteLine("-------------------------------\n");

            Console.WriteLine("\tMemento Design Pattern\t\n");
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            // Example 1: Basic Memento Pattern
            originator.Content = "State 1";
            caretaker.Mementos.Add(originator.CreateMemento());

            originator.Content = "State 2";
            Console.WriteLine($"Current state: {originator.Content}");

            originator.RestoreMemento(caretaker.Mementos[0]);
            Console.WriteLine($"Restored state: {originator.Content}");
            Console.WriteLine();

            // Example 2: Memento Pattern with Undo/Redo
            originator.Content = "Edit 1";
            caretaker.Mementos.Add(originator.CreateMemento());

            originator.Content = "Edit 2";
            caretaker.Mementos.Add(originator.CreateMemento());

            Console.WriteLine($"Current content: {originator.Content}");

            originator.RestoreMemento(caretaker.Mementos[1]);
            Console.WriteLine($"Restored content: {originator.Content}");





        }
    }
}