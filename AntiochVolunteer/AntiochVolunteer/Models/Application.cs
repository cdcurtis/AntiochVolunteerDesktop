using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiochVolunteer.ViewModels;
using System.Collections;

namespace AntiochVolunteer.Models
{
    public class ApplicationData
    {
        private List<Job> _jobsMasterList;
        private List<Event> _eventMasterList;
        private List<Schedule> _scheduleMasterList;
        private List<Volunteer> _volunteerMasterList;
        private IDGen _IDGenerator;

        public ApplicationData()
        {
            _jobsMasterList = new List<Job>();
            _eventMasterList = new List<Event>();
            _scheduleMasterList = new List<Schedule>();
            _volunteerMasterList = new List<Volunteer>();
            _IDGenerator = new IDGen();
        }
        public ApplicationData(string s)
        {
            //TODO:: s == file location to read from and fill all the info needed.
        }

        #region Public properties
        public List<Job> JobMasterList
        {
            get { return _jobsMasterList; }
        }
        public List<Event> EventMasterList
        {
            get { return _eventMasterList; }
        }
        public List<Schedule> ScheduleMasterList
        {
            get { return _scheduleMasterList; }
        }
        public List<Volunteer> VolunteerMasterList
        {
            get { return _volunteerMasterList; }
        }
        #endregion
    }
}
