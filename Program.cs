using System;
using System.Data.SqlClient;

namespace Assignment_5
{
    class Program
    {
        // the server is SQL SERVER FOR DEVELOPER
        private static string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        public static void CreateDatabaseAndTable(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the database
                    string createDatabaseSql = "CREATE DATABASE AssignmentFive";
                    using (SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseSql, connection))
                    {
                        createDatabaseCommand.ExecuteNonQuery();
                        Console.WriteLine("Database created ! ");
                    }

                    connection.ChangeDatabase("AssignmentFive");

                    // Create the table
                    string Table = @"
                    CREATE TABLE EMPLOYEES (
                        ID BIGINT IDENTITY(1,1) PRIMARY KEY,
                        FirstName NVARCHAR(255) NOT NULL,
                        LastName NVARCHAR(255) NOT NULL,
                        Email NVARCHAR(500) NOT NULL,
                        PrimaryPhoneNumber NVARCHAR(11) NOT NULL,
                        SecondaryPhoneNumber NVARCHAR(11) NULL,
                        CreatedBy NVARCHAR(100) NOT NULL,
                        CreatedOn DATETIME NOT NULL,
                        ModifiedBy NVARCHAR(100) NULL,
                        ModifiedOn DATETIME NULL
                    )";
                    using (SqlCommand createTable = new SqlCommand(Table, connection))
                    {
                        createTable.ExecuteNonQuery();
                        Console.WriteLine("Table created successfully.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }

        public static void selectEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EM WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, " +
                                              $"Email: {reader["Email"]}, PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}, " +
                                              $"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                        }
                    }
                }
            }
        }

        public static void insertEmployee(string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string createdBy, DateTime createdOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO EMPLOYEES (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn) " +
                               "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                    command.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Inserted {rowsAffected} records.");
                }
            }
        }

        public static void updateEmployee(int id, string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string modifiedBy, DateTime? modifiedOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // to open a connection
                connection.Open();

                string query = "UPDATE EMPLOYEES SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                               "PrimaryPhoneNumber = @PrimaryPhoneNumber, SecondaryPhoneNumber = @SecondaryPhoneNumber, " +
                               "ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn " +
                               "WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                    command.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);
                    command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                    command.Parameters.AddWithValue("@ModifiedOn", (object)modifiedOn ?? DBNull.Value);

                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"Updated {rowsAffected} records !");
                }
            }
        }
        public static void deleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM EMPLOYEES WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Deleted {rowsAffected} records !");
                }
            }
        }

        public static void readEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM EMPLOYEES";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"id: {reader["ID"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, Email: {reader["Email"]}, PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                        }
                    }
                }
            }

        }


        // this is the main to execute the above functions and implementations
        static void Main()
        {
            CreateDatabaseAndTable(connectionString);
            while (true)
            {
                Console.WriteLine("1. Insert employee");
                Console.WriteLine("2. Select employee by ID");
                Console.WriteLine("3. Update employee");
                Console.WriteLine("4. Delete employee");
                Console.WriteLine("5. Read all employees");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Enter number of  your choice :");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        


                        Console.Write("Enter FirstName: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter LastName: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Primary Phone Number: ");
                        string primaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Secondary Phone Number (press Enter if none): ");
                        string secondaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Created By: ");
                        string createdBy = Console.ReadLine();
                        DateTime createdOn = DateTime.Now;
                        insertEmployee(firstName, lastName, email, primaryPhoneNumber, secondaryPhoneNumber, createdBy, createdOn);
                        Console.WriteLine("Employee added successfully !");
                        break;
                    case "2":

                        Console.Write("Enter the ID of the employee to select: ");
                        if (int.TryParse(Console.ReadLine(), out int selectId))
                        {
                            selectEmployeeById(selectId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please try again.");
                        }
                        break;

                        

                    case "3":
                        Console.Write("Enter the ID of the employee to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.Write("Enter FirstName: ");
                            firstName = Console.ReadLine();
                            Console.Write("Enter LastName: ");
                            lastName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            email = Console.ReadLine();
                            Console.Write("Enter Primary Phone Number: ");
                            primaryPhoneNumber = Console.ReadLine();
                            Console.Write("Enter Secondary Phone Number : ");
                            secondaryPhoneNumber = Console.ReadLine();
                            Console.Write("Enter Modified By: ");
                            string modifiedBy = Console.ReadLine();
                            DateTime modifiedOn = DateTime.Now;
                            updateEmployee(updateId, firstName, lastName, email, primaryPhoneNumber, secondaryPhoneNumber, modifiedBy, modifiedOn);
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;
                        
                    case "4":
                        Console.Write("Enter the ID of the employee to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            deleteEmployee(deleteId);
                            Console.WriteLine("Employee deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please try again.");
                        }
                        break;
                    case "5":
                        readEmployees();
                        break;

                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again !");
                        break;
                }
            }
            Console.WriteLine("Press Any key...");
            Console.ReadKey();
        }

    }
}

