using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AntiochVolunteer.Models;

namespace AntiochVolunteer.ViewModels
{
    public class JobsViewModel: ViewModelBase
    {
        private ViewModelBase _parent;
        private ApplicationData _app;
        private int _selectedIndex;
        private string _jobName;
        private string _jobDescription;
        private string _minVolunteersNeeded;
        private string _recVolunteersNeeded;
        private string _isGenericJob;
        private ObservableCollection<string> _selectedJobList;
        private ObservableCollection<string> _selectedSkillSetList;
        public JobsViewModel(ViewModelBase parent)
        {
            _parent = parent;
            _app = (parent as MainWindowViewModel).AppData;
            JobList = _app.JobMasterList;
            NotifyPropertyChanged("JobList");
        }

        private void PopulateJobData()
        {
            if (_selectedIndex < 0 || _selectedIndex >= JobList.Count)
                return;
            Job j = JobList[_selectedIndex];
            JobName = j.Name;
            JobDescription = j.Description;

        }

        #region ICommands
        public ICommand OnEdit { get; set; }
        private void OnEditCommand()
        {
            if (_selectedIndex < 0 || _selectedIndex >= JobList.Count)
                return;
            (_parent as MainWindowViewModel).CurrentViewModel = new AddJobDlgViewModel(_parent, _selectedIndex);
        }
        public ICommand OnDelete { get; set; }
        private void OnDeleteCommand()
        {
            int indexToBeRemoved = _selectedIndex;
            if (indexToBeRemoved < 0 || indexToBeRemoved >= JobList.Count)
                return;
            JobList.RemoveAt(indexToBeRemoved);

            NotifyPropertyChanged("JobList");
            
          
        }
        #endregion
        #region Public Properties
        public ObservableCollection<Job> JobList { get; protected set; }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set 
            {
                _selectedIndex = value;
                PopulateJobData();
            }
        }

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
        public String IsGenericJob 
        {
            get { return _isGenericJob; }
            set 
            {
                _isGenericJob = value;
                NotifyPropertyChanged("IsGenericJob");
            }
        }
        public ObservableCollection<String> SelectedJobList
        {
            get { return _selectedJobList; }
        }
        public ObservableCollection<String> SelectedSkillSetList
        {
            get { return _selectedSkillSetList; }
        }
        #endregion
    }
}
