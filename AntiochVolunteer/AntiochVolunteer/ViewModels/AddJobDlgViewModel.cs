using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.ViewModels
{
    public class AddJobDlgViewModel : ViewModelBase
    {
        private ViewModelBase _parent;
        public AddJobDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
        }
    }
}
