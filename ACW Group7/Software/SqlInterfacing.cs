using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using UserClasses;
using BusinessLogic;

namespace Software
{
	class SqlInterfacing
	{
		/// <summary>
		/// Doms Notes
		/// </summary>
		///
		/// sqlite does not support datetime so has to be saved in a string which will be formatted by us eg
		/// TEXT as ISO8601 strings ("YYYY-MM-DD HH:MM:SS").
		///
		/// Specialities can be stored in one text field up to 500,000,000 characters
		/// so we can use csv (comma seperated values) to store and retrieve them
		/// same goes for medical conditions
		///
		/// Will - Does mean Specialities and Medical conditions can't have a , in their name, which is something we're
		/// going to need to consider when we decide what we call them!

		private static readonly string connectionString = @"Data Source=./DB.db;";


		SQLiteConnection connection = new SQLiteConnection(connectionString);



        /// <summary>
        /// Takes in an object of any user type and processes it according to what
        /// the type of object is
        /// </summary>
        /// <param name="userObject"></param>
		public void InsertUser(Object userObject)
		{
			Type type = userObject.GetType();
			string b = type.Name;


			switch (b)
			{
				case "PersonalTrainer":
					InsertPersonalTrainer(userObject);
					break;

				case "Student":
					InsertStudent(userObject);
					break;


				case "ExternalUser":
					InsertExternalUser(userObject);
					break;

				case "FacilitiesManagement":
					InsertFacilitiesManagement(userObject);
					break;
			}

			connection.Close();
		}


        /// <summary>
        /// Creates a facilities management user
        /// takes in an object and then processes the objects properties 
        /// to insert into the databse
        /// </summary>
        /// <param name="userObject"></param>
		private void InsertFacilitiesManagement(object userObject)
		{
			FacilitiesManagement facilitiesManagement;
			facilitiesManagement = userObject as FacilitiesManagement;
			try
			{
				SQLiteCommand insertExternalUser = new SQLiteCommand(
					"INSERT INTO Staff (FirstName, Surname, DOB, UserName, Password, UserType, StaffID, Email, JobTitle,UserLevel) " +
					"VALUES (@FirstName, @Surname, @DOB, @UserName, @Password, @UserType, @StaffID, @Email, @JobTitle, @UserLevel)",
					connection);
				connection.Open();
				insertExternalUser.Parameters.Add(new SQLiteParameter("@FirstName", facilitiesManagement._FirstName));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@Surname", facilitiesManagement._SurName));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@DOB", facilitiesManagement._DOB));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@UserName", facilitiesManagement._UniqueID));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@Password", facilitiesManagement._PasswordHash));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@UserType", facilitiesManagement._UserType));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@StaffID", facilitiesManagement._StaffID));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@Email", facilitiesManagement._WorkEmail));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@JobTitle", facilitiesManagement._JobTitle));
				insertExternalUser.Parameters.Add(new SQLiteParameter("@UserLevel", facilitiesManagement._UserLevel));
				insertExternalUser.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}


        /// <summary>
        /// Creates an external user and saves it to the database
        /// </summary>
        /// <param name="userObject"></param>
		private void InsertExternalUser(object userObject)
		{
			try
			{
				ExternalUser externalUser;
				externalUser = (ExternalUser) userObject as ExternalUser;
				SQLiteCommand insertExternal = new SQLiteCommand(
					"INSERT INTO Customers (FirstName, Surname, DOB, UserName, Password, UserType, Address, " +
					"Postcode, HomePhone, Mobile,MedicalConditions, EmergencyNumber,EmergencyName,Email,Motivation,CustomerID,Occupation  ) " +
					"VALUES (@FirstName, @Surname, @DOB, @UserName, @Password, @UserType, @Address, @Postcode, " +
					"@HomePhone, @Mobile,@MedicalConditions, @EmergencyNumber,@EmergencyName,@Email,@Motivation,@CustomerID,@Occupation)",
					connection);
				connection.Open();
				insertExternal.Parameters.Add(new SQLiteParameter("@FirstName", externalUser._FirstName));
				insertExternal.Parameters.Add(new SQLiteParameter("@Surname", externalUser._SurName));
				insertExternal.Parameters.Add(new SQLiteParameter("@DOB", externalUser._DOB));
				insertExternal.Parameters.Add(new SQLiteParameter("@UserName", externalUser._UniqueID));
				insertExternal.Parameters.Add(new SQLiteParameter("@Password", externalUser._PasswordHash));
				insertExternal.Parameters.Add(new SQLiteParameter("@UserType", externalUser._UserType));
				insertExternal.Parameters.Add(new SQLiteParameter("@Address", externalUser._Address));
				insertExternal.Parameters.Add(new SQLiteParameter("@Postcode", externalUser._PostCode));
				insertExternal.Parameters.Add(new SQLiteParameter("@HomePhone", externalUser._PhoneHome));
				insertExternal.Parameters.Add(new SQLiteParameter("@Mobile", externalUser._PhoneMobile));
				insertExternal.Parameters.Add(
					new SQLiteParameter("@MedicalConditions", externalUser._MedicalConditions));
				insertExternal.Parameters.Add(new SQLiteParameter("@EmergencyNumber",
					externalUser._EmergencyContactPhone));
				insertExternal.Parameters.Add(new SQLiteParameter("@EmergencyName",
					externalUser._EmergencyContactName));
				insertExternal.Parameters.Add(new SQLiteParameter("@Email", externalUser._Email));
				insertExternal.Parameters.Add(new SQLiteParameter("@Motivation", externalUser._Motivation));
				insertExternal.Parameters.Add(new SQLiteParameter("@CustomerID", externalUser._UniqueID));
				insertExternal.Parameters.Add(new SQLiteParameter("@Occupation", externalUser._Occupation));
				insertExternal.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// Creates a student account and saves it to the database
        /// </summary>
        /// <param name="userObject"></param>
		private void InsertStudent(object userObject)
		{
			try
			{
				Student student;
				student = (Student) userObject as Student;
				SQLiteCommand insertStudent = new SQLiteCommand(
					"INSERT INTO Customers (FirstName, Surname, DOB, UserName, Password, UserType, Address, Postcode, " +
					"HomePhone, Mobile,MedicalConditions, EmergencyNumber,EmergencyName,Email,Motivation,CustomerID," +
					"StudentID,Occupation  ) " +
					"VALUES (@FirstName, @Surname, @DOB, @UserName, @Password, @UserType, @Address, @Postcode, " +
					"@HomePhone, @Mobile,@MedicalConditions, @EmergencyNumber,@EmergencyName,@Email,@Motivation," +
					"@CustomerID,@StudentID,@Occupation)",
					connection);
				connection.Open();
				insertStudent.Parameters.Add(new SQLiteParameter("@FirstName", student._FirstName));
				insertStudent.Parameters.Add(new SQLiteParameter("@Surname", student._SurName));
				insertStudent.Parameters.Add(new SQLiteParameter("@DOB", student._DOB));
				insertStudent.Parameters.Add(new SQLiteParameter("@UserName", student._UserName));
				insertStudent.Parameters.Add(new SQLiteParameter("@Password", student._PasswordHash));
				insertStudent.Parameters.Add(new SQLiteParameter("@UserType", student._UserType));
				insertStudent.Parameters.Add(new SQLiteParameter("@Address", student._Address));
				insertStudent.Parameters.Add(new SQLiteParameter("@Postcode", student._PostCode));
				insertStudent.Parameters.Add(new SQLiteParameter("@HomePhone", student._PhoneHome));
				insertStudent.Parameters.Add(new SQLiteParameter("@Mobile", student._PhoneMobile));
				insertStudent.Parameters.Add(new SQLiteParameter("@MedicalConditions", student._MedicalConditions));
				insertStudent.Parameters.Add(new SQLiteParameter("@EmergencyNumber", student._EmergencyContactPhone));
				insertStudent.Parameters.Add(new SQLiteParameter("@EmergencyName", student._EmergencyContactName));
				insertStudent.Parameters.Add(new SQLiteParameter("@Email", student._Email));
				insertStudent.Parameters.Add(new SQLiteParameter("@Motivation", student._Motivation));
				insertStudent.Parameters.Add(new SQLiteParameter("@CustomerID", student._UniqueID));
				insertStudent.Parameters.Add(new SQLiteParameter("@StudentID", student._StudentID));
				insertStudent.Parameters.Add(new SQLiteParameter("@Occupation", "Student"));
				insertStudent.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// Creates a personal trainer account and saves it to the database
        /// </summary>
        /// <param name="userObject"></param>
		private void InsertPersonalTrainer(object userObject)
		{
			PersonalTrainer pt;
			pt = userObject as PersonalTrainer;
			try
			{
				string specialities = pt.GetSpecialitiesString();
				string availability = pt.GetAvailabilityString();
				SQLiteCommand insertPt = new SQLiteCommand(
					"INSERT INTO Staff (FirstName, Surname, DOB, UserName, Password, UserType, Address, " +
					"JobTitle, Email, UserLevel, Specialities,HourlyRate, UniqueID, Availability) " +
					"VALUES (@FirstName, @Surname, @DOB, @UserName, @Password, @UserType, @Address, @JobTitle, " +
					"@Email, @UserLevel, @Specialities, @HourlyRate, @UniqueID, @Availability)",
					connection);
				connection.Open();
				insertPt.Parameters.Add(new SQLiteParameter("@FirstName", pt._FirstName));
				insertPt.Parameters.Add(new SQLiteParameter("@Surname", pt._SurName));
				insertPt.Parameters.Add(new SQLiteParameter("@DOB", pt._DOB));
				insertPt.Parameters.Add(new SQLiteParameter("@UserName", pt._UserName));
				insertPt.Parameters.Add(new SQLiteParameter("@Password", pt._PasswordHash));
				insertPt.Parameters.Add(new SQLiteParameter("@UserType", pt._UserType));
				insertPt.Parameters.Add(new SQLiteParameter("@Address", "MISSING"));
				insertPt.Parameters.Add(new SQLiteParameter("@JobTitle", pt._JobTitle));
				insertPt.Parameters.Add(new SQLiteParameter("@Email", pt._WorkEmail));
				insertPt.Parameters.Add(new SQLiteParameter("@UserLevel", pt._UserLevel));
				insertPt.Parameters.Add(new SQLiteParameter("@Specialities", specialities));
				insertPt.Parameters.Add(new SQLiteParameter("@HourlyRate", pt._HourlyRate));
				insertPt.Parameters.Add(new SQLiteParameter("@UniqueID", pt._UniqueID));
				insertPt.Parameters.Add(new SQLiteParameter("@Availability", availability));
				insertPt.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}


        /// <summary>
        /// Updates an already existing personal trainer with the new edited details
        /// </summary>
        /// <param name="pt"></param>
		public void UpdatePersonalTrainer(PersonalTrainer pt)
		{
			try
			{	string specialities = pt.GetSpecialitiesString();
				string availability = pt.GetAvailabilityString();
				SQLiteCommand updatePT = new SQLiteCommand(
					"UPDATE Staff SET FirstName=@FirstName, Surname=@Surname, DOB=@DOB, UserName=@UserName, Password=@Password, UserType=@UserType, Address=@Address, " +
					"JobTitle=@JobTitle, Email=@Email, UserLevel=@UserLevel, Specialities=@Specialities,HourlyRate=@HourlyRate, Availability=@Availability WHERE UniqueID=@UniqueID ",
					connection);
				connection.Open();
				updatePT.Parameters.Add(new SQLiteParameter("@FirstName", pt._FirstName));
				updatePT.Parameters.Add(new SQLiteParameter("@Surname", pt._SurName));
				updatePT.Parameters.Add(new SQLiteParameter("@DOB", pt._DOB));
				updatePT.Parameters.Add(new SQLiteParameter("@UserName", pt._UserName));
				updatePT.Parameters.Add(new SQLiteParameter("@Password", pt._PasswordHash));
				updatePT.Parameters.Add(new SQLiteParameter("@UserType", pt._UserType));
				updatePT.Parameters.Add(new SQLiteParameter("@Address", "MISSING"));
				updatePT.Parameters.Add(new SQLiteParameter("@JobTitle", pt._JobTitle));
				updatePT.Parameters.Add(new SQLiteParameter("@Email", pt._WorkEmail));
				updatePT.Parameters.Add(new SQLiteParameter("@UserLevel", pt._UserLevel));
				updatePT.Parameters.Add(new SQLiteParameter("@Specialities", specialities));
				updatePT.Parameters.Add(new SQLiteParameter("@HourlyRate", pt._HourlyRate));
				updatePT.Parameters.Add(new SQLiteParameter("@UniqueID", pt._UniqueID));
				updatePT.Parameters.Add(new SQLiteParameter("@Availability", availability));
				updatePT.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// Inserts an appointment to the database
        /// </summary>
        /// <param name="appointments"></param>
		public void InsertAppointment(CreateAppointment appointments)
		{
			try
			{
				SQLiteCommand insertAppointment = new SQLiteCommand(
					"INSERT INTO Appointments(AppointmentID, StaffID, Paid, TimeStart, TimeEnd, UserID, Notes, Date) " +
					"VALUES(@AppointmentID, @StaffID, @Paid, @TimeStart, @TimeEnd, @UserID, @Notes, @Date)",
					connection);
				connection.Open();
				insertAppointment.Parameters.Add(new SQLiteParameter("@AppointmentID", appointments.AppointmentID));
				insertAppointment.Parameters.Add(new SQLiteParameter("@StaffID", appointments.StaffID));
				insertAppointment.Parameters.Add(new SQLiteParameter("@Paid", appointments.Paid));
				insertAppointment.Parameters.Add(new SQLiteParameter("@TimeStart", appointments.TimeStart));
				insertAppointment.Parameters.Add(new SQLiteParameter("@TimeEnd", appointments.TimeEnd));
				insertAppointment.Parameters.Add(new SQLiteParameter("@UserID", appointments.UserID));
				insertAppointment.Parameters.Add(new SQLiteParameter("@Notes", appointments.Notes));
                insertAppointment.Parameters.Add(new SQLiteParameter("@Date", appointments.Date));
                insertAppointment.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// Updates an existing customers details 
        /// </summary>
        /// <param name="customer"></param>
		public void UpdateCustomer(Customer customer)
		{
			try
			{
				SQLiteCommand updateUser = new SQLiteCommand(
					"UPDATE Customers " +
					"SET FirstName=@FirstName, Surname=@Surname, DOB=@DOB, UserName=@UserName, Password=@Password, " +
					"Address=@Address, Postcode=@Postcode, HomePhone=@HomePhone, Mobile=@Mobile," +
					"MedicalConditions=@MedicalConditions, EmergencyNumber=@EmergencyNumber, EmergencyName=@EmergencyName," +
					"Email=@Email, Motivation=@Motivation, StudentID=@StudentID, Occupation=@Occupation " +
					"WHERE CustomerID=@CustomerID", connection);

				updateUser.Parameters.Add(new SQLiteParameter("@FirstName", customer._FirstName));
				updateUser.Parameters.Add(new SQLiteParameter("@Surname", customer._SurName));
				updateUser.Parameters.Add(new SQLiteParameter("@DOB", customer._DOB));
				updateUser.Parameters.Add(new SQLiteParameter("@UserName", customer._UserName));
				updateUser.Parameters.Add(new SQLiteParameter("@Password", customer._PasswordHash));
				updateUser.Parameters.Add(new SQLiteParameter("@UserType", customer._UserType));
				updateUser.Parameters.Add(new SQLiteParameter("@Address", customer._Address));
				updateUser.Parameters.Add(new SQLiteParameter("@Postcode", customer._PostCode));
				updateUser.Parameters.Add(new SQLiteParameter("@HomePhone", customer._PhoneHome));
				updateUser.Parameters.Add(new SQLiteParameter("@Mobile", customer._PhoneMobile));
				updateUser.Parameters.Add(new SQLiteParameter("@MedicalConditions", customer._MedicalConditions));
				updateUser.Parameters.Add(new SQLiteParameter("@EmergencyNumber", customer._EmergencyContactPhone));
				updateUser.Parameters.Add(new SQLiteParameter("@EmergencyName", customer._EmergencyContactName));
				updateUser.Parameters.Add(new SQLiteParameter("@Email", customer._Email));
				updateUser.Parameters.Add(new SQLiteParameter("@Motivation", customer._Motivation));
				updateUser.Parameters.Add(new SQLiteParameter("@CustomerID", customer._UniqueID));
				updateUser.Parameters.Add(new SQLiteParameter("@StudentID", null));
				updateUser.Parameters.Add(new SQLiteParameter("@Occupation", "Student"));

				connection.Open();
				updateUser.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}


        /// <summary>
        /// Allows a user to change the details of an appointment
        /// </summary>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
		public void UpdateAppointment(CreateAppointment oldAppointment, CreateAppointment newAppointment)
		{
			try
			{
				connection.Open();
				SQLiteCommand updateAppointment = new SQLiteCommand(
					"UPDATE Appointments " +
					"SET StaffID=@StaffID, Paid=@Paid, TimeStart=@TimeStart, TimeEnd=@TimeEnd, UserID=@UserID, Notes=@Notes " +
					"WHERE AppointmentID=@AppointmentID",
					connection);

				updateAppointment.Parameters.Add(new SQLiteParameter("@StaffID", newAppointment.StaffID));
				updateAppointment.Parameters.Add(new SQLiteParameter("@Paid", newAppointment.Paid));
				updateAppointment.Parameters.Add(new SQLiteParameter("@TimeStart", newAppointment.TimeStart));
				updateAppointment.Parameters.Add(new SQLiteParameter("@TimeEnd", newAppointment.TimeEnd));
				updateAppointment.Parameters.Add(new SQLiteParameter("@UserID", newAppointment.UserID));
				updateAppointment.Parameters.Add(new SQLiteParameter("@Notes", newAppointment.Notes));
				updateAppointment.Parameters.Add(new SQLiteParameter("@AppointmentID", oldAppointment.AppointmentID));


//                SQLiteCommand cmd = new SQLiteCommand("Update Appointments set AppointmentID =" + newAppointment.AppointmentID + "," + "StaffID =" + newAppointment.StaffID + "," +
//                    "FacilityID =" + newAppointment.FacilityID + "," + "Paid =" + newAppointment.Paid + "," + "TimeStart =" + newAppointment.TimeStart + "," + "TimeEnd ="
//                    + newAppointment.TimeEnd + "," + "UserID =" + newAppointment.UserID + "," + "Notes =" + newAppointment.Notes + "," + "WHERE AppointmentID =" + oldAppointment.AppointmentID + ";", connection);
				updateAppointment.ExecuteNonQuery();
				connection.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}

        /// <summary>
        /// Retrieves a row of customer details based on their username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
		public SQLiteDataReader GetCustomer(string userName)
		{
			try
			{
				connection.Open();


				SQLiteCommand getUser =
					new SQLiteCommand("SELECT * FROM Customers WHERE UserName=@UserName", connection);
				getUser.Parameters.Add(new SQLiteParameter("@UserName", userName));
				SQLiteDataReader results = getUser.ExecuteReader();
				//	connection.Close();
				return results;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

        /// <summary>
        /// retrieves a row of employee details based on their username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
		public SQLiteDataReader GetStaffMemberReader(string userName)
		{
			try
			{
				connection.Open();

				SQLiteCommand getStaff = new SQLiteCommand("SELECT * FROM Staff WHERE UserName=@UserName", connection);
				getStaff.Parameters.Add(new SQLiteParameter("@UserName", userName));
				SQLiteDataReader results = getStaff.ExecuteReader();

				return results;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

		/// <summary>
		/// retrieves a row of employee details based on their username
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public PersonalTrainer GetStaffMember(string userName)
		{
			try
			{
				connection.Open();

				SQLiteCommand getStaff = new SQLiteCommand("SELECT * FROM Staff WHERE UserName=@UserName", connection);
				getStaff.Parameters.Add(new SQLiteParameter("@UserName", userName));
				SQLiteDataReader results = getStaff.ExecuteReader();
				PersonalTrainer pt = PersonalTrainer.PTFromDB(results);
                
                results.Close();
                connection.Close();

                return pt;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}


		private void CheckPassword(string userName, string hashedPassword)
		{
			connection.Open();
			SQLiteCommand checkPassword = new SQLiteCommand("SELECT * WHERE " + userName + "");
		}

        /// <summary>
        /// Creates and returns a list of each distinct personal trainers
        /// </summary>
        /// <returns></returns>
		public List<string> GetPersonalTrainers()
		{
			try
			{
				connection.Open();
				List<string> tempList = new List<string>();
				SQLiteCommand getPersonalTrainers =
					new SQLiteCommand("SELECT DISTINCT UserName FROM Staff", connection);

				SQLiteDataReader results = getPersonalTrainers.ExecuteReader();
				while (results.Read())
				{
					// Reader gets a keyed array, where the key is the column name we want
					tempList.Add(results["UserName"].ToString());
				}

                results.Close();
                connection.Close();
				return tempList;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

        /// <summary>
        /// Creates and returns a list of a PT's specialities based on 
        /// user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
		public List<string> GetPersonalTrainersSpecialities(string userId)
		{
			try
			{

				List<string> tempList = new List<string>();
				SQLiteCommand getPersonalTrainers =
					new SQLiteCommand("SELECT Specialities FROM Staff WHERE UserName = @UserName", connection);
				getPersonalTrainers.Parameters.Add(new SQLiteParameter("@UserName", userId));

				connection.Open();
				SQLiteDataReader results = getPersonalTrainers.ExecuteReader();

				while (results.Read())
				{
					// Reader gets a keyed array, where the key is the column name we want
					tempList.Add(results["Specialities"].ToString());
				}
				results.Close();
				connection.Close();

				return tempList;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

        public List<string> GetPersonalTrainersAvailabilities(string userId)
        {
            try
            {
                connection.Open();
                List<string> tempList = new List<string>();
                SQLiteCommand getPersonalTrainers =
                    new SQLiteCommand("SELECT Availability FROM Staff WHERE UserName = @UserName", connection);
                getPersonalTrainers.Parameters.Add(new SQLiteParameter("@UserName", userId));

                SQLiteDataReader results = getPersonalTrainers.ExecuteReader();

                while (results.Read())
                {
                    // Reader gets a keyed array, where the key is the column name we want
                    tempList.Add(results["Availability"].ToString());
                }
	            results.Close();
	            connection.Close();

                return tempList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }


		public List<Tuple<string,string>> GetCustomers()
		{
			try
			{
				List<Tuple<string,string>> customerList = new List<Tuple<string, string>>();
				SQLiteCommand getCustomers = new SQLiteCommand("SELECT CustomerID, UserName FROM Customers", connection);
				connection.Open();
				SQLiteDataReader results = getCustomers.ExecuteReader();
				while (results.Read())
				{
					customerList.Add(new Tuple<string, string>(results["CustomerID"].ToString(),
				   results["UserName"].ToString()));
				}
                connection.Close();
                return customerList;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

		public List<CreateAppointment> GetAppointmentDetails(string userID)
		{
			List<CreateAppointment> appointmentsList = new List<CreateAppointment>();
			SQLiteCommand getAppointments = new SQLiteCommand("Select * FROM Appointments where UserId=@UserId",connection);
			getAppointments.Parameters.Add(new SQLiteParameter("UserID", userID));
			connection.Open();
			SQLiteDataReader results = getAppointments.ExecuteReader();
			while(results.Read())
			{
				CreateAppointment app = new CreateAppointment(results["AppointmentID"].ToString(), results["StaffID"].ToString(), results["Paid"].ToString(), results["TimeStart"].ToString(), results["TimeEnd"].ToString(), results["UserID"].ToString(), results["Notes"].ToString(),results["Date"].ToString());
				appointmentsList.Add(app);
			}
			connection.Close();
			return appointmentsList;
		}

        public List<CreateAppointment> GetStaffAppointmentDetails(string userID)
        {
            List<CreateAppointment> appointmentsList = new List<CreateAppointment>();
            SQLiteCommand getAppointments = new SQLiteCommand("Select * FROM Appointments where StaffId=@UserId", connection);
            getAppointments.Parameters.Add(new SQLiteParameter("UserID", userID));
            connection.Open();
            SQLiteDataReader results = getAppointments.ExecuteReader();
            while (results.Read())
            {
                CreateAppointment app = new CreateAppointment(results["AppointmentID"].ToString(), results["StaffID"].ToString(), results["Paid"].ToString(), results["TimeStart"].ToString(), results["TimeEnd"].ToString(), results["UserID"].ToString(), results["Notes"].ToString(), results["Date"].ToString());
                appointmentsList.Add(app);
            }
            connection.Close();
            return appointmentsList;
        }

        public bool CheckIfSessionAvailable(CreateAppointment appointment)
        {
            SQLiteCommand getSession = new SQLiteCommand("SELECT * FROM Appointments WHERE StaffID=@StaffID AND TimeStart=@TimeStart AND TimeEnd=@TimeEnd AND Date=@Date", connection);
            getSession.Parameters.Add(new SQLiteParameter("TimeStart", appointment.TimeStart));
            getSession.Parameters.Add(new SQLiteParameter("TimeEnd", appointment.TimeEnd));
            getSession.Parameters.Add(new SQLiteParameter("Date", appointment.Date));
            getSession.Parameters.Add(new SQLiteParameter("StaffID", appointment.StaffID));
            connection.Open();
            SQLiteDataReader results = getSession.ExecuteReader();
            if (results.HasRows)
            {
                results.Close();
                connection.Close();
                return false;

            }
            results.Close();
            connection.Close();
            return true;
        }

        public bool CheckIfStaffSessionAvailable(CreateAppointment appointment)
        {
            SQLiteCommand getSession = new SQLiteCommand("SELECT * FROM Appointments WHERE UserID=@UserID AND TimeStart=@TimeStart AND TimeEnd=@TimeEnd AND Date=@Date", connection);
            getSession.Parameters.Add(new SQLiteParameter("TimeStart", appointment.TimeStart));
            getSession.Parameters.Add(new SQLiteParameter("TimeEnd", appointment.TimeEnd));
            getSession.Parameters.Add(new SQLiteParameter("Date", appointment.Date));
            getSession.Parameters.Add(new SQLiteParameter("UserID", appointment.UserID));
            connection.Open();
            SQLiteDataReader results = getSession.ExecuteReader();
            if (results.HasRows)
            {
                results.Close();
                connection.Close();
                return false;

            }
            results.Close();
            connection.Close();
            return true;
        }
    }
}