using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    internal class clsSQL
    {
        public static string GetFlights()
        {
            try
            {
                string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        public static string GetPassengers(string sFlightID)
        {
            try
            {
                string sSql = "SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
                                "FROM Passenger, Flight_Passenger_Link FPL " +
                                "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
                                "Flight_ID = " + sFlightID;
                return sSql;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}
