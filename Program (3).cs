using System;

namespace Assignment_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //SINGLETON DESIGN PATTEREN
            Console.WriteLine("SINGLETON DESIGN PATTEREN");
            Console.WriteLine("EXAMPLE1");
            //EXAMPLE1
            Singleton singletonInstance1 = Singleton.Instance;
            Singleton singletonInstance2 = Singleton.Instance;
            if (singletonInstance1 == singletonInstance2)
            {
                Console.WriteLine("Both instance are same!");
            }
            //EXAMPLE2
            Console.WriteLine("EXAMPLE2");
            SingletonM singletonInstance3 = SingletonM.Instance;
            singletonInstance3.SomeMethod();

            SingletonM singletonInstance4 = SingletonM.Instance;
            singletonInstance4.SomeMethod();

            // Checking if both instances refer to the same object
            Console.WriteLine(singletonInstance3 == singletonInstance4);

            //FACTORY DESIGN PATTEREN
            Console.WriteLine("--------------------------------");
            Console.WriteLine("FACTORY DESIGN PATTEREN");
            Console.WriteLine("EXAMPLE1");
            IFactory factoryA = new FactoryA();
            IProduct productA = factoryA.createProduct();
            productA.display();
            IFactory factoryB = new FactoryB();
            IProduct productB = factoryB.createProduct();
            productB.display();
            //EXAMPLE2
            Console.WriteLine("EXAMPLE2");
            IShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw();  
            IShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();
            rectangle.Draw();
            //ABSTRACT FACTORY DESIGN PATTEREN
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ABSTRACT FACTORY DESIGN PATTEREN");
            Console.WriteLine("EXAMPLE1");
            IFurnitureFactory modernFactory = new ModernFurnitureFactory();
            IChair modernChair = modernFactory.CreateChair();
            ITable modernTable = modernFactory.CreateTable();
            modernChair.SitOn();  
            modernTable.PutOn();  
            IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
            IChair victorianChair = victorianFactory.CreateChair();
            ITable victorianTable = victorianFactory.CreateTable();
            victorianChair.SitOn();  
            victorianTable.PutOn();
            //EXAMPLE2
            Console.WriteLine("EXAMPLE2");
            IDocumentFactory modernFactory2 = new ModernDocumentFactory();
            ILetter modernLetter = modernFactory2.CreateLetter();
            IResume modernResume = modernFactory2.CreateResume();

            modernLetter.Write();
            modernResume.Format();  

           
            IDocumentFactory classicFactory = new ClassicDocumentFactory();
            ILetter classicLetter = classicFactory.CreateLetter();
            IResume classicResume = classicFactory.CreateResume();

            classicLetter.Write();  
            classicResume.Format();

            //BUILDER DESIGN PATTEREN
            Console.WriteLine("--------------------------------");
            Console.WriteLine("BUILDER DESIGN PATTEREN");
            Console.WriteLine("EXAMPLE1");
            IComputerBuilder gamingComputerBuilder = new GamingComputerBuilder();
            ComputerDirector director = new ComputerDirector(gamingComputerBuilder);

            Computer gamingComputer = director.Construct();
            gamingComputer.Display();
            //EXAMPLE2
            Builder builder = new ConcreteBuilder();
            Director director2 = new Director(builder);
            director2.Construct();
            Product product = builder.GetResult();
            product.Display();
            //PROTOTYPE DESIGN PATTEREN
            Console.WriteLine("--------------------------------");
            Console.WriteLine("PROTOTYPE DESIGN PATTEREN");
            Console.WriteLine("EXAMPLE1");
            ICloneablePrototype original = new ConcretePrototype(1);
            // Clone the prototype to create a new instance
            ICloneablePrototype cloned = original.Clone();
            original.Display(); 
            cloned.Display();
            //EXAMPLE2
            Console.WriteLine("EXAMPLE2");
            IShapePrototype originalCircle = new Circle2();
            originalCircle.SetId(1);
            IShapePrototype clonedCircle = originalCircle.Clone();
            clonedCircle.SetId(12);
            originalCircle.Display();  // Output: Circle with Id: 1
            clonedCircle.Display();




        }
    }
}
