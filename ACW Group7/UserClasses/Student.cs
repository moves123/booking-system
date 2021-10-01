using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClasses
{
	public class Student : Customer
	{
		#region Member Variables/ getset

		public string _StudentID { private set; get; }

		#endregion

		public Student(string firstName, string surName, string dob, string password, string userType, string address,
			string postCode, string phoneHome, string phoneMobile, string medicalConditions,
			string emergencyContactName, string emergencyContactPhone, string email, string motivation,
			string volunteerId, string studentId, string userName) : base(firstName, surName, dob, password, userType,
			address, postCode, phoneHome, phoneMobile, medicalConditions, emergencyContactName, emergencyContactPhone,
			email, motivation, volunteerId, userName)
		{
			_StudentID = studentId;
		}
	}
}