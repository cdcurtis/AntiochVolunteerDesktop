using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
    public class IDGen
    {
        private long _ids;
        public IDGen()
        {
            _ids = 0;
        }
        public IDGen(long l)
        {
            _ids = l;
        }

        public long NewID
        {
            get { return _ids++; }
        }

    }
}
