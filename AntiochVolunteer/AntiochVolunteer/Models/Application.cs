using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiochVolunteer.ViewModels;
using System.Collections;
using System.Collections.ObjectModel;


namespace AntiochVolunteer.Models
{
    public class ApplicationData
    {
        private ObservableCollection<Job> _jobsMasterList;
        private ObservableCollection<Event> _eventMasterList;
        private ObservableCollection<Schedule> _scheduleMasterList;
        private ObservableCollection<Volunteer> _volunteerMasterList;
        private ObservableCollection<SkillSet> _skillSetMasterList;

        private IDGen _IDGenerator;

        public ApplicationData()
        {
            _jobsMasterList = new ObservableCollection<Job>();
            _eventMasterList = new ObservableCollection<Event>();
            _scheduleMasterList = new ObservableCollection<Schedule>();
            _volunteerMasterList = new ObservableCollection<Volunteer>();
            _skillSetMasterList = new ObservableCollection<SkillSet>();
            _skillSetMasterList.Add(new SkillSet("Testing"));
            _skillSetMasterList.Add(new SkillSet("Testing2"));
            _skillSetMasterList.Add(new SkillSet("Testing4"));
            _IDGenerator = new IDGen();
        }
        public ApplicationData(string s)
        {
            //TODO:: s == file location to read from and fill all the info needed.
        }

        #region Public properties
        public ObservableCollection<Job> JobMasterList
        {
            get { return _jobsMasterList; }
        }
        public ObservableCollection<Event> EventMasterList
        {
            get { return _eventMasterList; }
        }
        public ObservableCollection<Schedule> ScheduleMasterList
        {
            get { return _scheduleMasterList; }
        }
        public ObservableCollection<Volunteer> VolunteerMasterList
        {
            get { return _volunteerMasterList; }
        }
        public ObservableCollection<SkillSet> SkillSetMasterList
        {
            get { return _skillSetMasterList; }
        }
        public long GetNewID()
        {
            return _IDGenerator.NewID;
        }
        #endregion
    }
}
