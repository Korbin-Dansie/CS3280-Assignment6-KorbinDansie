using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    internal class Flight
    {
        private string _flightID = String.Empty;
        private string _flightNumber = String.Empty;
        private string _AircraftType = String.Empty;

        public string FlightID { get { return _flightID; } set { _flightID = value; } }
        public string FlightNumber { get { return _flightNumber; } set { _flightNumber = value; } }
        public string AircraftType { get { return _AircraftType; } set { _AircraftType = value; } }


        public override string ToString()
        {
            return FlightNumber;
        }
    }
}
