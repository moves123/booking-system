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
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        private PersonalTrainer _personalTrainer;
        /// <summary>
        /// Retrieve logged in user details
        /// </summary>
        /// <param name="pt"></param>
        public EmployeeDashboard(PersonalTrainer pt)
        {
            _personalTrainer = pt;
            InitializeComponent();
        }

        /// <summary>
        /// closes the current window and returns to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Opens the booking window for employees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            EmployeeBookingPage employeeBookingPage = new EmployeeBookingPage(_personalTrainer);
            employeeBookingPage.Show();
        }

        /// <summary>
        /// Opens the edit account details window
        /// allowing staff to change their personal details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditDetails employeeEditDetails = new EmployeeEditDetails(_personalTrainer);
            employeeEditDetails.Show();
        }

        /// <summary>
        /// Opens a window so the staff member can view all current bookings
        /// that they have
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewBooked_Click(object sender, RoutedEventArgs e)
        {
            EmployeeBookingDetails employeeBookingDetails = new EmployeeBookingDetails(_personalTrainer);
            employeeBookingDetails.Show();
        }
    }
}
