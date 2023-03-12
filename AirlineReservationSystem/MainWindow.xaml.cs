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

        /// <summary>
        /// A list of flights
        /// </summary>
        FlightManager flightManager;

        public MainWindow()
        {
            InitializeComponent();
            // Disable UI
            toggleUIComponents(false);

            db = new clsDataAccess();

            // Get the flights from the data base
            flightManager = new FlightManager(db);

            // Hide both canvases until user choosies one
            c380.Visibility = Visibility.Collapsed;
            c767.Visibility = Visibility.Collapsed;


            // Load the flights into the combobox
            cbFlight.ItemsSource = flightManager.getFlights();

            // Set the selected item equal to the one currently displayed
        }

        /// <summary>
        /// Toggle the visibility of the two canvases
        /// </summary>
        /// <param name="is767Visible"></param>
        private void toggleFlightCanvases(bool is767Visible)
        {
            if (is767Visible)
            {
                c380.Visibility = Visibility.Collapsed;
                c767.Visibility = Visibility.Visible;
            }
            else
            {
                c380.Visibility = Visibility.Visible;
                c767.Visibility = Visibility.Collapsed;
            }
            toggleUIComponents(true);
        }

        /// <summary>
        /// When the selection changes update which canavs shows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flight? flight = cbFlight.SelectedItem as Flight;

            // If flight is null exit
            if(flight == null)
            {
                return;
            }

            if(flight.AircraftType == "Boeing 767")
            {
                toggleFlightCanvases(true);
            }
            else
            {
                toggleFlightCanvases(false);
            }
        }

        /// <summary>
        /// Toggle enable on all UI components exept for choose flight
        /// </summary>
        /// <param name="isEnabled"></param>
        private void toggleUIComponents(bool isEnabled)
        {
            cbPassenger.IsEnabled = isEnabled;

            btnChangeSeat.IsEnabled = isEnabled;
            btnAddPassenger.IsEnabled = isEnabled;
            btnDeletePassenger.IsEnabled = isEnabled;
        }
    }
}
