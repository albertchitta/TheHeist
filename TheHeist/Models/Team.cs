using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeist.Models
{
    internal class Team
    {
        public List<TeamMember> Members { get; set; } = new List<TeamMember>();

        public void AddMember(TeamMember member)
        {
            Members.Add(member);
        }
    }
}
