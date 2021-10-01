using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Interaction logic for CustomerBookingPage.xaml
    /// </summary>
    public partial class CustomerBookingPage : Window
    {
        
        private List<string> ptList = new List<string>();
        private Customer _customer;

        /// <summary>
        ///  Private set up method to generate UI components
        /// </summary>
        private void Setup()
        {
            SqlInterfacing sqlInterfacing = new SqlInterfacing();
            ptList = sqlInterfacing.GetPersonalTrainers();

            foreach(string x in ptList)
            {
                SelectPTCombobox.Items.Add(x);
            }

            SelectPTCombobox.SelectedIndex = 0;
        }



        public CustomerBookingPage(Customer cust)
        {
            _customer = cust;
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Return to previous screen and close current window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnBookSession_Click(object sender, RoutedEventArgs e)
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
            if (AvailableTimesListBox.SelectedItem!=null)
            {
                SqlInterfacing sqlInterfacing = new SqlInterfacing();
                string timeSlot = AvailableTimesListBox.SelectedItem.ToString();

                string[] b = timeSlot.Split('-');
                string startTime = b[0].ToString();
                string endTime = b[1].ToString();
                string notes = NotesTextBox.Text;
                string date = BookingDatePicker.SelectedDate.ToString();



                PersonalTrainer personalTrainer = sqlInterfacing.GetStaffMember(SelectPTCombobox.SelectedValue.ToString());
                // Returns the PT object from the datareader



                //string appointmentID = SelectPTCombobox.SelectedValue.ToString().Substring(0, 3) + "-" + DateTime.Now.ToShortDateString() + _customer._FirstName.Substring(0, 3);
                string appointmentID = BusinessLogic.Util.generateGuid().ToString();
                BusinessLogic.CreateAppointment createAppointment = new BusinessLogic.CreateAppointment(appointmentID, personalTrainer._UniqueID, hasPaid, startTime, endTime, _customer._UniqueID, notes,date);
                bool sessionAvailable = sqlInterfacing.CheckIfSessionAvailable(createAppointment);
                if (sessionAvailable)
                {
                    sqlInterfacing.InsertAppointment(createAppointment);
                    MessageBox.Show("Session booked succesfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("That date/time slot is not available for this PT");
                }
                
                
            }
            else
            {
                MessageBox.Show("Please select a time slot");
            }
            
        }

        /// <summary>
        /// When the selection of a PT changes the specialities of that PT
        /// are read from the database and fills the combobox with the options 
        /// relevant to that PT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectPTCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlInterfacing sqlInterfacing = new SqlInterfacing();
            List<string> temp = sqlInterfacing.GetPersonalTrainersSpecialities(SelectPTCombobox.SelectedValue.ToString());
            Select_SpecialityCombobox.Items.Clear();
            foreach (string x in temp)
            {
                Select_SpecialityCombobox.Items.Add(x);
            }
            Select_SpecialityCombobox.SelectedIndex = 0;
        
            List<string> tempAvailablityList = sqlInterfacing.GetPersonalTrainersAvailabilities(SelectPTCombobox.SelectedValue.ToString());
            string a = BusinessLogic.Util.GetStringFromList(tempAvailablityList);
            List<string> list = BusinessLogic.Util.GetListFromString(a);
            AvailableTimesListBox.ItemsSource = list;


         PersonalTrainer personalTrainer = sqlInterfacing.GetStaffMember(SelectPTCombobox.SelectedValue.ToString());
//
          HourlyRateTextblock.Text = personalTrainer._HourlyRate.ToString();


        }
    }
}
