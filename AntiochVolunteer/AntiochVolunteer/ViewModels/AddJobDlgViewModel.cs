using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AntiochVolunteer.Models;

//TODO :: JobName must be unique!

namespace AntiochVolunteer.ViewModels
{
    public class AddJobDlgViewModel : ViewModelBase
    {
        private ViewModelBase _parent;
        private ObservableCollection<String> _selectedJobList;
        private ObservableCollection<String> _jobsList;
        private ObservableCollection<String> _selectedSkillSetList;
        private ObservableCollection<String> _skillSetList;
        private bool _isYesChecked;
        private bool _isNoChecked;
        private ApplicationData _app;
        private int _editedJobIndex;
        private string _jobName;
        private string _jobDescription;
        private string _minVolunteersNeeded;
        private string _recVolunteersNeeded;
        private string _otherSkill;


        public AddJobDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
            _selectedJobList = new ObservableCollection<string>();
            _jobsList = new ObservableCollection<string>();
            _skillSetList = new ObservableCollection<string>();
            _selectedSkillSetList = new ObservableCollection<string>();
            _app = (parent as MainWindowViewModel).AppData;

            _editedJobIndex = -1;
            AddCommands();
        }


        public AddJobDlgViewModel(ViewModelBase parent, int JobIndex)
        {
            _parent = parent;
            _selectedJobList = new ObservableCollection<string>();
            _jobsList = new ObservableCollection<string>();
            _skillSetList = new ObservableCollection<string>();
            _selectedSkillSetList = new ObservableCollection<string>();
            _app = (parent as MainWindowViewModel).AppData;

            Job j = _app.JobMasterList[JobIndex];
            JobName = j.Name;
            JobDescription = j.Description;
            MinVolenteersNeeded = j.MinimumVolenteersNeededToPreform.ToString();
            RecVolenteersNeeded = j.RecommendedVolenteersNeededToPreform.ToString();
            IsYesChecked = j.CanBePreformedByAnyone;
            IsNoChecked = j.CanBePreformedByAnyone;
            SelectedJobList = j.ComboJobs;
            SelectedSkillSetList = j.SkillsRequired;

            NotifyPropertyChanged("SelectedSkillSetList");
            NotifyPropertyChanged("SelectedJobList");
            _editedJobIndex = JobIndex;
            AddCommands();
        }
        private void AddCommands()
        {
            foreach (Job j in _app.JobMasterList)
                _jobsList.Add(j.Name);
            foreach (SkillSet s in _app.SkillSetMasterList)
                _skillSetList.Add(s.Skill);

            NotifyPropertyChanged("SkillSetList");
            NotifyPropertyChanged("JobsList");

            OnJobsLeftArrow = new RelayCommand(() => OnJobsLeftArrowCommand());
            OnJobsRightArrow = new RelayCommand(() => OnJobsRightArrowCommand());
            OnSkillsLeftArrow = new RelayCommand(() => OnSkillsLeftArrowCommand());
            OnSkillsRightArrow = new RelayCommand(() => OnSkillsRightArrowCommand());
            OnOK = new RelayCommand(() => OnOKCommand());
            OnCancel = new RelayCommand(() => OnCancelCommand());
            OnAddSkill = new RelayCommand(() => OnAddSkillCommand());
        }
        #region ICommands
        public ICommand OnJobsLeftArrow { get; set; }
        private void OnJobsLeftArrowCommand()
        {
            if (MasterJobIndex < 0 || MasterJobIndex >= _jobsList.Count())
                return;

            string newItem = _jobsList[MasterJobIndex];
            foreach (string s in _selectedJobList)
                if (s == newItem || newItem == JobName)
                    return;

            _selectedJobList.Add(_jobsList[MasterJobIndex]);

            NotifyPropertyChanged("SelectedJobList");
        }

        public ICommand OnJobsRightArrow { get; set; }
        private void OnJobsRightArrowCommand()
        {
            if (SelectedJobIndex < 0 || SelectedJobIndex >= _selectedJobList.Count())
                return;
            _selectedJobList.RemoveAt(SelectedJobIndex);
            NotifyPropertyChanged("SelectedJobList");
        }

        public ICommand OnSkillsLeftArrow { get; set; }
        private void OnSkillsLeftArrowCommand()
        {
            if (MasterSkillIndex < 0 || MasterSkillIndex >= _skillSetList.Count())
                return;

            string newItem = _skillSetList[MasterSkillIndex];
            foreach (string s in _selectedSkillSetList)
                if (s == newItem)
                    return;

            _selectedSkillSetList.Add(_skillSetList[MasterSkillIndex]);

            NotifyPropertyChanged("SelectedSkillSetList");
        }

        public ICommand OnSkillsRightArrow { get; set; }
        private void OnSkillsRightArrowCommand()
        {
            if (SelectedSkillIndex < 0 || SelectedSkillIndex >= _skillSetList.Count())
                return;
            _selectedSkillSetList.RemoveAt(SelectedSkillIndex);
            NotifyPropertyChanged("SelectedSkillSetList");

        }

        public ICommand OnOK { get; set; }
        private void OnOKCommand()
        {
            if (_editedJobIndex < 0)
            {
                foreach (Job jobs in _app.JobMasterList)
                    if (jobs.Name == JobName)
                    {
                        reportNameConflict();
                        return;
                    }

                foreach(Job jobs in _app.JobMasterList)
                {
                    foreach (String Name in SelectedJobList)
                    {
                        if (jobs.Name == Name)
                            jobs.ComboJobs.Add(JobName);
                    }
                }
                Job j = new Job(_app.GetNewID(), JobName, JobDescription, SelectedJobList, SelectedSkillSetList, IsYesChecked);
                j.MinimumVolenteersNeededToPreform = Convert.ToInt32(MinVolenteersNeeded);
                j.RecommendedVolenteersNeededToPreform = Convert.ToInt32(RecVolenteersNeeded);

                _app.JobMasterList.Add(j);
            }
            else
            {
                Job j = _app.JobMasterList[_editedJobIndex];
                j.Name = JobName;
                j.Description = JobDescription;
                j.ComboJobs = SelectedJobList;
                j.SkillsRequired = SelectedSkillSetList;
                j.CanBePreformedByAnyone = IsYesChecked;
                j.MinimumVolenteersNeededToPreform = Convert.ToInt32(MinVolenteersNeeded);
                j.RecommendedVolenteersNeededToPreform = Convert.ToInt32(RecVolenteersNeeded);

                RelinkJobConcurrency(j);
                _app.JobMasterList[_editedJobIndex] = j;
            }
            (_parent as MainWindowViewModel).CurrentViewModel = new JobsViewModel(_parent);
        }

        private void RelinkJobConcurrency(Job j)
        {
            foreach(Job mJob in _app.JobMasterList)
            {
                int index = mJob.ComboJobs.IndexOf(j.Name);
                int index2 = j.ComboJobs.IndexOf(mJob.Name);
                if ((index < 0 && index2 < 0) || (index >= 0 && index2 >= 0))
                    return;
                else if (index >= 0 && index2 < 0)
                    mJob.ComboJobs.RemoveAt(index);
                else if (index < 0 && index2 >= 0)
                {
                    mJob.ComboJobs.Add(j.Name);
                }
            }
        }

        private void reportNameConflict()
        {
            throw new NotImplementedException();
        }

        public ICommand OnCancel { get; set; }
        private void OnCancelCommand()
        { }

        public ICommand OnAddSkill { get; set; }
        private void OnAddSkillCommand()
        {
            SkillSet s = new SkillSet(OtherSkill);
            _skillSetList.Add(OtherSkill);

            OtherSkill = "";
            NotifyPropertyChanged("SkillSetList");

            (_parent as MainWindowViewModel).AppData.SkillSetMasterList.Add(s);
        }
        #endregion

        #region Public Properties
        public String JobName 
        {
            get { return _jobName; }
            set
            {
                _jobName = value;
                NotifyPropertyChanged("JobName");
            }
        }
        public String JobDescription
        {
            get { return _jobDescription; }
            set
            {
                _jobDescription = value;
                NotifyPropertyChanged("JobDescription");
            }
        }
        public String MinVolenteersNeeded
        {
            get { return _minVolunteersNeeded; }
            set
            {
                _minVolunteersNeeded = value;
                NotifyPropertyChanged("MinVolenteersNeeded");
            }
        }
        public String RecVolenteersNeeded
        {
            get { return _recVolunteersNeeded; }
            set
            {
                _recVolunteersNeeded = value;
                NotifyPropertyChanged("RecVolenteersNeeded");
            }
        }
        public String OtherSkill 
        {
            get { return _otherSkill; }
            set
            {
                _otherSkill = value;
                NotifyPropertyChanged("OtherSkill");
            }
        }
        public int SelectedJobIndex { get; set; }
        public int MasterJobIndex { get; set; }
        public int SelectedSkillIndex { get; set; }
        public int MasterSkillIndex { get; set; }

        public bool IsYesChecked 
        {
            get { return _isYesChecked; }
            set
            {
                _isYesChecked = value;
                if (value == true)
                    IsNoChecked = false;
                NotifyPropertyChanged("IsYesChecked");
            }
        }
        public bool IsNoChecked 
        {
            get { return _isNoChecked; }
            set
            {
                _isNoChecked = value;
                if (value == true)
                    IsYesChecked = false;
                NotifyPropertyChanged("IsNoChecked");

            }
        }

        public ObservableCollection<String> SelectedJobList
        {
            get { return _selectedJobList; }
            protected set
            {
                _selectedJobList = value;
                NotifyPropertyChanged("SelectedJobList");
            }
        }
        public ObservableCollection<String> JobsList
        {
            get { return _jobsList; } 
        }
        public ObservableCollection<String> SelectedSkillSetList
        {
            get { return _selectedSkillSetList; }
            protected set
            {
                _selectedSkillSetList = value;
                NotifyPropertyChanged("SelectedSkillSetList");
            }
        }
        public ObservableCollection<String> SkillSetList
        {
            get { return _skillSetList; }
        }
        #endregion

        
    }
}
