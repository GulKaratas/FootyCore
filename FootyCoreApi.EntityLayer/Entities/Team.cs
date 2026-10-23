using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.EntityLayer.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string LogoUrl { get; set; }

        public int StadiumId { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public Stadium Stadium { get; set; }

        public int FoundedYear { get; set; }

        public string City { get; set; }

        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
    }
}
