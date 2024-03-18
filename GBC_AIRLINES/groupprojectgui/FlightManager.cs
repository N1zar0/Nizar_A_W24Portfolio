using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class FlightManager
    {
        public string addFlight(string flightnumber, string departureAirport, string destinationAirport, string aircraft, string flightDate, int seats)
        {
            //read all lines in flight
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt");

            //check if flight alreaady exists and return error if it does
            for (int x = 0; x < lines.Length; x++)
            {
                string[] linesSplit = lines[x].Split(',');
                if (linesSplit[0] == flightnumber 
                    && linesSplit[1] == departureAirport 
                    && linesSplit[2] == destinationAirport 
                    && linesSplit[3] == aircraft 
                    && linesSplit[4] == flightDate)
                    return "Flight Already Exists";
            }
            //append flight info to file
            using (StreamWriter writetext = File.AppendText("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt"))
            {       
                writetext.WriteLine(flightnumber + "," + departureAirport + "," + destinationAirport + "," + aircraft + "," + flightDate + "," + seats);
            }
            return "Flight Added Successfully";
        }

        public int findFlight(string flightNumber)
        {   
            //read all lines in flight
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt");

            //loop through all the lines and fine the specific flight by its flight number
            for (int x = 0; x < lines.Length; x++)
            {
                //split flight and compare flight number
                string[] linesSplit = lines[x].Split(',');
                if (linesSplit[0] == flightNumber)
                    return x;
            }
            return -1;
        }

        public string removeFlight(string flightNumber)
        {
            //check if flight exists
            int loc = findFlight(flightNumber);

            //if flight does not exist return error
            if (loc == -1) return "Flight does not exist";

            //if there is an active booking on the plane return error
            string[] activeBookings = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\bookings.txt");
            for (int x = 0; x < activeBookings.Length; x++)
            {   
                //check if there is a booking
                string[] bookingSplit = activeBookings[x].Split(',');
                if (bookingSplit[2] == flightNumber)
                    return "Flight has an active booking(s)";
            }
            
            //read all the flights
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\fligths.txt");
            //make a temp file
            var tempFile = Path.GetTempFileName();
            //remove line
            var keepLines = File.ReadLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt").Where(l => l != lines[loc]);
            //write the line
            File.WriteAllLines(tempFile, keepLines);
            //move the files
            File.Delete(("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt"));
            File.Move(tempFile, ("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt"));
            return "Flight removed successfully";
        }

        public string viewFlight(string flightNumber)
        {   
            //if cant find flight return error
            int loc = findFlight(flightNumber);

            if (loc == -1)
            {
                return "No flight";
            }

            //view flight split it and write into string
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt");

            string[] linesSplit = lines[loc].Split(',');

            string s = "Flight Number: " + linesSplit[0];
            s += "\nDeparture Airport: " + linesSplit[1];
            s += "\nDestination Airport: " + linesSplit[2];
            s += "\nAircraft: " + linesSplit[3];
            s += "\nDate: " + linesSplit[4];
            s += "\nSeat Capacity: " + linesSplit[5];
            s += "\n";

            return s;
        }

        public string printAllFlights()
        {
            //
            string[] lines = File.ReadAllLines("C:\\comp2129\\groupprojectgui\\groupprojectgui\\flights.txt");

            string s = "";

            for (int i = 0; i < lines.Length; i++)
            {

                string[] linesSplit = lines[i].Split(',');

                s += "\nFlight Number: " + linesSplit[0];
                s += "\nDeparture Airport: " + linesSplit[1];
                s += "\nDestination Airport: " + linesSplit[2];
                s += "\nAircraft: " + linesSplit[3];
                s += "\nSeat Capacity: " + linesSplit[4];
                s += "\n";
            }
            return s;
        }

    }
}
