using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmISick
{
    class Functions
    {
        public static void Diagnose(PatientsManager patientsManager,Doctor doctor) //adding a diagnosis to a patient
        {
            Console.WriteLine("Undiagnosed patients: ");
            Console.WriteLine(patientsManager.PrintAllUndiagnosedPatients());

            Console.WriteLine("Type the index of the pation who's going to be diagnosed: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("Type diagnosis: ");
            string diagnosis = Console.ReadLine();
            patientsManager.AddPatientDiagnose(index, diagnosis + doctor.ToString());

            Console.WriteLine("Patients left: ");
            Console.WriteLine(patientsManager.PrintAllUndiagnosedPatients());
        }

        public static void AddSymptoms(Patient patient) //adding symptoms when registering
        {
            string symptom;
            int i = 0;
            do
            {
                Console.WriteLine("Symptom code or 'submit': ");
                symptom = Console.ReadLine();
                bool isItParsable = int.TryParse(symptom, out i);
                if (isItParsable == true)
                {
                    patient.AddSymptom(int.Parse(symptom));

                }
                else if (isItParsable == false && symptom != "submit")
                {
                    Console.WriteLine("Use correct numeric value or 'submit'");
                }
            } while (symptom != "submit");
            Console.WriteLine("Your registration was successful!");

        }

        public static void Register(PatientsManager patientsManager) //inputing the first data for the registration
        {
            string firstName, secondName, lastName;
            Console.WriteLine("Register: ");
            Console.WriteLine("First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Second Name: ");
            secondName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            lastName = Console.ReadLine();

            Patient patient = new Patient(firstName, secondName, lastName);
            AddSymptoms(patient);
            patientsManager.AddPatient(patient);
            string patientInfo = patientsManager.PrintPatientInfo(patient.FirstName, patient.SecondName, patient.LastName);
            Console.WriteLine(patientInfo);
        }

        public static string Help()
        {
            string symptoms = Patient.PrintSymptoms();
            return "How to register:\nType the command 'register' followed by your first, second and last name. \nThen type the appropriate symptoms using their code numbers. \nWhen you have typed all of your symptoms type 'submit'. \nSymptoms:" + symptoms + "How to check your registered problems:\nType the command 'check' followed by your first, second and last name. \nYou will see your submitted problems and their status.\nHow to diagnose someone as a doctor:\nType the command 'diagnose' followed by the doctor's password. \nChoose which patient would you like to diagnose, using their indexes and type the diagnosis.";
        }

    }
}
