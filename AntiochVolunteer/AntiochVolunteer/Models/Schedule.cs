using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
   
    public class Schedule
    {
        #region Private Members
        private List<Event> Events;
        private List<Volunteer> Volunteers;

        private bool _CanVolenteersWorkTwoOrMoreEventsInARow;
        private bool _isScheduleRequiredToFillAllSpots;
        #endregion

        public Schedule()
        {
            Events = new List<Event>();
            Volunteers = new List<Volunteer>();
        }

    }
}
