using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.TeamDto;

namespace FootyCore.WebUI.Areas.Admin.Models
{
    public class MatchEventFormViewModel
    {
        public int MatchDetailId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int Minute { get; set; }
        public List<ResultMatchDto> Matches { get; set; } = new();
        public List<ResultTeamDto> Teams { get; set; } = new();
    }

    public class MatchEventPageViewModel
    {
        public List<ResultMatchDetailDto> Events { get; set; } = new();
        public ResultMatchDto Featured { get; set; }
    }
}
