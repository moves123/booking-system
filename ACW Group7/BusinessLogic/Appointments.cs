using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Appointments
    {
        #region Member Variable
        private DateTime m_dateTime;
        private readonly TimeSpan m_halfHourApp = new TimeSpan(00, 30, 0);
        private readonly TimeSpan m_HourApp = new TimeSpan(01, 00, 0);
        private readonly TimeSpan m_startTimeSpan = new TimeSpan(09, 00, 0);
        private readonly TimeSpan m_endTimeSpan = new TimeSpan(17, 00, 0);
        private DateTime m_startTimeOfDay;
        private DateTime m_endTimeOfDay;
        #endregion

        #region Constructor
        private Appointments(DateTime pDateTime)//also need to take in who booked and the facility booked and the PT if one was booked
        {

            m_dateTime = pDateTime.Date;
            m_startTimeOfDay = m_startTimeOfDay.Date + m_startTimeSpan;
            m_endTimeOfDay = m_endTimeOfDay.Date + m_endTimeSpan;
            //interval will be set here depending on the time chosen on the form eg 1 hour
        }
        #endregion

        // #region New Class Added Here read inside
        // list will have customer, PT, facility, time, fee
        // this will be a list with all appointment time slots in a given day that will be marked available or not
        // there will be one list for each facility or PT that can be booked that day
        // #endregion

        //To create the bookings availble output:
        //get list of all bookings for the day..
        //then create a loop (16 elements if 9 to 5) of time starting at 09:00 and then loop 2 is 9.30, 
        //then 10..etc inside the loop for each element check if there is a booking 
        //if yes populate the availability class as booked..all else are available slots..

    }
}
