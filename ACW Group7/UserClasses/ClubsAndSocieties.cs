using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace UserClasses
{
    class ClubsAndSocieties
    {
        public string _UniqueID { get; private set; }
        public string _ClubName { get; set; }
        public string _AdminUserID { get; set; }
        public List<User> _ListOfMembers { get; set; }
        public List<Appointments> _Appointments { get; set; }

        public ClubsAndSocieties(string clubName, string adminUserId, List<User> listOfMembers, List<Appointments> appointments)
        {
            _UniqueID = Util.generateGuid().ToString();
            _ClubName = clubName;
            _AdminUserID = adminUserId;
            _ListOfMembers = listOfMembers;
            _Appointments = appointments;
        }
    }
}
