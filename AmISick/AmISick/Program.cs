﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AmISick
{
    class Program
    {
       
        static void Main(string[] args)
        {
            PatientsManager patientsManager = new PatientsManager();
           // var patients = new List<Patient>();
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
                    patientsManager.Clear();
                    patientsManager.ReadFromFile();
                    Functions.Register(patientsManager);
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
                            patientsManager.Clear();
                            patientsManager.ReadFromFile();
                            Functions.Diagnose(patientsManager,doctors[i]);
                        }
                    }
                }
                else if (command == "check")
                {
                    patientsManager.Clear();
                    patientsManager.ReadFromFile();
                    string firstName, secondName, lastName;
                    Console.WriteLine("First Name: ");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Second Name: ");
                    secondName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    lastName = Console.ReadLine();
                    string patientInfo = patientsManager.PrintPatientInfo(firstName, secondName, lastName);
                    Console.WriteLine(patientInfo);
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
