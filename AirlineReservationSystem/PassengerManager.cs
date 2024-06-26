﻿using AirlineReservationSystem.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace AirlineReservationSystem
{
    internal class PassengerManager
    {
        /// <summary>
        /// A list of passengers
        /// </summary>
        private List<Passenger> passengers = new List<Passenger>();

        /// <summary>
        /// A list of passengers
        /// </summary>
        public List<Passenger> Passengers { get { return passengers; } private set { passengers = value; } }

        /// <summary>
        /// The database
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Create a new PassengerManager
        /// </summary>
        /// <param name="db"></param>
        public PassengerManager(clsDataAccess db)
        {
            this.db = db;
        }

        /// <summary>
        /// Return the list of passengers
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public List<Passenger> GetPassengers(int flightId)
        {
            try
            {
                // Dataset
                DataSet ds;

                string sql = clsSQL.GetPassengers(flightId.ToString());

                // Execute sql
                int rows = 0;
                ds = db.ExecuteSQLStatement(sql, ref rows);

                //Show the data
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = 0;
                    string firstName = String.Empty;
                    string lastName = String.Empty;

                    id = (int)row.ItemArray[0];
                    firstName = (string)row.ItemArray[1];
                    lastName = (string)row.ItemArray[2];

                    Passenger passenger = new Passenger(id, firstName, lastName);
                    Passengers.Add(passenger);
                }
                return Passengers;
            }
            catch (Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
                return null;
            }
        }

    }
}
