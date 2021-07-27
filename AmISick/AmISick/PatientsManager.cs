using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmISick
{
    class PatientsManager
    {
        const string UNDIAGNOSED = "Undiagnosed";
        const string PATIENTS_FILE = "database.txt";
        private List<Patient> patients;

        public PatientsManager() 
        {
            this.patients = new List<Patient>();
        }
        public PatientsManager(List<Patient>patients) 
        {
            this.patients = patients;
        }


        public string PrintAllUndiagnosedPatients() //printing all the undiagnosed patients with their indexes
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Diagnosis == UNDIAGNOSED)
                {
                    result.AppendLine(i + ". " + patients[i].ToString());
                }
            }
            return result.ToString();
        }
        public bool IsThereUndiagnosedPatients() //checking if there are undiagnosed patients left
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Diagnosis == UNDIAGNOSED)
                {
                    return true;
                }
            }
            return false;
        }
     
        public void AddPatient(Patient patient)//creating a problem and adding it to the database
        {
            patients.Add(patient);
            WriteInFile();
        }

        private void WriteInFile() //saving the current List<Patient> into a file
        {
            StreamWriter databaseWriter = new StreamWriter(PATIENTS_FILE);
            using (databaseWriter)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    databaseWriter.WriteLine(patients[i].ToString());
                }
            }
        }

        public void ReadFromFile() //Reading a file and pushing the info into List<Patient>
        {
            StreamReader databaseReader = new StreamReader(PATIENTS_FILE);
            using (databaseReader)
            {
                int lineNumber = 0;
                string line = databaseReader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    var info = line.Split(' ', ':', ',');
                    PushPatientInfo(info);
                    line = databaseReader.ReadLine();
                }
            }
        }

        private void PushPatientInfo(string[] info) //separating the info prom a line of input and putting it into an object
        {
            Patient patient = new Patient();
            patient.FirstName = info[0];
            patient.SecondName = info[1];
            patient.LastName = info[2];

            int i = 3;
            while (info[i] != "-")
            {
                if (info[i] != "")
                {
                    string symptom = info[i];
                    Symptom tempSymptom = (Symptom)Enum.Parse(typeof(Symptom), symptom, true);
                    patient.AddSymptom(tempSymptom);
                }
                i++;
            }

            if (info[i + 1] != UNDIAGNOSED)
            {
                StringBuilder diagnose = new StringBuilder();
                for (int f = i + 1; f < info.Length; f++)
                {
                    diagnose.Append(info[f]);
                    diagnose.Append(" ");
                }
                patient.AddDiagnose(diagnose.ToString());
            }

            patients.Add(patient);
        }

        public string PrintPatientInfo(string firstName, string secondName, string lastName)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Your info:");
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].FirstName == firstName && patients[i].SecondName == secondName && patients[i].LastName == lastName)
                {
                    output.AppendLine(patients[i].ToString());
                } //using the names as identificator, if the project gets bigger, it will be used egn
            }
            return output.ToString();
        }

        public void AddPatientDiagnose(int patientIndex, string diagnose)
        {
            patients[patientIndex].AddDiagnose(diagnose);
            WriteInFile();
        }

        public void Clear() 
        {
            this.patients.Clear();
        }
    }
}
