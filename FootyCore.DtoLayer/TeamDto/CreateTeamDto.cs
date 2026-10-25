using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.TeamDto
{
    public class CreateTeamDto
    {
        public string TeamName { get; set; }

        public string LogoUrl { get; set; }

        public int StadiumId { get; set; }
        public int LeagueId { get; set; }
        public int FoundedYear { get; set; }
        public string City { get; set; }
    }
}
