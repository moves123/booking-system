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
	/// Interaction logic for CreateStaff.xaml
	/// </summary>
	public partial class CreateStaff : Window
	{
		private List<string> specialitiesList = new List<string>();
		SqlInterfacing sqlInterfacing = new SqlInterfacing();


        /// <summary>
        /// Private set up method to generate UI components
        /// </summary>
		private void Setup()
		{   AccountCombobox.Items.Add("Admin");
			AccountCombobox.Items.Add("Personal Trainer");			
			AccountCombobox.SelectedIndex = 0;
            AvailableTimesListBox.Visibility = Visibility.Hidden;
            OpenTimesListBox.Visibility = Visibility.Hidden;
            InsertTimeSlotButton.Visibility = Visibility.Hidden;
            RemoveTimeSlotButton.Visibility = Visibility.Hidden;

            SpecialityTextBlock.Visibility = Visibility.Hidden;
            SpecialtiesTextbox.Visibility = Visibility.Hidden;
            RemoveSpecialityButton.Visibility = Visibility.Hidden;
            AddSpecialityButton.Visibility = Visibility.Hidden;
            SpecialityListbox.Visibility = Visibility.Hidden;
            SpecialitiesTitleTextblock.Visibility = Visibility.Hidden;

            OpenTimesListBox.Items.Add("09:00 - 09:30");
            OpenTimesListBox.Items.Add("09:30 - 10:00");
            OpenTimesListBox.Items.Add("10:00 - 10:30");
            OpenTimesListBox.Items.Add("10:30 - 11:00");
            OpenTimesListBox.Items.Add("11:00 - 11:30");
            OpenTimesListBox.Items.Add("11:30 - 12:00");                  
            OpenTimesListBox.Items.Add("12:00 - 12:30");
            OpenTimesListBox.Items.Add("13:00 - 13:30");
            OpenTimesListBox.Items.Add("13:30 - 14:00");
            OpenTimesListBox.Items.Add("14:00 - 14:30");
            OpenTimesListBox.Items.Add("14:30 - 15:00");
            OpenTimesListBox.Items.Add("15:00 - 15:30");
            OpenTimesListBox.Items.Add("15:30 - 16:00");
            OpenTimesListBox.Items.Add("16:00 - 16:30");
            OpenTimesListBox.Items.Add("16:30 - 17:00");
		}


		public CreateStaff()
		{
			InitializeComponent();
			Setup();
		}

        /// <summary>
        /// Adds specialities to the listbox view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void AddSpecialityButton_Click(object sender, RoutedEventArgs e)
		{
			specialitiesList.Add(SpecialtiesTextbox.Text);
			SpecialityListbox.Items.Add(SpecialtiesTextbox.Text);
		}

		private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
		{
            List<string> availabilityList = new List<string>();
            foreach(string x in AvailableTimesListBox.Items)
            {
                availabilityList.Add(x);
            }

			if (AccountCombobox.SelectedValue.ToString() == "Personal Trainer")
			{

				UserClasses.PersonalTrainer personalTrainer = new UserClasses.PersonalTrainer(FirstNameTextbox.Text,
					LastNameTextbox.Text, DOBDatepicker.SelectedDate.Value.ToString(), PasswordPasswordbox.Password,
					AccountCombobox.SelectedValue.ToString(), "A staff iD",
					JobTitleTextbox.Text, EmailTextbox.Text, 1, specialitiesList, availabilityList,
					decimal.Parse(HourlyRateTextbox.Text), UsernameTextbox.Text);
				try
				{
					sqlInterfacing.InsertUser(personalTrainer);
					MessageBox.Show("User created");
					this.Close();
				}
				catch
				{
					MessageBox.Show("Unable to create user at this time");
				}
			}
		}

        /// <summary>
        /// Cancels and closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// Remove a speciality from the listbox view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void RemoveSpecialityButton_Click(object sender, RoutedEventArgs e)
		{
			SpecialityListbox.Items.Remove(SpecialityListbox.SelectedItem);
			specialitiesList.Remove((string) SpecialityListbox.SelectedItem);
		}

        private void InsertTimeSlotButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = OpenTimesListBox.SelectedIndex;
            AvailableTimesListBox.Items.Add(OpenTimesListBox.Items[selectedIndex]);
            OpenTimesListBox.Items.Remove(OpenTimesListBox.Items[selectedIndex]);
        }

        private void RemoveTimeSlotButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = AvailableTimesListBox.SelectedIndex;
            OpenTimesListBox.Items.Add(AvailableTimesListBox.Items[selectedIndex]);
            AvailableTimesListBox.Items.Remove(AvailableTimesListBox.Items[selectedIndex]);
        }

        private void AccountCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AccountCombobox.SelectedValue.ToString() == "Personal Trainer")
            {
                AvailableTimesListBox.Visibility = Visibility.Visible;
                OpenTimesListBox.Visibility = Visibility.Visible;
                InsertTimeSlotButton.Visibility = Visibility.Visible;
                RemoveTimeSlotButton.Visibility = Visibility.Visible;
                SpecialityTextBlock.Visibility = Visibility.Visible;
                SpecialtiesTextbox.Visibility = Visibility.Visible;
                RemoveSpecialityButton.Visibility = Visibility.Visible;
                AddSpecialityButton.Visibility = Visibility.Visible;
                SpecialityListbox.Visibility = Visibility.Visible;
                SpecialitiesTitleTextblock.Visibility = Visibility.Visible;
            }
        }
    }
}