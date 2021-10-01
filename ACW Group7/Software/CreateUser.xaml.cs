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

namespace Software
{
	/// <summary>
	/// Interaction logic for CreateUser.xaml
	/// </summary>
	public partial class CreateUser : Window
	{
        /// <summary>
        ///  Private set up method to generate UI components
        /// </summary>
		private void Setup()
		{
			AccountCombobox.Items.Add("Student");
			AccountCombobox.Items.Add("External User");
			AccountCombobox.Items.Add("Volunteer");
			AccountCombobox.SelectedIndex = 0;
		}

		public CreateUser()
		{
			InitializeComponent();
			Setup();
		}

		SqlInterfacing sqlInterfacing = new SqlInterfacing();

        /// <summary>
        /// Create a user account based on the type of account 
        /// selected from the AccountCombobox and create a new
        /// object based on which type of account it is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (AccountCombobox.SelectedValue.ToString() == "Student")
				{
					UserClasses.Student anotherStudent = new UserClasses.Student(FirstNameTextbox.Text,
						LastNameTextbox.Text, DOBDatepicker.SelectedDate.ToString(), PasswordPasswordbox.Password,
						AccountCombobox.SelectedValue.ToString(), AddressTextbox.Text, PostcodeTextbox.Text,
						HomePhoneTextbox.Text, MobileTextbox.Text, "", EmergencyContactTextbox.Text,
						EmergencyTelTextbox.Text, EmailTextbox.Text, MotivationTextbox.Text, "", StudentIDTextbox.Text,
						UsernameTextbox.Text);


					UserClasses.Student student = new UserClasses.Student(FirstNameTextbox.Text, LastNameTextbox.Text,
						DOBDatepicker.SelectedDate.Value.ToString(), PasswordPasswordbox.Password,
						AccountCombobox.SelectedValue.ToString(),
						AddressTextbox.Text, PostcodeTextbox.Text, HomePhoneTextbox.Text, MobileTextbox.Text, "",
						EmergencyContactTextbox.Text, EmergencyTelTextbox.Text, EmailTextbox.Text,
						MotivationTextbox.Text, "", StudentIDTextbox.Text, UsernameTextbox.Text);
					try
					{
						sqlInterfacing.InsertUser(student);
						MessageBox.Show("User created");
						this.Close();
					}
					catch
					{
						MessageBox.Show("Unable to create user at this time");
					}
				}

				else if (AccountCombobox.SelectedValue.ToString() == "External User")
				{
				}

				else if (AccountCombobox.SelectedValue.ToString() == "Volunteer")
				{
				}
			}
			catch (Exception ex)

			{
				MessageBox.Show(ex.Message + ex.ToString());
			}
		}



        /// <summary>
        /// cancels the operation and closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}