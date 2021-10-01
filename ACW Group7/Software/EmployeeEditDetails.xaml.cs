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
    /// Interaction logic for EmployeeEditDetails.xaml
    /// </summary>
    public partial class EmployeeEditDetails : Window
    {
        /// <summary>
        /// Retrieve logged in user details
        /// </summary>
        private PersonalTrainer _personalTrainer;
        public EmployeeEditDetails(PersonalTrainer pt)
        {
            _personalTrainer = pt;
            InitializeComponent();
            LoadUserDetails();
        }

        /// <summary>
        /// Load up current user details before editing
        /// </summary>
        private void LoadUserDetails()
        {
            D_O_B.Text = _personalTrainer._DOB;
            Email.Text = _personalTrainer._WorkEmail;
            Name1.Text = _personalTrainer._FirstName;
            Rate.Text = _personalTrainer._HourlyRate.ToString();
            foreach (string speciality in _personalTrainer._Specialities)
            {
                Select_Speciality.Items.Add(speciality);
            }
            Select_Speciality.SelectedIndex = 0;

            foreach (string availability in _personalTrainer._Availability)
            {
                Set_Availability.Items.Add(availability);
            }

            Set_Availability.SelectedIndex = 0;

        }

        /// <summary>
        /// closes this window and returns to the dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Saves the newly edited details to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //do some stuff
            _personalTrainer._DOB = D_O_B.Text;
            _personalTrainer._WorkEmail = Email.Text;
            _personalTrainer._FirstName = Name1.Text;
            _personalTrainer._HourlyRate = Convert.ToDecimal(Rate.Text);

            SqlInterfacing sql = new SqlInterfacing();
            sql.UpdatePersonalTrainer(_personalTrainer);
            MessageBox.Show("Details updated successfully");

            this.Close();
        }
    }
}
