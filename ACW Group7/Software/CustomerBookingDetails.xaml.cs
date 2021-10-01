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
    /// Interaction logic for CustomerBookingDetails.xaml
    /// </summary>
    public partial class CustomerBookingDetails : Window
    {
        SqlInterfacing sqlInterfacing = new SqlInterfacing();
        private Customer _cust;


        private void Setup()
        {
            List<BusinessLogic.CreateAppointment> appointmentsList = sqlInterfacing.GetAppointmentDetails(_cust._UniqueID);
            BookedSessionsDataGrid.ItemsSource = appointmentsList;
        }

        public CustomerBookingDetails(Customer cust)
        {
            _cust = cust;
            InitializeComponent();
            Setup();

        }


        /// <summary>
        /// Closes the window
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
