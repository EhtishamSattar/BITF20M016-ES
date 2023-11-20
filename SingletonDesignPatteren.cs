using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    //EXAMPLE#01(classic singleton)
    public class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        {

        }
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
    //EXAMPLE#2
    public class SingletonM
    {
        private static SingletonM _instance;

        private SingletonM() { }

        public static SingletonM Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonM();
                }
                return _instance;
            }
        }

        public void SomeMethod()
        {
            Console.WriteLine("Executing SomeMethod");
        }
    }

}
