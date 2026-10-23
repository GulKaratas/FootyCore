using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.EntityLayer.Entities
{
    public class MatchStatistic
    {

        public int MatchStatisticId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int HomeFirstHalfGoals { get; set; }
        public int AwayFirstHalfGoals { get; set; }

        public int HomeSecondHalfGoals { get; set; }
        public int AwaySecondHalfGoals { get; set; }

        public int HomeShots { get; set; }
        public int AwayShots { get; set; }

        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }

        public int HomePossession { get; set; }
        public int AwayPossession { get; set; }
    }
}
