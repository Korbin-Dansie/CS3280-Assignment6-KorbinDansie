using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    internal class Flight
    {
        private int _flightId;
        private string _flightNumber;
        private string _aircraftType;

        public int FlightId { get { return _flightId; } set { _flightId = value; } }
        public string FlightNumber { get { return _flightNumber; } set { _flightNumber = value; } }
        public string AircraftType { get { return _aircraftType; } set { _aircraftType = value; } }

        public Flight()
        {
            try
            {
                FlightId = 0;
                FlightNumber = String.Empty;
                AircraftType = String.Empty;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        public Flight(int flightId, string flightNumber, string aircraftType)
        {
            try
            {
                FlightId = flightId;
                FlightNumber = flightNumber;
                AircraftType = aircraftType;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        public override string ToString()
        {
            try
            {
                return AircraftType + " - " + FlightNumber;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                return null;
            }
        }
    }
}
