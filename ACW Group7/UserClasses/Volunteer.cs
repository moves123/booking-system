using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace UserClasses
{
    public class Volunteer
    {
        public string _UniqueID { get; private set; }
        public string _CustomerID { get; private set; }
        public Appointments _Availability { get; set; }
        public Appointments _Appointments { get; set; }

        public List<String> _Specialities { get; set; }

        public Volunteer(string customerId, Appointments availability, Appointments appointments, List<string> specialities)
        {
            _UniqueID = Util.generateGuid().ToString();
            _CustomerID = customerId;
            _Availability = availability;
            _Appointments = appointments;
            _Specialities = specialities;
        }
    }
}
