using AirlineReservationSystem.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    internal class FlightManager
    {
        private List<Flight> flights = new List<Flight>();

        public List<Flight> Flights { get { return flights; } private set { flights = value; }}

        public clsDataAccess db;

        public FlightManager(clsDataAccess db)
        {
            this.db = db;
        }

        public List<Flight> getFlights()
        {
            // Dataset
            DataSet ds;

            string sql = clsSQL.GetFlights();

            // Execute sql
            int rows = 0;
            ds = db.ExecuteSQLStatement(sql, ref rows);

            //Show the data


            // Loop through DataSet, for each Row, Create a new Flight, fill it up, add it to the list
            return Flights;


        }
    }
}
