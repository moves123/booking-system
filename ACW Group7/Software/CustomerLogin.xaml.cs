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
using BusinessLogic;
using UserClasses;

namespace Software
{
    /// <summary>
    /// Interaction logic for CustomerLogin.xaml
    /// </summary>
    public partial class CustomerLogin : Window
    {

        private void Setup()
        {
            Username.Focus();
        }

		public CustomerLogin()
		{
			InitializeComponent();
            Setup();
		}

        /// <summary>
        /// Login with password verification, checks the password hash generated from the 
        /// encryption class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{
			string authPass = PasswordBox.Password;
			SqlInterfacing sqlInterface = new SqlInterfacing();
			SQLiteDataReader results = sqlInterface.GetCustomer(Username.Text);
			if (results.HasRows)
			{
				Customer user = Customer.CustomerFromDB(results);

				if (user.VerifyPassword(authPass))
				{
					CustomerDashboard customerDashboard = new CustomerDashboard(user);
					customerDashboard.Show();
				}
				else
				{
					MessageBox.Show("Invalid Username or Password");
				}
			}
			else
			{
				MessageBox.Show("Invalid Username or Password");
			}
		}

        /// <summary>
        /// close this window and return to the main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}


        /// <summary>
        /// Opens the create a user account window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }
    }
}