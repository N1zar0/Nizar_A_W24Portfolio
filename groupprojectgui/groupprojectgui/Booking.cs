using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class Booking
    {
       private int bookingID;
       Customer customer;
       Flight flight;
       private string date;

        public Booking(int bookingID, Customer customer, Flight flight, string date)
        {
            bookingID = 100;
        }

        public override string ToString()
        {
            string s = "Booking ID: " + bookingID;
            s += "Date: " + date;
            return s;
        }

    }
}
