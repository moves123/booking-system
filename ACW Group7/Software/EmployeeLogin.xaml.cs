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
	/// Interaction logic for EmployeeLogin.xaml
	/// </summary>
	public partial class EmployeeLogin : Window
	{
		public EmployeeLogin()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Verifies users details and logs in if they are correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{
			string authPass = Password.Password;
			SqlInterfacing sqlinterface = new SqlInterfacing();
			SQLiteDataReader results = sqlinterface.GetStaffMemberReader(Username.Text);
			if (results.HasRows)
			{
				PersonalTrainer user = PersonalTrainer.PTFromDB(results);

				if (user.VerifyPassword(authPass))
				{
					EmployeeDashboard employeeDashboard = new EmployeeDashboard(user);
					employeeDashboard.Show();
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
        /// Closes this window and returns to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// Opens the create an account window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
		{
			CreateStaff createStaff = new CreateStaff();
			createStaff.Show();
		}

        private void Username_TextChanged()
        {

        }
    }
}