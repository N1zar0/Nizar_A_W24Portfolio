using groupproject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace groupprojectgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // ------------ MAIN MENU --------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void customerBtn_Click(object sender, EventArgs e)
        {
            customerPanel.Show();
        }
        private void flightsBtn_Click(object sender, EventArgs e)
        {
            flightPanel.Show();
        }

        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            bookingPanel.Show(); 
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ------------------------ CUSTOMER MAIN MENU -----------------------------

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            addCustPanel.Show();
        }

        private void viewCustomersBtn_Click(object sender, EventArgs e)
        {
            listAllCustomersPanel.Show();

            CustomerManager cm = new CustomerManager();

            customerListLabel.Text = cm.printAllCustomers();
        }
        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            removeCustPanel.Show();
        }
        private void customerBackBtn_Click(object sender, EventArgs e)
        {
            customerPanel.Hide();
        }

        // ------------------------ CUSTOMER ADD CUSTOMER MENU -----------------------------
        private void submitAddCustBtn_Click(object sender, EventArgs e)
        {
            if (firstNameAddCustField.Text == "" || lastNameAddCustField.Text == "" || phoneNumAddCustField.Text == "")
            {

                addCustErrorLabel.Text = "Fill All Fields!";
            }
            else
            {
                CustomerManager cm = new CustomerManager();
                addCustErrorLabel.Text = cm.addCustomer(firstNameAddCustField.Text, lastNameAddCustField.Text, phoneNumAddCustField.Text);
            }

        }

        private void resetAddCustFieldBtn_Click(object sender, EventArgs e)
        {
            firstNameAddCustField.Text = "";
            lastNameAddCustField.Text = "";
            phoneNumAddCustField.Text = "";
        }

        private void goBackToCustMenuMenu1_Click(object sender, EventArgs e)
        {
            addCustPanel.Hide();
            customerPanel.Show();
        }

        // ------------------------ CUSTOMER LIST CUSTOMERS MENU -----------------------------
        private void listAllCustomerBackBtn_Click(object sender, EventArgs e)
        {
            listAllCustomersPanel.Hide();
        }

        // ------------------------ CUSTOMER REMOVE CUSTOMER MENU -----------------------------

        private void submitRemoveCust_Click(object sender, EventArgs e)
        {
            if (removeCustField.Text == "")
            {

                removeCustErrorLabel.Text = "Fill All Fields!";
            }
            else
            {
                CustomerManager cm = new CustomerManager();
                removeCustErrorLabel.Text = cm.removeCustomer(removeCustField.Text);
            }
        }

        private void resetRemoveCustField_Click(object sender, EventArgs e)
        {
            removeCustField.Text = "";
        }

        private void backBtnRemoveCust_Click(object sender, EventArgs e)
        {
            removeCustPanel.Hide();
            customerPanel.Show();
        }

        private void removeCustFillFormLabel_Click(object sender, EventArgs e)
        {

        }

        // ------------------------ FLIGHT MAIN MENU -----------------------------

        private void addFlightBtn_Click(object sender, EventArgs e)
        {
            addFlightPanel.Show();
        }

        private void viewFligthsBtn_Click(object sender, EventArgs e)
        {
            listAllFlightsPanel.Show();

            FlightManager fm = new FlightManager();

            allFlightsLabel.Text = fm.printAllFlights();
        }

        private void viewParticularFlightBtn_Click(object sender, EventArgs e)
        {
            viewParticularFlightPanel.Show();
        }

        private void deleteFlightBtn_Click(object sender, EventArgs e)
        {
            removeFlightPanel.Show();
        }

        private void backFlightBtn_Click(object sender, EventArgs e)
        {
            flightPanel.Hide();
        }

        // ------------------------ FLIGHT ADD FLIGHT MENU -----------------------------


        private void addFlightResetBtn_Click(object sender, EventArgs e)
        {
            flightNumField.Clear();
            departureField.Clear();
            destinationField.Clear();
            aircraftField.Clear();
            flightDateField.Clear();
            seatsField.Clear();
            addFlightErrorLabel.ResetText();
        }

        private void addFlightSubmitBtn_Click(object sender, EventArgs e)
        {
            int parsedValue;
            bool isNumeric = int.TryParse(seatsField.Text, out parsedValue);

            if (flightNumField.Text == "" || departureField.Text == "" || destinationField.Text == "" || aircraftField.Text == "" || flightDateField.Text == "" || seatsField.Text == "")
            {
                addFlightErrorLabel.Text = "Fill In all of the Fields!";
            }
            else if (isNumeric == false)
            {
                addFlightErrorLabel.Text = "Seat Amount Must Be a Number";
            }
            else
            {
                FlightManager fm = new FlightManager();
                int seats = Int16.Parse(seatsField.Text);
                addFlightErrorLabel.Text = fm.addFlight(flightNumField.Text, departureField.Text, destinationField.Text, aircraftField.Text, flightDateLabel.Text, seats);
            }
        }

        private void addFlightBackBtn_Click(object sender, EventArgs e)
        {
            addFlightPanel.Hide();
        }

        // ------------------------ FLIGHT Remove FLIGHT MENU -----------------------------
        private void submitRemoveFlight_Click(object sender, EventArgs e)
        {
            if (removeFlightField.Text == "")
            {
                removeFlightErrorLabel.Text = "Fill All Fields!";
            }
            else
            {
                FlightManager cm = new FlightManager();
                removeFlightErrorLabel.Text = cm.removeFlight(removeFlightField.Text);
            }
        }

        private void removeFlightResetField_Click(object sender, EventArgs e)
        {
            removeFlightField.Text = "";
        }

        private void removeFlightBackButton_Click(object sender, EventArgs e)
        {
            removeFlightPanel.Hide();
        }

        // ------------------------ FLIGHT VIEW PARTICULAR FLIGHT MENU -----------------------------

        private void viewParticularFlightSubmit_Click(object sender, EventArgs e)
        {
            if (viewParticularFlightField.Text == "")
            {
                viewParticularFlightErrorLabel.Text = "Fill All Fields!";
            }
            else
            {
                FlightManager cm = new FlightManager();
                viewParticularFlightDisplayFlightLabel.Text = cm.viewFlight(viewParticularFlightField.Text);
            }
        }

        private void viewParticularFlightReset_Click(object sender, EventArgs e)
        {
            viewParticularFlightField.ResetText();
        }

        private void viewParticularFlightBack_Click(object sender, EventArgs e)
        {
            viewParticularFlightPanel.Hide();
        }

        // -------------- LIST OF ALL FLIGHTS MENU -------------

        private void listOfAllFlightsBackBtn_Click(object sender, EventArgs e)
        {
            listAllFlightsPanel.Hide();
        }

        // ----------- BOOKING MENU ------------------
        private void makeBookingBtn_Click(object sender, EventArgs e)
        {
            makeBookingPanel.Show();
        }

        private void viewBookingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void bookingBackBtn_Click(object sender, EventArgs e)
        {
            bookingPanel.Hide();
        }


        // ----------- BOOKING MAKE BOOKING MENU ----------
        private void customerIdBookingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void flightNumberBookingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void makeBookingSubmitBtn_Click(object sender, EventArgs e)
        {
            if(flightNumberBookingTextBox.Text == "" || customerIdBookingTextBox.Text == "")
            {
                makeBookingErrorLabel.Text = ("Please fill in all of the fields");
            }
            else
            {
                BookingManager bm = new BookingManager();
                bm.addBooking(customerIdBookingTextBox.Text, flightNumberBookingTextBox.Text);
                makeBookingErrorLabel.Text = ("Booking Added Successfully");
            }
        }

        private void makeBookingResetBtn_Click(object sender, EventArgs e)
        {
            customerIdBookingTextBox.Clear();
            flightNumberBookingTextBox.Clear();
            makeBookingErrorLabel.Text = string.Empty;
        }

        private void makeBookingBackBtn_Click(object sender, EventArgs e)
        {
            makeBookingPanel.Hide();
        }
    }
}
