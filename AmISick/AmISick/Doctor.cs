using System;
using System.Collections.Generic;
using System.Text;

namespace AmISick
{
    class Doctor
    {
        private string firstName;
        private string lastName;
        private string password;

        public string FirstName
        {
            get { return this.firstName;  }
        }
        public string LastName
        {
            get { return this.lastName; }
        }
        public string Password
        {
            get { return this.password; }
        }
        public Doctor() 
        {
            this.firstName = "Unknown";
            this.lastName = "Unknown";
            this.password = "Unknown";
        }

        public Doctor(string firstName, string lastName, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
        }

        public override string ToString()
        {
            return string.Format(" diagnosed by Dr.{0} {1}", firstName, lastName);
        }
    }
}
