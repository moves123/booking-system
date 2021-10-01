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
    /// Interaction logic for EmployeeBookingPage.xaml
    /// </summary>
    public partial class EmployeeBookingPage : Window
    {
        private PersonalTrainer _personalTrainer;
        private List<Tuple<string, string>> _customerList;
        public EmployeeBookingPage(PersonalTrainer pt)
        {
            _personalTrainer = pt;
            InitializeComponent();
            LoadDetails();
        }

        /// <summary>
        /// close this window and return to the dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Creates a booking for a member of staff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            string hasPaid = string.Empty;

            if(PaidCheckbox.IsChecked == true)
            {
                hasPaid = "True";
            }
            else if(PaidCheckbox.IsChecked == false)
            {
                hasPaid = "False";
            }

            string timeSlot = AvailableTimes.SelectedItem.ToString();

            string [] b = timeSlot.Split('-');
            string startTime = b[0].ToString();
            string endTime = b[1].ToString();
            string notes = NotesTextBox.Text;
            string customerUsername = SelectCustomer.SelectedValue.ToString();
            string customerID = GetUserID(customerUsername);
            string date = Date.SelectedDate.ToString();
            SqlInterfacing sql = new SqlInterfacing();


            //string appointmentID = _personalTrainer._UserName.Substring(0,3) +"-"+ DateTime.Now.ToShortDateString() + SelectCustomer.SelectedValue.ToString().Substring(0,3);
            string appointmentID = BusinessLogic.Util.generateGuid().ToString();
            BusinessLogic.CreateAppointment createAppointment = new BusinessLogic.CreateAppointment(appointmentID,_personalTrainer._UniqueID,hasPaid,startTime,endTime,customerID,notes,date);
            bool sessionAvailable = sql.CheckIfStaffSessionAvailable(createAppointment);
            if (sessionAvailable)
            {
                sql.InsertAppointment(createAppointment);
                MessageBox.Show("Session booked successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("You already have an appointment with that customer in this date/time slot!");
            }
            
        }

        private string GetUserID(string userName)
        {
            foreach (Tuple<string,string> user in _customerList)
            {
                if (user.Item2 == userName)
                {
                    return user.Item1;
                }
            }

            return null;
        }

        private void LoadDetails()
        {
            HourlyRateTextblock.Text = _personalTrainer._HourlyRate.ToString();

            Select_SpecialityCombobox.Items.Clear();
            List<string> specialities = _personalTrainer._Specialities;
            foreach (string x in specialities)
            {
                Select_SpecialityCombobox.Items.Add(x);
            }
            Select_SpecialityCombobox.SelectedIndex = 0;

            foreach (string availability in _personalTrainer._Availability)
            {
                AvailableTimes.Items.Add(availability);
            }
            SqlInterfacing sql = new SqlInterfacing();
            List<Tuple<string, string>> customers = sql.GetCustomers();
            _customerList = customers;
            foreach (Tuple<string,string> customer in _customerList)
            {
                SelectCustomer.Items.Add(customer.Item2);
            }

        }
    }
}
