using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserClasses
{
	public class Customer : User
	{
		#region Member variables/ getset

		public string _Address { get; set; }
		public string _PostCode { get; set; }
		public string _PhoneHome { get; set; }
		public string _PhoneMobile { get; set; }
		public string _MedicalConditions { get; set; }
		public string _EmergencyContactName { get; set; }
		public string _EmergencyContactPhone { get; set; }
		public string _Email { get; set; }
		public string _Motivation { get; set; }
		public string _VolunteerID { get; set; }

		#endregion

		public Customer(string firstName, string surName, string dob, string password, string userType, string address,
			string postCode, string phoneHome, string phoneMobile, string medicalConditions,
			string emergencyContactName, string emergencyContactPhone, string email, string motivation,
			string volunteerId, string userName) : base(firstName, surName, dob, password, userType, userName)
		{
			_Address = address;
			_PostCode = postCode;
			_PhoneHome = phoneHome;
			_PhoneMobile = phoneMobile;
			_MedicalConditions = medicalConditions;
			_EmergencyContactName = emergencyContactName;
			_EmergencyContactPhone = emergencyContactPhone;
			_Email = email;
			_Motivation = motivation;
			_VolunteerID = volunteerId;
		}
		/// <summary>
		/// Creates a Customer object from the database info
		/// </summary>
		/// <param name="reader"></param>
		/// <returns>Customer</returns>
		public static Customer CustomerFromDB(SQLiteDataReader reader)
		{
			Customer cust = null;
			try
			{
				if(reader.Read())
				{
					cust = new Customer(
						reader["FirstName"].ToString(),
						reader["SurName"].ToString(),
						reader["DOB"].ToString(),
						// This is the password field, yes this is silly, I know it is. But it works, so sue me
						// If we set it to a null value stuff breaks, really we should overload the constructor
						"",
						reader["UserType"].ToString(),
						reader["Address"].ToString(),
						reader["Postcode"].ToString(),
						reader["HomePhone"].ToString(),
						reader["Mobile"].ToString(),
						reader["MedicalConditions"].ToString(),
						reader["EmergencyName"].ToString(),
						reader["EmergencyNumber"].ToString(),
						reader["Email"].ToString(),
						reader["Motivation"].ToString(),
						null, //Not Implemented yet
						reader["UserName"].ToString()
					) {_PasswordHash = reader["Password"].ToString(), _UniqueID = reader["CustomerID"].ToString()};
				}
                reader.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
			}

			return cust;
		}
	}
}