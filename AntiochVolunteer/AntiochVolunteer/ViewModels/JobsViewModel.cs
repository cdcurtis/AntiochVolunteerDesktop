using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AntiochVolunteer.Models;

namespace AntiochVolunteer.ViewModels
{
    public class JobsViewModel: ViewModelBase
    {
        private ViewModelBase _parent;
        private ApplicationData _app;
        public JobsViewModel(ViewModelBase parent)
        {
            _parent = parent;
            _app = (parent as MainWindowViewModel).AppData;
            JobList = _app.JobMasterList;
            NotifyPropertyChanged("JobList");
        }

        public ObservableCollection<Job> JobList { get; protected set; }
    }
}
