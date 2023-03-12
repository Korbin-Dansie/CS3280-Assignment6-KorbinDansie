using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Resources
{
    internal class Passenger
    {
        private int _passengerId;
        private string _passengerFirstName;
        private string _passengerLastName;

        public int PassengerId { get { return _passengerId; } set { _passengerId = value; } }
        public string PassengerFirstName { get { return _passengerFirstName; } set { _passengerFirstName = value; } }
        public string PassengerLastName { get { return _passengerLastName; } set { _passengerLastName = value; } }


        public Passenger()
        {
            PassengerId = 0;
            PassengerFirstName = String.Empty;
            PassengerLastName = String.Empty;
        }

        public Passenger(int passengerId, string passengerFirstName, string passengerLastName)
        {
            PassengerId = passengerId;
            PassengerFirstName = passengerFirstName;
            PassengerLastName = passengerLastName;
        }

        public override string ToString()
        {
            return  PassengerFirstName + " " + PassengerLastName;
        }
    }
}
