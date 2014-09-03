using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.ViewModels
{
    public class AddVolunteerDlgViewModel : ViewModelBase
    {
        private ViewModelBase _parent;
        public AddVolunteerDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
        }
    }
}
