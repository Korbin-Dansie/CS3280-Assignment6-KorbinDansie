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
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int id = 0;
                string flightNumber = String.Empty;
                string aircraftType = String.Empty;

                id = (int)row.ItemArray[0];
                flightNumber = (string)row.ItemArray[1];
                aircraftType = (string)row.ItemArray[2];

                Flight flight = new Flight(id, flightNumber, aircraftType);
                Flights.Add(flight);
            }

            // Loop through DataSet, for each Row, Create a new Flight, fill it up, add it to the list
            return Flights;
        }
    }
}
