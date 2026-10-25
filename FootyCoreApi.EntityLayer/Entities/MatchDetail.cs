using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.EntityLayer.Entities
{
    public class MatchDetail
    {
        public int MatchDetailId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public string ActionType { get; set; }

        public string Description { get; set; }

        public int Minute { get; set; }
    }
}
