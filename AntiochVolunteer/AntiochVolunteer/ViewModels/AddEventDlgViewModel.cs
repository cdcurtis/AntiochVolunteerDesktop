using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.ViewModels
{
    public class AddEventDlgViewModel : ViewModelBase
    {
        private ViewModelBase _parent;
        public AddEventDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
        }
    }
}
