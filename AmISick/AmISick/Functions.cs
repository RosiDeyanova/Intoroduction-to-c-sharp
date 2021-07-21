using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmISick
{
    class Functions
    {
        public static void PrintAllUndiagnosedPatients(List<Patient> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Diagnosis == "Undiagnosed")
                {
                    Console.WriteLine(i + ". " + patients[i].ToString());
                }
            }
        }
        public static bool IsThereUndiagnosedPatients(List<Patient> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Diagnosis == "Undiagnosed")
                {
                    return true;
                }
            }
            return false;
        }
        public static void Diagnose(Doctor doctor, List<Patient> patients)
        {
            ReadFromFile(patients);
            Console.WriteLine("Undiagnosed patients: ");
            PrintAllUndiagnosedPatients(patients);
            Console.WriteLine("Type the index of the pation who's going to be diagnosed: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Type diagnosis: ");
            string diagnosis = Console.ReadLine();
            patients[index].Diagnosis = diagnosis + doctor.ToString();
            WriteInFile(patients);
            Console.WriteLine("Patients left: ");
            PrintAllUndiagnosedPatients(patients);

        }
        public static void PushPatientInfo(string[] info, List<Patient> patients)
        {
            Patient temp = new Patient();
            temp.FirstName = info[0];
            temp.SecondName = info[1];
            temp.LastName = (info[2].Remove(info[2].Length - 1));
            string symptom = "";
            int i = 3;
            while(info[i]!="-")
            {
                if (info[i+1]!="-")
                {
                    symptom = info[i].Remove(info[i].Length - 1);
                }
                else
                {
                    symptom = info[i];
                }
                Symptom tempSymptom = (Symptom)Enum.Parse(typeof(Symptom), symptom, true);
                temp.AddSymptom(tempSymptom);
                i++;
            }
            if (info[i+1]!= "Undiagnosed")
            {
                StringBuilder diagnose = new StringBuilder();
                for (int f =i+1; f < info.Length; f++)
                {
                    diagnose.Append(info[f]);
                    diagnose.Append(" ");
                }
                temp.Diagnosis = diagnose.ToString();
            }
            patients.Add(temp);
        }
        public static void ReadFromFile(List<Patient> patients)
        {
            StreamReader databaseReader = new StreamReader("database.txt");
            using (databaseReader)
            {
                int lineNumber = 0;
                string line = databaseReader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    var info = line.Split(" ");
                    PushPatientInfo(info, patients);
                    line = databaseReader.ReadLine();
                }
            }
        }
        public static void WriteInFile(List<Patient> patients)
        {
            StreamWriter databaseWriter = new StreamWriter("database.txt");
            using (databaseWriter)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    databaseWriter.WriteLine(patients[i].ToString());
                }
            }
        }
        public void FillDatabase(string line)
        {
            //take a line from the file, split it by spaces and add it to list of Patients
        }
        public static void CreatePatient(string firstName, string secondName, string lastName, List<Patient> patients)
        {
            Patient patient = new Patient(firstName, secondName, lastName);
            AddSymptoms(patient);
            patients.Add(patient);
            Console.WriteLine("Your info: ");
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].FirstName == firstName && patients[i].SecondName == secondName && patients[i].LastName == lastName)
                {
                    Console.WriteLine(patients[i].ToString());
                } //using the names as identificator, if the project gets bigger, it will be used egn
            }
            WriteInFile(patients);

        }
        public static void Register(List<Patient> patients)
        {
            string firstName, secondName, lastName;
            Console.WriteLine("Register: ");
            Console.WriteLine("First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Second Name: ");
            secondName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            lastName = Console.ReadLine();

            CreatePatient(firstName, secondName, lastName, patients);

        }
        public static void AddSymptoms(Patient patient)
        {
            string symptom;
            int i = 0;
            do
            {
                Console.WriteLine("Symptom code or 'submit': ");
                symptom = Console.ReadLine();
                bool IsItParsable = int.TryParse(symptom, out i);
                if (IsItParsable == true)
                {
                    patient.AddSymptom(int.Parse(symptom));

                }
                else if (IsItParsable == false && symptom != "submit")
                {
                    Console.WriteLine("Use correct numeric value or 'submit'");
                }
            } while (symptom != "submit");
            Console.WriteLine("Your registration was successful!");

        }

        public static void Help()
        {
            Console.WriteLine("How to register:");
            Console.WriteLine("Type the command 'register' followed by your first, second and last name. \nThen type the appropriate symptoms using their code numbers. \nWhen you have typed all of your symptoms type 'submit'. \nSymptoms: ");
            Patient.PrintSymptoms();
        }


    }
}
