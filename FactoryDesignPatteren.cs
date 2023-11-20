using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public interface IProduct
    {
        void display();
    }
    public class ProductA : IProduct
    {
        public void display()
        {
            Console.WriteLine("Product A");
        }
    }
    public class ProductB : IProduct
    {
        public void display()
        {
            Console.WriteLine("Product B");
        }
    }
    //Now make IFactory
    public interface IFactory {
        IProduct createProduct();
    }
    public class FactoryA:IFactory
    {
        public IProduct createProduct()
        {
            return new ProductA();
        }
    }
    public class FactoryB : IFactory
    {
        public IProduct createProduct()
        {
            return new ProductB();
        }
    }


    //EXAMPLE#02
    public interface IShape
    {
        void Draw();
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle");
        }
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Rectangle");
        }
    }
    //factory interface
    public interface IShapeFactory
    {
        IShape CreateShape();
    }
    public class CircleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Circle();
        }
    }
    public class RectangleFactory : IShapeFactory
    {
        public IShape CreateShape()
        {
            return new Rectangle();
        }
    }
}
