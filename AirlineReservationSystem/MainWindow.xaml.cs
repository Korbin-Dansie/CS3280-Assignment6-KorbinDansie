using AirlineReservationSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// A list of passengers
        /// </summary>
        AddPassengerWindow addPassengerWindow;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                // Disable UI
                toggleUIComponents(false);

                //MAKE SURE TO INCLUDE THIS LINE OR THE APPLICATION WILL NOT CLOSE
                //BECAUSE THE WINDOWS ARE STILL IN MEMORY
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                //Create new windows
                addPassengerWindow = new AddPassengerWindow();

                db = new clsDataAccess();

                // Get the flights from the data base
                flightManager = new FlightManager(db);

                // Hide both canvases until user choosies one
                c380.Visibility = Visibility.Collapsed;
                c767.Visibility = Visibility.Collapsed;


                // Load the flights into the combobox
                cbFlight.Items.Clear();
                cbFlight.ItemsSource = flightManager.getFlights();

                // Set the selected item equal to the one currently displayed
            }
            catch(Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Toggle the visibility of the two canvases
        /// </summary>
        /// <param name="is767Visible"></param>
        private void toggleFlightCanvases(bool is767Visible)
        {
            try
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
            catch(Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }

        }

        /// <summary>
        /// When the selection changes update which canavs shows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Flight? flight = cbFlight.SelectedItem as Flight;

                // If flight is null exit
                if (flight == null)
                {
                    return;
                }

                // Display the correct canvas
                if (flight.AircraftType == "Boeing 767")
                {
                    toggleFlightCanvases(true);
                }
                else
                {
                    toggleFlightCanvases(false);
                }

                // Fill in the passanger combo box
                PassengerManager passengers = new PassengerManager(db);
                passengers.GetPassengers(flight.FlightId);

                // Add the passangers to the combo box
                cbPassenger.ItemsSource = passengers.Passengers;

            }
            catch(Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Toggle enable on all UI components exept for choose flight
        /// </summary>
        /// <param name="isEnabled"></param>
        private void toggleUIComponents(bool isEnabled)
        {
            try
            {
                cbPassenger.IsEnabled = isEnabled;

                btnChangeSeat.IsEnabled = isEnabled;
                btnAddPassenger.IsEnabled = isEnabled;
                btnDeletePassenger.IsEnabled = isEnabled;

            }
            catch(Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }

        /// <summary>
        /// Add a passenger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                relocateWindow(addPassengerWindow, this);
                addPassengerWindow.ShowDialog();
                relocateWindow(this, addPassengerWindow);
                this.Show();
            }
            catch(Exception ex)
            {
                ErrorHandling.handleError(MethodInfo.GetCurrentMethod(), ex);
            }
        }


        /// <summary>
        /// Relocate the windows to match
        /// </summary>
        /// <param name="toWindow"></param>
        /// <param name="fromWindow"></param>
        private void relocateWindow(Window toWindow, Window fromWindow)
        {
            try
            {
                toWindow.Left = fromWindow.Left;
                toWindow.Top = fromWindow.Top;
            }
            catch(Exception ex)
            {
                ErrorHandling.throwError(MethodInfo.GetCurrentMethod(), ex);
            }
        }
    }
}
