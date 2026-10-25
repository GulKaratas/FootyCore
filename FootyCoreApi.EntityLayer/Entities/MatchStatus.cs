using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.EntityLayer.Entities
{
    public class MatchStatus
    {
        public int MatchStatusId { get; set; }
        public string StatusName { get; set; }
        public List<Match> Matches { get; set; }
    }
}
