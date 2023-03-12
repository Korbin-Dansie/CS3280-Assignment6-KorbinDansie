using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    internal class Flight
    {
        private int _flightId = 0;
        private string _flightNumber = String.Empty;
        private string _aircraftType = String.Empty;

        public int FlightId { get { return _flightId; } set { _flightId = value; } }
        public string FlightNumber { get { return _flightNumber; } set { _flightNumber = value; } }
        public string AircraftType { get { return _aircraftType; } set { _aircraftType = value; } }

        public Flight()
        {
        }

        public Flight(int flightId, string flightNumber, string aircraftType)
        {
            FlightId = flightId;
            FlightNumber = flightNumber;
            AircraftType = aircraftType;
        }

        public override string ToString()
        {
            return AircraftType + " - " + FlightNumber;
        }
    }
}
