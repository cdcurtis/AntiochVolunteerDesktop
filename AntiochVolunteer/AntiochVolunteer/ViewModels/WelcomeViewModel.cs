using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        private ViewModelBase _parent;

        public WelcomeViewModel(ViewModelBase parent)
        {
            _parent = parent;
            ViewLoaded = "Welcome View loaded Properly";
        }

        public string ViewLoaded
        {
            get;
            set;
        }
    }
}
