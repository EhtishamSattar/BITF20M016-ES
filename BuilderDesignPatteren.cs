using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    //product
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GPU { get; set; }

        public void Display()
        {
            Console.WriteLine($"Computer with CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, GPU: {GPU}");
        }
    }

    // Builder interface
    public interface IComputerBuilder
    {
        void SetCPU(string cpu);
        void SetRAM(string ram);
        void SetStorage(string storage);
        void SetGPU(string gpu);
        Computer Build();
    }

    // Concrete builders
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU(string cpu)
        {
            _computer.CPU = cpu;
        }

        public void SetRAM(string ram)
        {
            _computer.RAM = ram;
        }

        public void SetStorage(string storage)
        {
            _computer.Storage = storage;
        }

        public void SetGPU(string gpu)
        {
            _computer.GPU = gpu;
        }

        public Computer Build()
        {
            return _computer;
        }
    }

    // Director
    public class ComputerDirector
    {
        private IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer Construct()
        {
            _builder.SetCPU("Intel i9");
            _builder.SetRAM("32GB");
            _builder.SetStorage("1TB SSD");
            _builder.SetGPU("NVIDIA RTX 3080");
            return _builder.Build();
        }
    }
    //EXAMPLE2
    public class Product
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }

        public void Display()
        {
            Console.WriteLine($"Part1: {Part1}, Part2: {Part2}");
        }
    }
    public abstract class Builder
    {
        public abstract void BuildPart1();
        public abstract void BuildPart2();
        public abstract Product GetResult();
    }
    public class ConcreteBuilder : Builder
    {
        private Product product = new Product();

        public override void BuildPart1()
        {
            product.Part1 = "Builder Part 1";
        }

        public override void BuildPart2()
        {
            product.Part2 = "Builder Part 2";
        }

        public override Product GetResult()
        {
            return product;
        }
    }
    public class Director
    {
        private Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildPart1();
            builder.BuildPart2();
        }
    }





}
