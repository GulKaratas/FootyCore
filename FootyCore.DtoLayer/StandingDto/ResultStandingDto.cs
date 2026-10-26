using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.StandingDto
{
    public class ResultStandingDto
    {
        public int Position { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public string Zone { get; set; }
        public List<string> Form { get; set; } = new();
    }
}
