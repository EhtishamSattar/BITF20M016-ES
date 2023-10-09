using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_03
{
    class Program
    {
        //1. Optional Arguments

        //  a
        public static void Greet(string greeting = "Hello", string name = "World")
        {
            Console.WriteLine($"{greeting}, {name}!");
        }

        //  b
        public static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }

        //  c
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }

        //  d

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }

            public Book(string title, string author = "Unknown")
            {
                Title = title;
                Author = author;
            }
        }


        // Generics
        //  a
        public class MyList<T>
        {
            private List<T> items;

            public MyList()
            {
                items = new List<T>();
            }
            public void Add(T item)
            {
                items.Add(item);
            }
            public bool Remove(T item)
            {
                return items.Remove(item);
            }

            public void Display()
            {
                Console.WriteLine("List Elements:");
                foreach (T item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }


        //  b

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        //  c
        public static T ComputeSum<T>(T[] array) where T : struct, IComparable<T>
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentException("Array must not be empty.", nameof(array));

            dynamic sum = 0; // Initialize sum to 0 of the generic type

            foreach (T item in array)
            {
                sum += item;
            }

            return sum;
        }


        //  D

        static string GetStudentName(int studentID, Dictionary<int, string> database)
        {
            if (database.ContainsKey(studentID))
            {
                return database[studentID];
            }
            else
            {
                return null;
            }
        }

        static void DisplayStudentDatabase(Dictionary<int, string> database)
        {
            Console.WriteLine("Student Database:");
            foreach (var student in database)
            {
                Console.WriteLine($"Student ID: {student.Key}, Name: {student.Value}");
            }
        }


        static void UpdateStudentName(Dictionary<int, string> database)
        {
            Console.Write("Enter Student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                if (database.ContainsKey(studentID))
                {
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();
                    database[studentID] = newName;
                    Console.WriteLine("Student name updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student ID not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer Student ID.");
            }
        }
        static void Main()
        {
            // Greet function

            Greet(); 
            Greet("Hi", "John");
            Greet(name: "Alice");
            Greet(greeting: "Hey");

            //Calculate Area
            
            double defaultArea = CalculateArea(); 
            double customArea = CalculateArea(5.0, 3.0); 
            double lengthOnlyArea = CalculateArea(length: 4.0); 
            double widthOnlyArea = CalculateArea(width: 2.5);
            Console.WriteLine(defaultArea);
            Console.WriteLine(customArea);
            Console.WriteLine(lengthOnlyArea);
            Console.WriteLine(widthOnlyArea);

            //Add numbers

            int sum1 = AddNumbers(5, 7); 
            int sum2 = AddNumbers(10, 20, 30); 
            int sum3 = AddNumbers(3, 4);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);

            // Book Class with 2nd optional parameter
            Book book1 = new Book("Book 1");
            Book book2 = new Book("Book 2", "Author 2");
            Console.WriteLine($"Book 1: Title - {book1.Title}, Author - {book1.Author}");
            Console.WriteLine($"Book 2: Title - {book2.Title}, Author - {book2.Author}");


            MyList<int> myListInt = new MyList<int>();
            myListInt.Add(1);
            myListInt.Add(2);
            myListInt.Add(3);
            myListInt.Display();


            int num1 = 10;
            int num2 = 20;
            Console.WriteLine($"Before Swap - num1: {num1}, num2: {num2}");
            Swap(ref num1, ref num2);
            Console.WriteLine($"After Swap - num1: {num1}, num2: {num2}");
            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine($"Before Swap - str1: {str1}, str2: {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After Swap - str1: {str1}, str2: {str2}");


            int[] intArray = { 1, 2, 3, 4, 5 };
            double[] doubleArray = { 1.5, 2.5, 3.5, 4.5, 5.5 };
            long[] longArray = { 10L, 20L, 30L };

            // Compute the sum of integers
            int intSum = ComputeSum(intArray);
            Console.WriteLine("Sum of integers: " + intSum);

            // Compute the sum of doubles
            double doubleSum = ComputeSum(doubleArray);
            Console.WriteLine("Sum of doubles: " + doubleSum);

            long longSum = ComputeSum(longArray);
            Console.WriteLine("Sum of Longs: " + longSum);





            // This is the dictionary of students - students Database
            Dictionary<int, string> studentDatabase = new Dictionary<int, string>();
            // Add some initial student records to the dictionary
            studentDatabase.Add(101, "Alice");
            studentDatabase.Add(102, "Bob");
            studentDatabase.Add(103, "Charlie");
            studentDatabase.Add(104, "David");

            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View the student database");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update a student's name");
                Console.WriteLine("4. Exit the program");
                Console.Write("Enter your choice (1-4): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayStudentDatabase(studentDatabase);
                            break;
                        case 2:
                            Console.Write("Enter a Student ID: ");
                            if (int.TryParse(Console.ReadLine(), out int studentID))
                            {
                                string studentName = GetStudentName(studentID, studentDatabase);

                                if (studentName != null)
                                {
                                    Console.WriteLine($"Student ID: {studentID}, Name: {studentName}");
                                }
                                else
                                {
                                    Console.WriteLine("Student ID not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer Student ID.");
                            }
                            break;
                        case 3:
                            UpdateStudentName(studentDatabase);
                            break;
                        case 4:
                            exitProgram = true;
                            Console.WriteLine("Exiting the program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid menu option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid menu option (1-4).");
                }
            }

            Console.WriteLine("Press any key to exit ... ");
            Console.ReadKey();
        }
    }
}
