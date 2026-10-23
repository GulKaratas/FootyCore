
namespace FootyCore.EntityLayer.Entities
{
    public class Match
    {
        public int MatchId { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }

        public int MatchStatusId { get; set; }
        public MatchStatus MatchStatus { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }

        public List<MatchDetail> MatchDetails { get; set; }
        public MatchStatistic? MatchStatistic { get; set; }
    }
}