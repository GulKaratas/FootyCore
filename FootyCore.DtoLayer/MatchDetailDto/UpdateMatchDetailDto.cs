using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.MatchDetailDto
{
    public class UpdateMatchDetailDto
    {
        public int MatchDetailId { get; set; }

        public int MatchId { get; set; }
        public string ActionType { get; set; }

        public string Description { get; set; }

        public int Minute { get; set; }
    }
}
