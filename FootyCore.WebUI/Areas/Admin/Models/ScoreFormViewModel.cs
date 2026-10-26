using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatusDto;

namespace FootyCore.WebUI.Areas.Admin.Models
{
    public class ScoreFormViewModel
    {
        public int MatchId { get; set; }
        public int MatchStatisticId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeLogoUrl { get; set; }
        public string AwayLogoUrl { get; set; }
        public string StadiumName { get; set; }
        public int Week { get; set; }
        public string StatusName { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
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
        public List<ResultMatchDto> Matches { get; set; } = new();
        public List<ResultMatchStatusDto> Statuses { get; set; } = new();
    }
}
