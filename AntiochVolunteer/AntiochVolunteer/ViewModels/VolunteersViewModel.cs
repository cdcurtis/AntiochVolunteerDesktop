using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AntiochVolunteer.Models;

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
        }


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

        private void PopulateUserData()
        {
            UserFirstName = VolunteerList[_volunteerSelectedIndex].FirstName;
            UserLastName = VolunteerList[_volunteerSelectedIndex].LastName;
            UserPhone = VolunteerList[_volunteerSelectedIndex].Phone;
            UserEmail = VolunteerList[_volunteerSelectedIndex].Email;

            NotifyPropertyChanged("UserFirstName");
            NotifyPropertyChanged("UserLastName");
            NotifyPropertyChanged("UserPhone");
            NotifyPropertyChanged("UserEmail");
        }
        public ObservableCollection<Volunteer> VolunteerList
        {
            get;
            private set;
        }
    }
}
