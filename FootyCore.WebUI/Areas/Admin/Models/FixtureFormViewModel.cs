using FootyCore.DtoLayer.MatchStatusDto;
using FootyCore.DtoLayer.StadiumDto;
using FootyCore.DtoLayer.TeamDto;

namespace FootyCore.WebUI.Areas.Admin.Models
{
    public class FixtureFormViewModel
    {
        public int MatchId { get; set; }
        public int? Week { get; set; }
        public DateTime? MatchDate { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeLogoUrl { get; set; }
        public string AwayLogoUrl { get; set; }
        public string StadiumName { get; set; }
        public string StatusName { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public List<ResultTeamDto> Teams { get; set; } = new();
        public List<ResultStadiumDto> Stadiums { get; set; } = new();
        public List<ResultMatchStatusDto> Statuses { get; set; } = new();
    }
}
