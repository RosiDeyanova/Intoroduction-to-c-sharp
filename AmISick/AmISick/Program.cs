using System;
using System.Collections.Generic;
using System.IO;

namespace AmISick
{
    class Program
    {

        static void Main(string[] args)
        {
            PatientsManager patientsManager = new PatientsManager();
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
                    Functions.Register(patientsManager);
                }
                else if (command == "help")
                {
                    Functions.Help();
                }
                else if (command == "diagnose")
                {
                    Functions.Diagnose(patientsManager, doctors);
                }
                else if (command == "check")
                {
                    Functions.Check(patientsManager);
                }
                else if (command == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Wrong command");
                }
            }

        }
    }
}
