using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AntiochVolunteer.Models
{
    public class Job
    {
        public Job()
        {
            ComboJobs = new ObservableCollection<string>();
            SkillsRequired = new ObservableCollection<string>();
            CanBePreformedByAnyone = true;
        }
        public Job(long id, string n, string d, ObservableCollection<String> l, ObservableCollection<String> skills, bool canBePreformedByAnyone = true)
        {
            ComboJobs = new ObservableCollection<string>();
            SkillsRequired = new ObservableCollection<string>();

            ID = id;
            Name = n;
            Description = d;
            ComboJobs = l;
            SkillsRequired = skills;
            CanBePreformedByAnyone = canBePreformedByAnyone;
        }

        
        #region Public Properties
        public long ID
        {
            get;
            protected set;
        }

        public String Name
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        public ObservableCollection<String> ComboJobs
        {
            get;
            set;
        }
        public int MinimumVolenteersNeededToPreform
        {
            get;
            set;
        }
        public int RecommendedVolenteersNeededToPreform
        {
            get;
            set;
        }
        public bool CanBePreformedByAnyone
        {
            get;
            set;
        }
        public ObservableCollection<string> SkillsRequired
        {
            get;
            set;
        }
        #endregion
    }

    
}
