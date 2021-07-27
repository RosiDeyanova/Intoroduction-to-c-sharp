using System;
using System.Collections.Generic;
using System.Text;

namespace AmISick
{
   class Patient
    {
        private string firstName;
        private string secondName;
        private string lastName;
        private List<Symptom> symptoms;
        private string diagnose;

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            set 
            {
                this.firstName = value;
            }
        }
        public string SecondName
        {
            get
            {
                return this.secondName;
            }
            set
            {
                this.secondName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public string Diagnosis
        {
            get
            {
                return this.diagnose;
            }
            set
            {
                this.diagnose = value;
            }
        }

        public Patient() 
        {
            this.firstName = "Unknown";
            this.lastName = "Unknown";
            this.secondName = "Unknown";
            this.diagnose = "Undiagnosed";
            this.symptoms = new List<Symptom>();
        }
        public Patient(string firstName, string secondName, string lastName) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.secondName = secondName;
            this.diagnose = "Undiagnosed";
            this.symptoms = new List<Symptom>();
        }

        public override string ToString()
        {
            StringBuilder symptomsString = new StringBuilder();
            for (int i = 0; i < this.symptoms.Count; i++)
            {
                symptomsString.Append(symptoms[i].ToString()); //tried with symptomsString.AppendJoin, it didn't work, so I left it like this
                symptomsString.Append(", ");
            }
            symptomsString.Remove(symptomsString.Length - 2, 2);
            return string.Format("{0} {1} {2}: {3} - {4}",firstName,secondName,lastName,symptomsString,diagnose);
        }

        public void AddSymptom(Symptom symptom) 
        {
            this.symptoms.Add(symptom);
        }

        public void AddSymptom(int n) 
        {
            Symptom temp = (Symptom)(n - 1);
            for (int i = 0; i < symptoms.Count; i++)
            {
                if (symptoms[i]==temp)
                {
                    Console.WriteLine("The symptom is already added.");
                    return;
                }
            }
            switch (n)
            {
                case 1: this.symptoms.Add(Symptom.RunnyNose); break;
                case 2: this.symptoms.Add(Symptom.SoreThroat); break;
                case 3: this.symptoms.Add(Symptom.Headache); break;
                case 4: this.symptoms.Add(Symptom.Coughing); break;
                case 5: this.symptoms.Add(Symptom.Sneezing); break;
                case 6: this.symptoms.Add(Symptom.MuscleAches); break;
                case 7: this.symptoms.Add(Symptom.Vomiting); break;
                case 8: this.symptoms.Add(Symptom.TroubleBreathing); break;
                case 9: this.symptoms.Add(Symptom.LossOfTasteSmell); break;
                case 10: this.symptoms.Add(Symptom.StomachPain); break;
                default:Console.WriteLine("Try using correct symptom index."); break;
            }
        }
        public static string PrintSymptoms() 
        {
            int n = 1;
            StringBuilder symptoms = new StringBuilder();
            foreach (Symptom val in Enum.GetValues(typeof(Symptom)))
            {
                string enumText = ((Symptom)n-1).ToString(); //callind the display prorepty does not work
                symptoms.AppendLine(string.Format("{0}: {1}",n,enumText));
                n++;
            }
            return symptoms.ToString();

        }

        public void AddDiagnose(string diagnose) 
        {
            this.diagnose = diagnose.ToString();
        }
    }
}
