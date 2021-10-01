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
    /// Interaction logic for CustomerEditDetails.xaml
    /// </summary>
    public partial class CustomerEditDetails : Window
    {
        private Customer _customer;

        /// <summary>
        /// retrieve logged in customers details
        /// </summary>
        /// <param name="cust"></param>
        public CustomerEditDetails(Customer cust)
        {
            _customer = cust;
            InitializeComponent();
            LoadUserDetails();
            
        }

        /// <summary>
        /// closes the current window and returns to the dashboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Confirms change of details and updates the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //do some stuff
            _customer._DOB = D_O_B.Text;
            _customer._Email = Email.Text;
            _customer._FirstName = Name1.Text;
            _customer._PhoneMobile = Telephone.Text;

            SqlInterfacing sql = new SqlInterfacing();
            sql.UpdateCustomer(_customer);
            MessageBox.Show("Details updated successfully");

            this.Close();
        }

        /// <summary>
        /// Load current user details before editing
        /// </summary>
        private void LoadUserDetails()
        {
            D_O_B.Text = _customer._DOB;
            Email.Text = _customer._Email;
            Name1.Text = _customer._FirstName;
            Telephone.Text = _customer._PhoneMobile;
        }
    }
}
