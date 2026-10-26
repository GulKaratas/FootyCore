using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.SeasonDto;

namespace FootyCore.WebUI.Models
{
    public class MatchPageViewModel
    {
        public List<ResultMatchDto> Matches { get; set; }
        public List<ResultSeasonDto> Seasons { get; set; }
        public int SelectedSeasonId { get; set; }
        public int SelectedWeek { get; set; }
        public string LeagueName { get; set; } = "Premier League";
        public string DateRange { get; set; } = "";
        public ResultMatchDto? FeaturedMatch { get; set; }
    }
}
