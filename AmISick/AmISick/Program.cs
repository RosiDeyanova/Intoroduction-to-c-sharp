using System;
using System.Collections.Generic;
using System.IO;

namespace AmISick
{
    class Program
    {
        static void Main(string[] args)
        {
            var patients = new List<Patient>();
            var doctors = new List<Doctor>()
            {
              new Doctor("Nikolina", "Petkova" , "npetkova12"),
              new Doctor("Georgi", "Nedelchev", "gnedelchev12"),
              new Doctor("Petar", "Barzov", "pbarzov12")
            };
            if (!File.Exists("database.txt"))
            {
                File.Create("database.txt").Dispose();
            }

            while (true)
            {
                Console.WriteLine("Commands: 'register', 'help', 'diagnose', 'check' or 'exit'\nType command: ");
                string command = Console.ReadLine();
                if (command == "register")
                {
                    patients.Clear();
                    Functions.ReadFromFile("database.txt",patients);
                    Functions.Register(patients);
                }
                else if (command == "help")
                {
                   Console.WriteLine(Functions.Help());
                }
                else if (command == "diagnose")
                {
                    string password;
                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();
                    for (int i = 0; i < doctors.Count; i++)
                    {
                        if (password == doctors[i].Password)
                        {
                            patients.Clear();
                            Functions.Diagnose(doctors[i],patients);
                        }
                    }
                }
                else if (command == "check")
                {
                    patients.Clear();
                    Functions.ReadFromFile("database.txt", patients);
                    string firstName, secondName, lastName;
                    Console.WriteLine("First Name: ");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Second Name: ");
                    secondName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    lastName = Console.ReadLine();
                    for (int i = 0; i < patients.Count; i++)
                    {
                        if (firstName == patients[i].FirstName && secondName == patients[i].SecondName && lastName==patients[i].LastName)
                        {
                            Console.WriteLine(patients[i].ToString());
                        }
                    }
                }
                else if (command == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Use a valid command");
                }
            }

        }
    }
}
