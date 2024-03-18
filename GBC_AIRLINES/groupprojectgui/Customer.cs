using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phoneNum;

        public Customer(string firstName, string lastName, string phoneNum)
        {
            id = 100;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNum = phoneNum;
        }

        public override string ToString()
        {
            string s = "Customer ID:" + id;
            s += "\nFirst Name: " + firstName;
            s += "\nLast Name: " + lastName;
            s += "\nPhone Number: " + phoneNum;
            s += "\n";
            return s;
        }

    }
}
