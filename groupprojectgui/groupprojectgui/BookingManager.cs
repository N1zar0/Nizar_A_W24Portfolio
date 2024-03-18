using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class BookingManager
    {   
        public string addBooking(string customerId, string flightNumber)
        {
            // create objects to use their functions
            CustomerManager customer = new CustomerManager();
            FlightManager flight = new FlightManager();
            Utilities util = new Utilities();
            //find Customer function and find flight function
            int locCustomer = customer.findCustomer(customerId);
            int locFlight = flight.findFlight(flightNumber);
            // get current date
            string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            //if customer or flight not found return error message
            if (locCustomer == -1 || locFlight == -1)
            {
                return "Customer or Flight not found";
            }
            
            // read all lines in customers file
            string[] customers = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");
            ///split the found customer
            var splitCustomers = customers[locCustomer].Split(',');
            // get the booking amount from the customer (the 5ths value in the string always) and turn it into an int
            int bookingsAmt = Int16.Parse(splitCustomers[4]);
            //add one to the booking amount because we just made a booking
            bookingsAmt++;
            //turn the booking amount back into a string so we can write it into file
            splitCustomers[4] = bookingsAmt.ToString();

            //combine the new booking amount with the other parts of the customer into one string
            string combineCustomer
                = splitCustomers[0] + ","
                + splitCustomers[1] + ","
                + splitCustomers[2] + ","
                + splitCustomers[3] + ","
                + splitCustomers[4];

            //read all lines in the flight file
            string[] flights = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt");

            //split the found flight
            var splitFlights = flights[locFlight].Split(',');
            // get the seat amount from the plane and turn it into a num
            int seatsInt = Int16.Parse(splitFlights[5]);

            if (seatsInt == 0)
            {
                return "No seats available on this flight";
            }

            //if plane has seats remove a seat
            seatsInt--;
            //turn num back into string
            splitFlights[5] = seatsInt.ToString();

            //combine plane witht he updates seat amount
            string combineFlight
                = splitFlights[0] + ","
                + splitFlights[1] + ","
                + splitFlights[2] + ","
                + splitFlights[3] + ","
                + splitFlights[4] + ","
                + splitFlights[5];

            //if the booking file is empty, set the booking id to 1000 and put the rest of the info in
            if (new FileInfo("C:\\comp2129\\groupprojectgui\\groupprojectgui\\bookings.txt").Length == 0)
            {   
                //use the change line function to update the customer and flight files
                util.changeLine(combineCustomer, "C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt", locCustomer);
                util.changeLine(combineFlight, "C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt", locFlight);

                //use stream writer in append to save info to file
                using (StreamWriter writetext = File.AppendText("C:\\comp2129\\groupprojectgui\\groupprojectgui\\bookings.txt"))
                {
                    //append booking the new booking to file with all the data
                    writetext.WriteLine(1000 + "," + customerId + "," + flightNumber + "," + date);
                }
                return "Booking added successfully";
            }
            //else take the last line from the booking file and add 1 to the booking id and put the info in
            else
            {   
                //get the last line from bookings
                var lastLine = File.ReadLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\bookings.txt").Last();
                //split the line
                var lastNumber = lastLine.Split(',');
                //all get the booking id and turn it into an int
                int bookingNumber = Int16.Parse(lastNumber[0]);
                //add 1 to it
                bookingNumber++;

                //use changeline function to update customer and flight with their new info
                util.changeLine(combineCustomer, "C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt", locCustomer);
                util.changeLine(combineFlight, "C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt", locFlight);

                //use stream writer in append mode to append the new data to bookings.txt
                using (StreamWriter writetext = File.AppendText("C:\\comp2129\\groupprojectgui\\groupprojectgui\\bookings.txt"))
                {   
                    //turn the booking number back into a string so we can append to file
                    string numberString = bookingNumber.ToString();
                    writetext.WriteLine(numberString + "," + customerId + "," + flightNumber + "," + date);
                }
                return "Booking successful";
            }
        }

        public string printAllBookings()
        {
            //read all lines in customer
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\customers.txt");

            //empty string to save into
            string s = "";

            // loop through every customer
            for (int i = 0; i < lines.Length; i++)
            {
                //split them and add a description to each attribute they have
                string[] linesSplit = lines[i].Split(',');
                s += "\nBookingn ID: " + linesSplit[0];
                s += "\nCustomer Number: " + linesSplit[1];
                s += "\nPlane Number: " + linesSplit[2];
                s += "\nDate: " + linesSplit[3];
                s += "\n";
            }
            return s;
        }
    }
}