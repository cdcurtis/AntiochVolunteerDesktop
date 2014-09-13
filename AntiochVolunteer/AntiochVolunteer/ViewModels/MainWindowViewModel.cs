using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections;
using AntiochVolunteer.Models;

namespace AntiochVolunteer.ViewModels
{

    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Stack<ViewModelBase> _history;
        private ViewModelBase _currentViewModel;

        public MainWindowViewModel()
        {
            AppData = new ApplicationData();
            _history = new Stack<ViewModelBase>();

            base.DisplayName = "Loaded Main Window Correctly";

          
            OnCreateNewEvent = new RelayCommand(() => OpenCreateNewEventDlg());
            OnCreateNewVolunteer = new RelayCommand(() => OpenCreateNewVolunteerDlg());
            OnOpenVolunteersPage = new RelayCommand(() => OpenVolunteerView());
            OnCreateNewJob = new RelayCommand(() => OpenCreateNewJobDlg());
            OnCreateNewSchedule = new RelayCommand(() => OpenCreateNewScheduleDlg());


            CurrentViewModel = new WelcomeViewModel(this);
        }

        public ApplicationData AppData
        {
            get;
            protected set;
        }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                NotifyPropertyChanged("CurrentViewModel");
            }
        }


        #region ICommands
        public ICommand OnSave { get; private set; }
        private void SaveApplication()
        {
            //convert application to an encrypted CSV.
        }
        public ICommand OnOpenVolunteersPage { get; private set; }
        private void OpenVolunteerView()
        {
            CurrentViewModel = new VolunteersViewModel(this);
        }
        public ICommand OnCreateNewVolunteer { get; private set; }
        private void OpenCreateNewVolunteerDlg()
        {
            _history.Push(this);
            CurrentViewModel = new AddVolunteerDlgViewModel(this);
        }
        public ICommand OnOpenJobsPage { get; private set; }
        public ICommand OnCreateNewJob { get; private set; }
        private void OpenCreateNewJobDlg()
        {
            _history.Push(this);
            CurrentViewModel = new AddJobDlgViewModel(this);
        }
        public ICommand OnOpenEventPage { get; private set; }


        public ICommand OnCreateNewEvent { get; private set; }
        private void OpenCreateNewEventDlg()
        {
            _history.Push(this);
            CurrentViewModel = new AddEventDlgViewModel(this);
        }
        public ICommand OnOpenSchedulePage { get; private set; }
        public ICommand OnCreateNewSchedule { get; private set; }
        private void OpenCreateNewScheduleDlg()
        {
            _history.Push(this);
            CurrentViewModel = new AddScheduleDlgViewModel(this);
        }
        #endregion



    }
}
