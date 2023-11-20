using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public interface IChair
    {
        void SitOn();
    }

    public interface ITable
    {
        void PutOn();
    }

    // Concrete product implementations
    public class ModernChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a modern chair");
        }
    }

    public class ModernTable : ITable
    {
        public void PutOn()
        {
            Console.WriteLine("Putting something on a modern table");
        }
    }

    public class VictorianChair : IChair
    {
        public void SitOn()
        {
            Console.WriteLine("Sitting on a Victorian chair");
        }
    }

    public class VictorianTable : ITable
    {
        public void PutOn()
        {
            Console.WriteLine("Putting something on a Victorian table");
        }
    }
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }

    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ITable CreateTable()
        {
            return new ModernTable();
        }
    }

    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ITable CreateTable()
        {
            return new VictorianTable();
        }
    }
    //EXAMPLE#02
    public interface ILetter
    {
        void Write();
    }

    public interface IResume
    {
        void Format();
    }

    // Concrete product implementations
    public class ModernLetter : ILetter
    {
        public void Write()
        {
            Console.WriteLine("Writing a modern letter");
        }
    }

    public class ModernResume : IResume
    {
        public void Format()
        {
            Console.WriteLine("Formatting a modern resume");
        }
    }

    public class ClassicLetter : ILetter
    {
        public void Write()
        {
            Console.WriteLine("Writing a classic letter");
        }
    }

    public class ClassicResume : IResume
    {
        public void Format()
        {
            Console.WriteLine("Formatting a classic resume");
        }
    }

    // Abstract factory interface
    public interface IDocumentFactory
    {
        ILetter CreateLetter();
        IResume CreateResume();
    }

    // Concrete factory implementations
    public class ModernDocumentFactory : IDocumentFactory
    {
        public ILetter CreateLetter()
        {
            return new ModernLetter();
        }

        public IResume CreateResume()
        {
            return new ModernResume();
        }
    }

    public class ClassicDocumentFactory : IDocumentFactory
    {
        public ILetter CreateLetter()
        {
            return new ClassicLetter();
        }

        public IResume CreateResume()
        {
            return new ClassicResume();
        }
    }
}
