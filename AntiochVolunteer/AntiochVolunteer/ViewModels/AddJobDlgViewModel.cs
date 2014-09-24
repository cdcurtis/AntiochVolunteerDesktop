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


        public AddJobDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
            _selectedJobList = new ObservableCollection<string>();
            _jobsList = new ObservableCollection<string>();
            _skillSetList = new ObservableCollection<string>();
            _selectedSkillSetList = new ObservableCollection<string>();
            _app = (parent as MainWindowViewModel).AppData;

            foreach (Job j in _app.JobMasterList)
                _jobsList.Add(j.Name);
            foreach (SkillSet s in _app.SkillSetMasterList)
                _skillSetList.Add(s.Skill);

            NotifyPropertyChanged("SkillSetList");
            NotifyPropertyChanged("JobsList");
            AddCommands();
        }


        public AddJobDlgViewModel(ViewModelBase parent, int JobIndex)
        {
            _parent = parent;
            _selectedJobList = new ObservableCollection<string>();
            _jobsList = new ObservableCollection<string>();
            _skillSetList = new ObservableCollection<string>();
            _selectedSkillSetList = new ObservableCollection<string>();
        }
        private void AddCommands()
        {
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
            _selectedSkillSetList.Add(_skillSetList[MasterSkillIndex]);

            NotifyPropertyChanged("SelectedSkillSetList");
        }

        public ICommand OnSkillsRightArrow { get; set; }
        private void OnSkillsRightArrowCommand()
        {
            if (SelectedSkillIndex < 0 || SelectedSkillIndex >= _selectedJobList.Count())
                return;
            _selectedSkillSetList.RemoveAt(SelectedSkillIndex);
            NotifyPropertyChanged("SelectedSkillSetList");

        }

        public ICommand OnOK { get; set; }
        private void OnOKCommand()
        {
            Job j = new Job(_app.GetNewID(), JobName, JobDescription, SelectedJobList, SelectedSkillSetList, IsYesChecked);
            j.MinimumVolenteersNeededToPreform = Convert.ToInt32(MinVolenteersNeeded);
            j.RecommendedVolenteersNeededToPreform = Convert.ToInt32(RecVolenteersNeeded);

            _app.JobMasterList.Add(j);
            (_parent as MainWindowViewModel).CurrentViewModel = new JobsViewModel(_parent);
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
            NotifyPropertyChanged("OtherSkill");
            NotifyPropertyChanged("SkillSetList");

            (_parent as MainWindowViewModel).AppData.SkillSetMasterList.Add(s);
        }
        #endregion

        #region Public Properties
        public String JobName { get; set; }
        public String JobDescription { get; set; }
        public String MinVolenteersNeeded { get; set; }
        public String RecVolenteersNeeded { get; set; }
        public String OtherSkill { get; set; }
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
        }
        public ObservableCollection<String> JobsList
        {
            get { return _jobsList; } 
        }
        public ObservableCollection<String> SelectedSkillSetList
        {
            get { return _selectedSkillSetList; }
        }
        public ObservableCollection<String> SkillSetList
        {
            get { return _skillSetList; }
        }
        #endregion

        
    }
}
