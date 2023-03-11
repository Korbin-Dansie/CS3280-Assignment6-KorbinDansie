using AirlineReservationSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlineReservationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Data Connection
        /// </summary>
        clsDataAccess db;

        FlightManager flightManager;

        public MainWindow()
        {
            InitializeComponent();
            db = new clsDataAccess();
            flightManager = new FlightManager(db);

            cbFlight.ItemsSource = flightManager.getFlights();
        }
    }
}
