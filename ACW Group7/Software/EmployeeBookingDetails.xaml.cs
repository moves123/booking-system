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
    /// Interaction logic for EmployeeBookingDetails.xaml
    /// </summary>
    public partial class EmployeeBookingDetails : Window
    {
        private PersonalTrainer _personalTrainer;
        SqlInterfacing sqlInterfacing = new SqlInterfacing();
        public EmployeeBookingDetails(PersonalTrainer pt)
        {
            _personalTrainer = pt;
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            List<BusinessLogic.CreateAppointment> appointmentsList = sqlInterfacing.GetStaffAppointmentDetails(_personalTrainer._UniqueID);
            BookedSessionsDataGrid.ItemsSource = appointmentsList;
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

        private void CancelSessionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
