using OOP_book_reader.Models;
using System;
using System.IO;
using System.Security.Principal;
using System.Text.Json;

namespace OOP_book_reader.Manager
{
    public class LoginSignin
    {
        static string dataDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Data"
        );

        static string filePath = Path.Combine(
            dataDir,
            "UserData.txt"
        );

        public static void SignInLogIn  ()
        {

            Directory.CreateDirectory(dataDir);

            Console.WriteLine("1-- signin \n2--- login");
            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    Console.WriteLine("Enter name:");
                    string? name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        Environment.Exit(0);
                        return;
                    }

                    Console.WriteLine("Enter surname:");
                    string? surname = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(surname))
                    {
                        Console.WriteLine("Surname cannot be empty.");
                        Environment.Exit(0);
                        return;
                    }

                    Console.WriteLine("Enter phone number:");
                    if (!int.TryParse(Console.ReadLine(), out int phone))
                    {
                        Console.WriteLine("Invalid phone number.");
                        Environment.Exit(0);
                        return;
                    }

                    Console.WriteLine("Enter date of birth (yyyy-MM-dd):");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                    {
                        Console.WriteLine("Invalid date format.");
                        return;
                    }

                    User user = new User(name, surname, phone, dateOfBirth);

                    string json = JsonSerializer.Serialize(user);


                    File.AppendAllText(filePath, json + Environment.NewLine);

                    Console.WriteLine("User registered successfully!");
                    break;
                case 2:
                    Console.WriteLine("Enter name:");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        return;
                    }

                    Console.WriteLine("Enter surname:");
                    surname = Console.ReadLine();

                    Console.WriteLine("Enter phone number:");
                    if (!int.TryParse(Console.ReadLine(), out phone))
                    {
                        Console.WriteLine("Invalid phone number.");
                        return;
                    }

                    Console.WriteLine("Enter date of birth (yyyy-MM-dd):");
                    if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                    {
                        Console.WriteLine("Invalid date format.");
                        return;
                    }

                    User userLog = new User(name, surname, phone, dateOfBirth);


                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        User? account = null;
                        foreach (var line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;
                            User? u = JsonSerializer.Deserialize<User>(line);
                            if (u != null &&
                                u.Name == userLog.Name &&
                                u.Surname == userLog.Surname &&
                                u.Phone == userLog.Phone &&
                                u.DateOfBirth == userLog.DateOfBirth)
                            {
                                account = u;
                                break;
                            }
                        }

                        if (account != null)
                        {
                            Console.WriteLine("Login successful!");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No users registered yet.");
                    }

                    break;
            }
        }


    }
}
