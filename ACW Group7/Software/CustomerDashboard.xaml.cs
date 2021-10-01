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
using System.Windows.Shapes;
using UserClasses;

namespace Software
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : Window
    {
        private Customer _customer;

        /// <summary>
        /// Retrieve logged in customers details
        /// </summary>
        /// <param name="cust"></param>
        public CustomerDashboard(Customer cust)
        {
            _customer = cust;
            InitializeComponent();
        }

        /// <summary>
        /// Open the window to create a booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            CustomerBookingPage customerBookingPage = new CustomerBookingPage(_customer);
            customerBookingPage.Show();
        }

        /// <summary>
        ///  Closes the current window and returns to the customer dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the editaccountdetails window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            CustomerEditDetails customerEditDetails = new CustomerEditDetails(_customer);
            customerEditDetails.Show();
        }

        /// <summary>
        /// opens the customerBookingDetails window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewBookedSessions_Click(object sender, RoutedEventArgs e)
        {
            CustomerBookingDetails customerBookingDetails = new CustomerBookingDetails(_customer);
            customerBookingDetails.Show();
        }
    }
}
