using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmISick
{
    class Functions
    {
        public static string PrintAllUndiagnosedPatients(List<Patient> patients) //printing all the undiagnosed patients with their indexes
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Diagnosis == "Undiagnosed")
                {
                    result.AppendLine(i + ". " + patients[i].ToString());
                }
            }
            return result.ToString();
        }
        public static bool IsThereUndiagnosedPatients(List<Patient> patients) //checking if there are undiagnosed patients left
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
        public static void Diagnose(Doctor doctor, List<Patient> patients) //adding a diagnosis to a patient
        {
            ReadFromFile("database.txt",patients);
            Console.WriteLine("Undiagnosed patients: ");
            Console.WriteLine(PrintAllUndiagnosedPatients(patients));
            Console.WriteLine("Type the index of the pation who's going to be diagnosed: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Type diagnosis: ");
            string diagnosis = Console.ReadLine();
            patients[index].Diagnosis = diagnosis + doctor.ToString();
            WriteInFile("database.txt",patients);
            Console.WriteLine("Patients left: ");
            Console.WriteLine(PrintAllUndiagnosedPatients(patients));

        }
        public static void PushPatientInfo(string[] info, List<Patient> patients) //separating the info prom a line of input and putting it into an object
        {
            Patient temp = new Patient();
            temp.FirstName = info[0];
            temp.SecondName = info[1];
            temp.LastName = info[2];
            string symptom = "";
            int i = 3;
            while(info[i]!="-")
            {
                if (info[i]!="")
                {
                    symptom = info[i];
                    Symptom tempSymptom = (Symptom)Enum.Parse(typeof(Symptom), symptom, true);
                    temp.AddSymptom(tempSymptom);
                }
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
        public static void ReadFromFile(string fileName,List<Patient> patients) //Reading a file and pushing the info into List<Patient>
        {
            StreamReader databaseReader = new StreamReader(fileName);
            using (databaseReader)
            {
                int lineNumber = 0;
                string line = databaseReader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    var info = line.Split(' ',':',',');
                    PushPatientInfo(info, patients);
                    line = databaseReader.ReadLine();
                }
            }
        }
        public static void WriteInFile(string fileName,List<Patient> patients) //saving the current List<Patient> into a file
        {
            StreamWriter databaseWriter = new StreamWriter(fileName);
            using (databaseWriter)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    databaseWriter.WriteLine(patients[i].ToString());
                }
            }
        }
 
        public static void CreatePatient(string firstName, string secondName, string lastName, List<Patient> patients)//creating a problem and adding it to the database
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
            WriteInFile("databse.txt",patients);

        }
    
        public static void Register(List<Patient> patients) //inputing the first data for the registration
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
        public static void AddSymptoms(Patient patient) //adding symptoms when registering
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

        public static string Help()
        {
            string symptoms = Patient.PrintSymptoms();
            return "How to register:\nType the command 'register' followed by your first, second and last name. \nThen type the appropriate symptoms using their code numbers. \nWhen you have typed all of your symptoms type 'submit'. \nSymptoms:" + symptoms + "How to check your registered problems:\nType the command 'check' followed by your first, second and last name. \nYou will see your submitted problems and their status.\nHow to diagnose someone as a doctor:\nType the command 'diagnose' followed by the doctor's password. \nChoose which patient would you like to diagnose, using their indexes and type the diagnosis.";
        }


    }
}
