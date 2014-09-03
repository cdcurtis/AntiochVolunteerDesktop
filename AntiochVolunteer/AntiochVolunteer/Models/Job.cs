using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
    public class Job
    {
        public Job()
        {
           ComboJobs = new List<long>();
           CanBePreformedByAnyone = true;
        }
        public Job(long id, string n, string d, List<long> l, bool canBePreformedByAnyone = true)
        {
            ID = id;
            Name = n;
            Description = d;
            ComboJobs = l;
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
        public List<long> ComboJobs
        {
            get;
            protected set;
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
        #endregion
    }

    
}
