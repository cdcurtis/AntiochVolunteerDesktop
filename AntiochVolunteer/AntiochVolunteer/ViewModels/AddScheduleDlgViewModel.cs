using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.ViewModels
{
    public class AddScheduleDlgViewModel : ViewModelBase
    {
        private ViewModelBase _parent;
        public AddScheduleDlgViewModel(ViewModelBase parent)
        {
            _parent = parent;
        }
    }
}
