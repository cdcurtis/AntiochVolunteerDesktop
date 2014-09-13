using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiochVolunteer.Models
{
    public class SkillSet
    {

        public SkillSet(String s = "")
        {
            Skill = s;
        }
        public String Skill { get; set; }
    }
}
