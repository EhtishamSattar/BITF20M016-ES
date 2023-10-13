using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        //class Driver
        public class Driver
        {
            public int driver_id;
            public string driver_name;
            public int age;
            public string gender;
            public string address;
            public string phone_no;
            public bool availability;
            public Location cur_location;
            public Vehicle vechicle;
            public List<int> ratings;

            public Driver()
            {
                cur_location = new Location();
                vechicle = new Vehicle();
                age = 0;
            }

            public void updateAvailability(bool status)
            {
                availability = status;
                
            }

            public int getRating()
            {

                if (ratings.Count == 0)
                {
                    Console.WriteLine("No rides yet ");
                    return 0;

                }
                else
                {
                    int totalratings = 0;
                    foreach (int rating in ratings)
                    {
                        totalratings += rating;

                    }
                    return Convert.ToInt32(totalratings / ratings.Count);
                }

            }

            public void updateLocation(float latitude, float longitude)
            {
                cur_location.Latitude = latitude;
                cur_location.Longitude = longitude;
            }
        }

        public class Passenger
        {
            public string passenger_name;
            public string phone_no;


            public void bookRide(List<Driver> drivers_list)
            {
                Ride book_ride = new Ride();
                book_ride.assignPassenger();
                //Console.WriteLine("--->" + book_ride.passenger.passenger_name);
                Console.WriteLine("Enter start location :");
                string input = Console.ReadLine();

                string[] values = input.Split(',');


                Console.WriteLine("Enter end-location : ");
                string input2 = Console.ReadLine();

                string[] end_values = input2.Split(',');

                if (end_values.Length == 2 && values.Length == 2)
                {
                    
                    if (float.TryParse(values[0], out float float1) && float.TryParse(values[1], out float float2) && float.TryParse(end_values[0], out float float3) && float.TryParse(end_values[1], out float float4))
                    {
                       // Console.WriteLine("Float 1: " + float1);
                        //Console.WriteLine("Float 2: " + float2);
                        book_ride.getLocation(float1, float2, float3, float4);
                    }
                    else
                    {
                        Console.WriteLine("Invalid float values.");
                    }
                }



                Console.WriteLine("Enter ride type : ");

                book_ride.vehicle = new Vehicle();
                book_ride.vehicle.type = Console.ReadLine();

                book_ride.calculatePrice();
                //Console.WriteLine("-->" + book_ride.price);

                Console.WriteLine("Price for this ride is : " + book_ride.price);

                book_ride.assignDriver(drivers_list);
                Console.WriteLine("In book ride the driver assigned is " + book_ride.driver.driver_name);

                Console.WriteLine("Enter 'yes' if you want to Book the ride, enter 'no' if you want to cancel operation : ");
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Happy travel ! ... ");
                    int rating = book_ride.passenger.giveRating();
                    
                }
            }

            public int giveRating()
            {
                
                Console.WriteLine("Give ratings : ");
                return Convert.ToInt32(Console.ReadLine());


            }
        }


        //class Ride
        public class Ride
        {
            public Location start_location;
            public Location end_location;
            public Vehicle vehicle;
            public int price;
            public Passenger passenger;
            public Driver driver;

            public Ride()
            {
                start_location = new Location();
                end_location = new Location();

            }
            public void assignPassenger()
            {
                passenger = new Passenger();
                Console.WriteLine("Enter name : ");
                passenger.passenger_name = Console.ReadLine();
                Console.WriteLine("Enter phone_no");
                passenger.phone_no = Console.ReadLine();

            }

            public void assignDriver(List<Driver> list)
            {
                driver = new Driver();
                float minimum = 9999;
                //Console.WriteLine("In assign driver function : list count is " + list.Count);
                //Console.WriteLine("In assign driver function : locations are  " + start_location.Latitude);

                foreach (Driver d in list)
                {
                    if (d.availability == true)
                    {
                        float distance = CalculateEuclideanDistance(start_location, d.cur_location);
                        Console.WriteLine("distance in AD func is " + distance);
                        Console.WriteLine("and driver is " + d.driver_name);


                        if (distance < minimum)
                        {
                            minimum = distance;
                            driver = d;
                        }
                    }
                }
                //Console.WriteLine("Driver in AD func : " + driver.driver_name);
            }

            public void getLocation(float startLatitude, float startLongitude, float endLatitude, float endLongitude)
            {
                start_location.Latitude = startLatitude;
                start_location.Longitude = startLongitude;
                end_location.Latitude = endLatitude;
                end_location.Longitude = endLongitude;
                
            }

            public float CalculateEuclideanDistance(Location location1, Location location2)
            {
                float xDiff = location1.Latitude - location2.Latitude;
                float yDiff = location1.Longitude - location2.Longitude;
                return (float)Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            }

            public void calculatePrice()
            {
                float distance = CalculateEuclideanDistance(start_location, end_location);
                //Console.WriteLine("In price cal function : locations are  " + this.start_location.Latitude, end_location.Latitude);
                //Console.WriteLine("In price cal function : price are  " + distance);

                if (vehicle.type == "bike")
                {
                    price = Convert.ToInt32(((distance * 321) / 50) + 0.05);
                }
                else if (vehicle.type == "car")
                {
                    price = Convert.ToInt32(((distance * 321) / 15) + 0.20);
                }
                else
                {
                    price = Convert.ToInt32(((distance * 321) / 35) + 0.10);
                }

            }
        }

        //Class LOcation
        public class Location
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }

        // class Vehicle
        public class Vehicle
        {
            public string type;
            public string Model { get; set; }
            public string licence_plate { get; set; }
        }

        //class Admin
        public class Admin
        {
            public List<Driver> listOfDriver;
            public Admin()
            {
                listOfDriver = new List<Driver>();
            }
            public void addDriver()
            {
                Driver driver = new Driver();
                Console.WriteLine("Enter ID : ");
                driver.driver_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name : ");
                driver.driver_name = Console.ReadLine();

                Console.WriteLine("Enter gender : ");
                driver.gender = Console.ReadLine();

                Console.WriteLine("Enter address : ");
                driver.address = Console.ReadLine();

                Console.WriteLine("Enter phone_no : ");
                driver.phone_no = Console.ReadLine();

                driver.cur_location = new Location();
                Console.WriteLine("Enter Location : ");

                string input = Console.ReadLine();
                string[] values = input.Split(',');


                float[] location = new float[values.Length];
                driver.cur_location.Latitude = location[0];
                driver.cur_location.Longitude = location[1];

                driver.vechicle = new Vehicle();
                Console.WriteLine("Enter type of Vechicle : ");
                driver.vechicle.type = Console.ReadLine();
                Console.WriteLine("Enter model : ");
                driver.vechicle.Model = Console.ReadLine();

                Console.WriteLine("Enter licence plate : ");
                driver.vechicle.licence_plate = Console.ReadLine();

                driver.ratings = null;

                driver.availability = true;

                listOfDriver.Add(driver);
                //Console.WriteLine("in add driver function count is " + listOfDriver.Count);
            }

            public bool updateDriver(string name = null, string ph_no = null, int id = 0)
            {
                bool updated = false;
                foreach (Driver driver in listOfDriver)
                {
                    if (driver.driver_id == id || driver.driver_name == name || driver.phone_no == ph_no)
                    {
                        Console.WriteLine("Which field you want to update : ");
                        string field = Console.ReadLine();

                        if (field == "name")
                        {
                            Console.WriteLine("Enter new name : ");
                            driver.driver_name = Console.ReadLine();
                            updated = true;

                        }
                        else if (field == "ph_no")
                        {
                            Console.WriteLine("Enter new phone no : ");
                            driver.phone_no = Console.ReadLine();
                            updated = true;
                        }
                        else if (field == "id")
                        {
                            Console.WriteLine("Enter new id : ");
                            driver.driver_id = Convert.ToInt32(Console.ReadLine());
                            updated = true;
                        }
                    }
                }
                return updated;
            }

            public bool removeDriver(int id)
            {
                Console.WriteLine("in remove driver : count is " + listOfDriver.Count);
                bool rem = false;
                Driver d = new Driver();

                foreach (Driver driver in listOfDriver)
                {
                    if (driver.driver_id == id)
                    {
                        d = driver;
                    }
                }
                if (listOfDriver.Remove(d))
                {
                    rem = true;
                }
                return rem;
            }

            public Driver searchDriver(string name, string ph_no, int id)
            {
                Console.WriteLine("Searching ... " + listOfDriver.Count);

                Driver searchedDriver = new Driver();

                foreach (Driver driver in listOfDriver)
                {
                    if (driver.driver_id == id || driver.driver_name == name || driver.phone_no == ph_no)
                    {

                        searchedDriver = driver;
                    }
                }

                return searchedDriver;
            }
        }

        static int showmenu()
        {
            Console.WriteLine("1.Book a ride ");
            Console.WriteLine("2.Enter as Driver ");
            Console.WriteLine("3.Enter as Admin ");
            Console.WriteLine("Press 1 to 3 to select an option ");
            Console.WriteLine("Press any number to directly exit ");
            string option = Console.ReadLine();
            return Convert.ToInt32(option);
        }

        //1.String Concatenation
        static void concatenation()
        {
            string firstName, lastName;

            Console.Write("Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            lastName = Console.ReadLine();

            string fullName = firstName+" "+lastName;

            Console.WriteLine("Your full name is: " + fullName);

        }

        //2.Substring fetching

        static void Substring(string input)
        {
            string sentence = input;

            if (sentence.Length >= 5)
            {
                string lastFiveCharacters = GetLastFiveCharacters(sentence);
                Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
            }
            else
            {
                Console.WriteLine("The sentence is too short to extract the last 5 characters.");
            }
        }

        static string GetLastFiveCharacters(string input)
        {
            
            if (input.Length >= 5)
            {
                return input.Substring(input.Length - 5);
            }
            else
            {
                return input;
            }
        }

        //3.String Interpolation
        static void StringInterpolation()
        {
            double temperature;
            string city;

            Console.Write("Enter the current temperature (in degrees Celsius): ");
            string temperatureInput = Console.ReadLine();

        
            if (double.TryParse(temperatureInput, out temperature))
            {
                Console.Write("Enter the name of your city: ");
                city = Console.ReadLine();

            
                Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
            }
            else
            {
                Console.WriteLine("Invalid temperature input. Please enter a valid number.");
            }
        }


        //4.Array Declaration and iNITIALIZATION
        static void ArrayDeclaration()
        { 
            int[] numbers = { 1, 2, 3, 4, 5 };

        
            Console.WriteLine("Elements of the 'numbers' array:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }


        //5. FOR loop and For each loop
        static void PrintFruitNames(string[] fruitArray)
        {
            Console.WriteLine("Fruit Names:");

        
            for (int i = 0; i < fruitArray.Length; i++)
            {
                Console.WriteLine(fruitArray[i]);
            }
        }


        static void DisplayColorNamesWithCommas()
        {
            string[] colorArray = { "Red", "Blue", "Green", "Yellow", "Orange" };
            Console.Write("Color Names: ");

        
            foreach (string color in colorArray)
            {
                Console.Write(color + ", ");
            }

            Console.WriteLine(); 
        }

        //6. Do while loop , iterating throught est scores
        static void testscores()
        {
            int[] scoreArray = new int[10] { 10, 23, 55, 22, 55, 22, 56, 9, 67, 88 };


            int sum = 0;
            int index = 0;

        
            do
            {
                sum += scoreArray[index];
                index++;
            }
            while (index < scoreArray.Length);
            Console.WriteLine("Sum of test scores: " + sum);
        }


        //7. Max Value
        static void MaxValue()
        {
            int[] array = { 12, 34, 56, 78, 90, 45, 67, 89, 23, 1 };
            if (array.Length == 0)
            {
                Console.WriteLine("The array is empty.");
                
            }else
            {

                int max = array[0]; 
                int index = 1; 
                while (index < array.Length)
                {
                    if (array[index] > max)
                    {
                        max = array[index];
                    }
                    index++;
                }
                Console.WriteLine("The maximum value in the array is: " + max);
            }


        }

        //8.Reverse Array

        static void reverse()
        {
            int[]array = { 1, 2, 3, 4, 5, 6 };
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                // Swap the elements at 'left' and 'right'
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                left++;
                right--;
            }

            // Display the reversed array using a foreach loop
            Console.Write("Reversed Array: ");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
        

        }

        //9. Boxing
        //   1.Integer

        static void integerBoxing()
        {
        
            int x = 42;
            object boxedX = x;
            int y = (int)boxedX;
            Console.WriteLine("Value of 'y': " + y);
        }

        //    2.Double

        static void doubleBoxing()
        {
        
            double doubleValue = 3.14159;
            object boxedValue = doubleValue;
            double unboxedValue = (double)boxedValue;
            Console.WriteLine("Value of 'unboxedValue': " + unboxedValue);
        }

        //10 Unboxing

        static void aUnboxing()
        {
        
            int[] numbers = { 2, 4, 6, 8, 10 };
            for (int i = 0; i < numbers.Length; i++)
            {
                int originalValue = numbers[i]; 

                object boxedValue = originalValue;
                int unboxedValue = (int)boxedValue;
                int squaredValue = unboxedValue * unboxedValue;
                Console.WriteLine($"Original Integer: {originalValue}, Squared Value: {squaredValue}");
            }
        }

        static void bUnboxing()
        {
        
            List<object> mixedList = new List<object>();
            mixedList.Add(42);          
            mixedList.Add(3.14159);     
            mixedList.Add('A');         
            mixedList.Add("Hello");  
            Console.WriteLine("Elements in the list:");

            foreach (object item in mixedList)
            {
            
                if (item is int)
                {
                    Console.WriteLine($"Integer: {item}, Type: {item.GetType()}");
                }
                else if (item is double)
                {
                    Console.WriteLine($"Double: {item}, Type: {item.GetType()}");
                }
                else if (item is char)
                {
                    Console.WriteLine($"Char: {item}, Type: {item.GetType()}");
                }
                else if (item is string)
                {
                    Console.WriteLine($"String: {item}, Type: {item.GetType()}");
                }
            }
        }


        // 11. Dynamic keyword
        static void dynamicVariable()
        {
        
            dynamic myVariable;
            myVariable = 42;
            Console.WriteLine("Integer Value: " + myVariable);
            myVariable = "Hello, Dynamic!";
            Console.WriteLine("String Value: " + myVariable);
        }

        //    gettype()
        static void dynamicType()
        {
            dynamic myVariable2;
            myVariable2 = 42;
            Console.WriteLine("Type of myVariable2 (integer): " + myVariable2.GetType());
            myVariable2 = 3.14;
            Console.WriteLine("Type of myVariable2 (double): " + myVariable2.GetType());
            myVariable2 = DateTime.Now;
            Console.WriteLine("Type of myVariable2 (DateTime): " + myVariable2.GetType());
            myVariable2 = "Hello, Dynamic!";
            Console.WriteLine("Type of myVariable2 (string): " + myVariable2.GetType());
        }


        static void Main(string[] args)
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("");
            Console.WriteLine("                       MENU");
            Console.WriteLine("");
            Console.WriteLine("****************************************************");
            Console.WriteLine("                  WELCOME TO MYRIDE");

            bool mainExit = false;

            Admin admin = new Admin();
            while (!mainExit)
            {

                int option = showmenu();
                if (option == 1)
                {
                    Passenger passenger = new Passenger();
                    passenger.bookRide(admin.listOfDriver);

                }
                else if (option == 2)
                {
                    Driver driver = new Driver();
                    Console.WriteLine("Enter id : ");
                    driver.driver_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter name : ");
                    driver.driver_name = Console.ReadLine();
                    //Console.WriteLine(admin.searchDriver(null, null, driver.driver_id).driver_name);
                    if (driver.driver_id == admin.searchDriver(null, null, driver.driver_id).driver_id)
                    {
                        Console.Write("Hello " + driver.driver_name);
                        Console.WriteLine("Enter your current Location : ");
                        string input2 = Console.ReadLine();

                        string[] end_values = input2.Split(',');

                        if (end_values.Length == 2)
                        {

                            if (float.TryParse(end_values[0], out float float1) && float.TryParse(end_values[1], out float float2))
                            {
                                // Console.WriteLine("Float 1: " + float1);
                                //Console.WriteLine("Float 2: " + float2);
                                driver.cur_location.Latitude = float1;
                                driver.cur_location.Longitude=float2;
                            }
                            else
                            {
                                Console.WriteLine("Invalid location values.");
                            }
                        }

                        bool exit = false;
                        while (!exit)
                        {
                            Console.WriteLine("1. Change Availibity (true for available / false for unavaliaable )");
                            Console.WriteLine("2. Change location ");
                            Console.WriteLine("3. Exit as driver ");

                            string opt = Console.ReadLine();


                            if (opt == "1")
                            {
                                Console.WriteLine("Are u available yes/no : ");
                                if (Console.ReadLine() == "yes")
                                {
                                    driver.updateAvailability(true);
                                }
                                else
                                {
                                    driver.updateAvailability(false);
                                }

                            }
                            else if (opt == "2")
                            {
                                Console.WriteLine("Enter your location : ");

                                string input = Console.ReadLine();

                                string[] end_values2 = input2.Split(',');

                                if (end_values2.Length == 2)
                                {

                                    if (float.TryParse(end_values2[0], out float float1) && float.TryParse(end_values2[1], out float float2))
                                    { 
                                        driver.updateLocation(float1, float2);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid location values.");
                                    }
                                }
                            }
                            else
                            {
                                exit = true;
                            }
                        }
                    }

                }
                else if (option == 3)
                {
                    bool exit = false;
                    while (!exit)
                    {
                        Console.WriteLine("1. Add Driver ");
                        Console.WriteLine("2. Remove Driver ");
                        Console.WriteLine("3. Update Driver ");
                        Console.WriteLine("4. Search Driver ");
                        Console.WriteLine("5. Exit as Admin ");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        if (opt == 1)
                        {
                            admin.addDriver();
                            Console.WriteLine("Outside of add driver func " + admin.listOfDriver.Count);
                        }
                        else if (opt == 2)
                        {
                            Console.WriteLine("Enter id : ");
                            admin.removeDriver(Convert.ToInt32(Console.ReadLine()));
                        }
                        else if (opt == 3)
                        {
                            Console.WriteLine("Which field you want to update : ");
                            string field = Console.ReadLine();
                            if (field == "name")
                            {
                                Console.WriteLine("Enter name : ");
                                if (admin.updateDriver(Console.ReadLine(), null, 0))
                                {
                                    Console.WriteLine("Driver Updated ");
                                }
                                else
                                {
                                    Console.WriteLine("Driver not Updated ");

                                }
                            }
                            else if (field == "ph_no")
                            {
                                Console.WriteLine("Enter ph_no : ");
                                if (admin.updateDriver(null, Console.ReadLine(), 0))
                                {
                                    Console.WriteLine("Driver Updated ");
                                }
                                else
                                {
                                    Console.WriteLine("Driver not  Updated ");

                                }
                            }
                            else if (field == "id")
                            {
                                Console.WriteLine("Enter id : ");
                                if (admin.updateDriver(null, null, Convert.ToInt32(Console.ReadLine())))
                                {
                                    Console.WriteLine("Driver Updated ");
                                }
                                else
                                {
                                    Console.WriteLine("Driver not Updated ");

                                }
                            }
                        }
                        else if (opt == 4)
                        {
                            Console.WriteLine("On basis of which field you want to search : ");
                            string field = Console.ReadLine();
                            if (field == "name")
                            {
                                Console.WriteLine("Enter name : ");
                                admin.searchDriver(Console.ReadLine(), null, 0);
                            }
                            else if (field == "ph_no")
                            {
                                Console.WriteLine("Enter ph_no : ");
                                admin.searchDriver(null, Console.ReadLine(), 0);
                            }
                            else if (field == "id")
                            {
                                Console.WriteLine("Enter id : ");
                                admin.searchDriver(null, null, Convert.ToInt32(Console.ReadLine()));
                            }
                        }
                        else
                        {
                            exit = true;
                        }

                    }
                }
                else
                {
                    mainExit = true;
                }
            }
            Console.WriteLine("Press any key to exit ... ");
            Console.ReadKey();
        }
    }
}
