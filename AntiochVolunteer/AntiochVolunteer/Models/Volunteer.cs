using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
    //TODO:: add regex validation.
    public class Volunteer
    {
        Volunteer() 
        {
            UserRoles = new List<long>();
            UserPrimaryRoles = new List<long>();
            DatesRequestedOff = new List<DateTime>();
        }
        Volunteer(String fn, String ln, String email, String phone, List<long> roles, List<long> pRoles) 
        {
            FirstName = fn;
            LastName = ln;
            Email = email;
            Phone = phone;
            UserRoles = roles;
            UserPrimaryRoles = pRoles;
            DatesRequestedOff = new List<DateTime>();
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

        public List<long> UserRoles
        {
            get;
            set;
        }

        public List<long> UserPrimaryRoles
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
