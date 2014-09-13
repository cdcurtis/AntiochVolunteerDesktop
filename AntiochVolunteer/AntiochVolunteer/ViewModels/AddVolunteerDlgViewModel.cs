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
    public class AddVolunteerDlgViewModel : ViewModelBase
    {
        #region Private Fields
        private ViewModelBase _parent;
        private int _editedIndex = -1;
        private ObservableCollection<string> _skillSet;
        private string _errorMessage;
        private string _firstNameBrush;
        private string _lastNameBrush;
        private string _emailBrush;
        private string _phoneBrush;
        private  string _otherSkill;
        #endregion

        #region Constructors
        public AddVolunteerDlgViewModel(ViewModelBase parent)
        {
            ErrorMessage = "";
            UserEmail = "";
            UserFirstName = "";
            UserLastName = "";
            UserPhone = "";
            _parent = parent;

            SetCommandsAndSkills();
        }

        public AddVolunteerDlgViewModel(ViewModelBase parent, int volunteeIndex)
        {
            _editedIndex = volunteeIndex;
            _parent = parent;
            Volunteer v = (parent as MainWindowViewModel).AppData.VolunteerMasterList[volunteeIndex];
            UserEmail = v.Email;
            UserFirstName = v.FirstName;
            UserLastName = v.LastName;
            UserPhone = v.Phone;
            SetCommandsAndSkills();
        }

        private void SetCommandsAndSkills()
        {
            _skillSet = new ObservableCollection<string>();
            foreach (SkillSet s in (_parent as MainWindowViewModel).AppData.SkillSetMasterList)
                _skillSet.Add(s.Skill);
            NotifyPropertyChanged("SkillSetList");


            OnOK = new RelayCommand(() => OnOKCommand());
            OnAddSkill = new RelayCommand(() => OnAddSkillCommand());
        }

        #endregion

        #region ICommands
        public ICommand OnOK { get; set; }
        private void OnOKCommand()
        {//TODO::View validation edits on Volunteer error.
            try
            {
                
                Volunteer v = new Volunteer(UserFirstName, UserLastName, UserEmail, UserPhone, null);
                (_parent as MainWindowViewModel).AppData.VolunteerMasterList.Add(v);
                ErrorMessage = "";
                (_parent as MainWindowViewModel).CurrentViewModel = new VolunteersViewModel(_parent);
            }
            catch (VolunteerErrorCode e)
            {
                if (e.InvalidFirstName)
                {
                    FirstNameBrush = "Red";
                    ErrorMessage += "First Name must not be Empty.\n";
                }
                if (e.InvalidLastName)
                {
                    LastNameBrush = "Red";
                    ErrorMessage += "Last Name must not be Empty.\n";

                }
                if (e.InvalidPhone)
                {
                    PhoneBrush = "Red";
                    ErrorMessage += "Must be a valid number.\n";

                }
                if (e.InvalidEmail)
                {
                    EmailBrush = "Red";
                    ErrorMessage += "Must be a valid Email.\n";
                }
            }

        }

        public ICommand OnAddSkill { get; set; }
        private void OnAddSkillCommand()
        {
            SkillSet s = new SkillSet(_otherSkill);
            _skillSet.Add (_otherSkill);

            _otherSkill = "";
            NotifyPropertyChanged("OtherSkill");
            NotifyPropertyChanged("SkillSetList");

            (_parent as MainWindowViewModel).AppData.SkillSetMasterList.Add(s);
        }

        #endregion

        #region Public Properties
        public string ErrorMessage 
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }
        public string UserFirstName { get; set; }
        public string FirstNameBrush 
        {
            get
            {
                return _firstNameBrush;
            }
            set
            {
                _firstNameBrush = value;
                NotifyPropertyChanged("FirstNameBrush");
            }
        }
        public string UserLastName { get; set; }
        public string LastNameBrush 
        {
            get
            {
                return _lastNameBrush;
            }
            set
            {
                _lastNameBrush = value;
                NotifyPropertyChanged("LastNameBrush");
            }
        }
        public string UserEmail { get; set; }
        public string EmailBrush 
        {
            get
            {
                return _emailBrush;
            }
            set
            {
                _emailBrush = value;
                NotifyPropertyChanged("EmailBrush");
            }
        }
        public string UserPhone { get; set; }
        public string PhoneBrush 
        {
            get
            {
                return _phoneBrush;
            }
            set
            {
                _phoneBrush = value;
                NotifyPropertyChanged("PhoneBrush");
            }
        }
        public ObservableCollection<string> SkillSetList
        {
            get
            {
                return _skillSet;
            }
        }
        public string OtherSkill
        {
            get
            {
                return _otherSkill;
            }
            set
            {
                _otherSkill = value;
            }
        }
        #endregion
    }
}
