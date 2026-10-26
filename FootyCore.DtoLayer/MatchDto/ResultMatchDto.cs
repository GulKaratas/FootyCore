using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchStatisticDto;

namespace FootyCore.DtoLayer.MatchDto
{
    public class ResultMatchDto
    {
        public int MatchId { get; set; }
        public int Week { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public string LeagueName { get; set; }
        public string SeasonName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeLogoUrl { get; set; }
        public string AwayLogoUrl { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
        public string StatusName { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public List<ResultMatchDetailDto> Details { get; set; } = new();
        public ResultMatchStatisticDto? Statistic { get; set; }
    }
}
