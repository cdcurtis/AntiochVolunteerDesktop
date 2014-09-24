using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AntiochVolunteer.Models;
using System.Windows.Input;

namespace AntiochVolunteer.ViewModels
{
    public class VolunteersViewModel :ViewModelBase
    {
        private ViewModelBase _parent;
        private int _volunteerSelectedIndex;

        public VolunteersViewModel(ViewModelBase parent)
        {
           _parent = parent;
           VolunteerList = (parent as MainWindowViewModel).AppData.VolunteerMasterList;
           if (VolunteerList.Count > 0)
           {
               _volunteerSelectedIndex = 0;
               PopulateUserData();
           }

            OnEdit = new RelayCommand(() => OnEditCommand());
            OnDelete = new RelayCommand(() => OnDeleteCommand());

        }


        private void PopulateUserData()
        {
            if (_volunteerSelectedIndex < 0 || _volunteerSelectedIndex >= VolunteerList.Count)
                return;

            UserFirstName = VolunteerList[_volunteerSelectedIndex].FirstName;
            UserLastName = VolunteerList[_volunteerSelectedIndex].LastName;
            UserPhone = VolunteerList[_volunteerSelectedIndex].Phone;
            UserEmail = VolunteerList[_volunteerSelectedIndex].Email;
            UserSkills = VolunteerList[_volunteerSelectedIndex].Skills;

            NotifyPropertyChanged("UserFirstName");
            NotifyPropertyChanged("UserLastName");
            NotifyPropertyChanged("UserPhone");
            NotifyPropertyChanged("UserEmail");
            NotifyPropertyChanged("UserSkills");
        }
        private void ClearUserData()
        {

            UserFirstName = "";
            UserLastName = "";
            UserPhone = "";
            UserEmail = "";
            UserSkills = new ObservableCollection<string>();

            NotifyPropertyChanged("UserFirstName");
            NotifyPropertyChanged("UserLastName");
            NotifyPropertyChanged("UserPhone");
            NotifyPropertyChanged("UserEmail");
            NotifyPropertyChanged("UserSkills");
        }

        #region ICommands
        public ICommand OnEdit { get; set; }
        public ICommand OnDelete { get; set; }

        private void OnEditCommand()
        {
            if (_volunteerSelectedIndex < 0 || _volunteerSelectedIndex >= VolunteerList.Count)
                return;
            (_parent as MainWindowViewModel).CurrentViewModel = new AddVolunteerDlgViewModel(_parent, _volunteerSelectedIndex);
        }

        private void OnDeleteCommand()
        {
            int indexToBeRemoved = _volunteerSelectedIndex;
            if (indexToBeRemoved < 0 || indexToBeRemoved >= VolunteerList.Count)
                return;
            VolunteerList.RemoveAt(indexToBeRemoved);
           
            NotifyPropertyChanged("VolunteerList");
            ClearUserData();
        }
        #endregion
        #region Public Properties
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int VolunteerSelectedIndex
        {
            get { return _volunteerSelectedIndex; }
            set
            {
                _volunteerSelectedIndex = value;
                PopulateUserData();
            }
        }
        public ObservableCollection<Volunteer> VolunteerList
        {
            get;
            private set;
        }
        public ObservableCollection<string> UserSkills
        {
            get;
            set;
        }
        #endregion
    }
}
