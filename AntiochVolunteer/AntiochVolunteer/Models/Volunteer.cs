using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AntiochVolunteer.Models
{
    //TODO:: add regex validation.
    public class VolunteerErrorCode : SystemException
    {
        private bool _invalidFirstName;
        private bool _invalidLastName;
        private bool _invalidEmail;
        private bool _invalidPhone;

        public VolunteerErrorCode() { }

        public bool InvalidFirstName { get { return _invalidFirstName; } set { _invalidFirstName = value; HasError = true; } }
        public bool InvalidLastName { get { return _invalidLastName; } set { _invalidLastName = value; HasError = true; } }
        public bool InvalidEmail { get { return _invalidEmail; } set { _invalidEmail= value; HasError = true; } }
        public bool InvalidPhone { get { return _invalidPhone; } set { _invalidPhone = value; HasError = true; } }
        public bool HasError { get; private set; }
    }
    public class Volunteer
    {
        public Volunteer() 
        {
            Skills = new ObservableCollection<string>();
            DatesRequestedOff = new List<DateTime>();
            FirstName = "John";
            LastName = "Doe";
            Email = "JDoe@email.com";
            Phone = "1234567890";
        }
        public Volunteer(String fn, String ln, String email, String phone, ObservableCollection<string> skills) 
        {
            FirstName = fn;
            LastName = ln;
            Email = email;
            Phone = phone;
            Skills = skills;
            DatesRequestedOff = new List<DateTime>();

            VolunteerErrorCode vec = new VolunteerErrorCode();
            if (fn == "")
                vec.InvalidFirstName = true;
            if (ln == "")
                vec.InvalidLastName = true;

            if (vec.HasError)
                throw vec;
        }

        #region Public Properties
        public String FirstName
        {
            get;
            set;
        }
        public String LastName
        {
            get;
            set;
        }
        public String Email
        {
            get;
            set;
        }
        public String Phone
        {
            get;
            set;
        }

        public ObservableCollection<String> Skills
        {
            get;
            set;
        }

        public List<DateTime> DatesRequestedOff
        {
            get;
            set;
        }


        #endregion
    }
}
