using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupproject
{
    class Flight
    {
        private string flightNumber;
        private string departureAirport;
        private string destinationAirport;
        private string aircraft;
        private string flightDate;
        private int seats;

        public Flight(string flightNumber, string departureAirport, string destinationAirport, string aircraft, string flightDate, int seats)
        {
            this.flightNumber = flightNumber;
            this.flightDate = flightDate;
            this.departureAirport= departureAirport;
            this.destinationAirport = destinationAirport;
            this.aircraft = aircraft;
            this.flightDate = flightDate;
            this.seats = seats;
        }
        
        public override string ToString()
        {
            string s = "Flight Number: " + flightNumber;
            s += "\nDeparture Airport: " + departureAirport;
            s += "\nDestination Airport: " + destinationAirport;
            s += "\nAircraft: " + aircraft;
            s += "\nSeat Capacity: " + seats;
            s += "\n";
            return s;
        }

    }
}