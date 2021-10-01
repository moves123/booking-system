using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace UserClasses
{
	public class PersonalTrainer : FacilitiesManagement
	{
		public List<String> _Specialities { get; set; }
		public List<string> _Availability { get; set; }
		public decimal _HourlyRate { get; set; }

		public PersonalTrainer(string firstName, string surName, string dob, string password, string userType,
			string staffId, string jobTitle, string workEmail, int userLevel, List<string> specialities,
			List<string> availability, decimal hourlyRate, string userName) : base(firstName, surName, dob,
			password, userType, staffId, jobTitle, workEmail, userLevel, userName)
		{
			_Specialities = specialities;
			_Availability = availability;
			_HourlyRate = hourlyRate;
		}
		/// <summary>
		/// Creates a PersonalTrainer object from the DB info
		/// </summary>
		/// <param name="reader"></param>
		/// <returns>PersonalTrainer</returns>
		public static PersonalTrainer PTFromDB(SQLiteDataReader reader)
		{
			PersonalTrainer pt = null;
			try
			{
				if (reader.Read())
				{
					pt = new PersonalTrainer(
						reader["FirstName"].ToString(),
						reader["SurName"].ToString(),
						reader["DOB"].ToString(),
						"",
						reader["UserType"].ToString(),
						"",
						reader["JobTitle"].ToString(),
						reader["Email"].ToString(),
						Convert.ToInt16(reader["UserLevel"].ToString()),
						// Specialities
						Util.GetListFromString(reader["Specialities"].ToString()),
						// Availability
						Util.GetListFromString(reader["Availability"].ToString()),
						Convert.ToDecimal(reader["HourlyRate"].ToString()),
						reader["UserName"].ToString()
						){_PasswordHash = reader["Password"].ToString(), _UniqueID = reader["UniqueID"].ToString()};
				}

                reader.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

			return pt;
		}
		/// <summary>
		/// Returns Specialities as a string
		/// </summary>
		/// <returns>string</returns>
		public string GetSpecialitiesString()
		{
			return Util.GetStringFromList(_Specialities);
		}
		/// <summary>
		/// Returns Availability as a string
		/// </summary>
		/// <returns>string</returns>
		public string GetAvailabilityString()
		{
			return Util.GetStringFromList(_Availability);
		}
	}
}