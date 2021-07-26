using System;
using System.Collections.Generic;
using System.Text;

namespace AmISick
{
    class PatientsManager
    {
        private List<Patient> patientManager;

        public List<Patient> PatientManager{set;get;}

        public PatientsManager() 
        {
            this.patientManager = new List<Patient>();
        }
        public PatientsManager(List<Patient>patients) 
        {
            this.patientManager = patients;
        }

    }
}
