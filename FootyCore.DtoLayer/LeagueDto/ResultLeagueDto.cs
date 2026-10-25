using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.LeagueDto
{
    public class ResultLeagueDto
    {
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public string Country { get; set; }

        public string LogoUrl { get; set; }

        public List<Team> Teams { get; set; }
    }
}
