using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public interface ICloneablePrototype
    {
        ICloneablePrototype Clone();
        void Display();
    }
    public class ConcretePrototype : ICloneablePrototype
    {
        public int Id { get; set; }

        public ConcretePrototype(int id)
        {
            Id = id;
        }
        public ICloneablePrototype Clone()
        {
            //shallow copy
            return (ICloneablePrototype)MemberwiseClone();
        }
        public void Display()
        {
            Console.WriteLine($"ConcretePrototype with Id: {Id}");
        }
    }
    //EXample2
    public interface IShapePrototype
    {
        void SetId(int id);
        int GetId();
        IShapePrototype Clone();
        void Display();

    }
    public class Circle2 : IShapePrototype
    {
        private int _id;

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public IShapePrototype Clone()
        {
            // Perform a shallow copy
            return (IShapePrototype)MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"Circle with Id: {_id}");
        }
    }
}
