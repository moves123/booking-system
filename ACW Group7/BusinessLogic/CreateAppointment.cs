using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CreateAppointment
    {

        public string AppointmentID { get; set; }
        public string StaffID { get; set; }
        public string Paid { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string UserID { get; set; }
        public string Notes { get; set; }

        public string Date { get; set; }

        public CreateAppointment(string _AppointmentID, string _StaffID, string _Paid, string _TimeStart, string _TimeEnd, string _UserID, string _Notes, string _Date)
        {
            AppointmentID = _AppointmentID;
            StaffID = _StaffID;
            Paid = _Paid;
            TimeStart = _TimeStart;
            TimeEnd = _TimeEnd;
            UserID = _UserID;
            Notes = _Notes;
            Date = _Date;

        }

    }
}
