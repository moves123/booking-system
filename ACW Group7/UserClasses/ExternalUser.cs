using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClasses
{
	public class ExternalUser : Customer
	{
		#region Member Variables/ getset

		public string _Occupation { get; set; }

		#endregion

		public ExternalUser(string firstName, string surName, string dob, string password, string userType,
			string address, string postCode, string phoneHome, string phoneMobile, string medicalConditions,
			string emergencyContactName, string emergencyContactPhone, string email, string motivation,
			string volunteerId, string occupation, string userName) : base(firstName, surName, dob, password, userType,
			address, postCode, phoneHome, phoneMobile, medicalConditions, emergencyContactName, emergencyContactPhone,
			email, motivation, volunteerId, userName)
		{
			_Occupation = occupation;
		}
	}
}