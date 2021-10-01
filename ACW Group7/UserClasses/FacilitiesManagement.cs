using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClasses
{
	public class FacilitiesManagement : User
	{
		public string _StaffID { get; private set; }
		public string _JobTitle { get; set; }
		public string _WorkEmail { get; set; }
		public int _UserLevel { get; set; }

		public FacilitiesManagement(string firstName, string surName, string dob, string password, string userType,
			string staffId, string jobTitle, string workEmail, int userLevel, string userName) : base(firstName,
			surName, dob, password, userType, userName)
		{
			_StaffID = staffId;
			_JobTitle = jobTitle;
			_WorkEmail = workEmail;
			_UserLevel = userLevel;
		}
	}
}