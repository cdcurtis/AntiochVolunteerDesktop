using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
    public class Event
    {
        public Event()
        {
            Jobs = new List<Job>();
        }
        public Event(Event e)
        {
            Jobs = new List<Job>();
            foreach (Job j in e.Jobs)
                Jobs.Add(j);
        }

        #region Public Methods
        
        public void AddJob(Job j)
        {
            Jobs.Add(j);
        }

        #endregion

        #region Public Properties
        public String Name
        {
            get;
            set;
        }

        public List<Job> Jobs
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }
        #endregion
    }
}
