using FootyCore.DtoLayer.StandingDto;

namespace FootyCore.WebUI.Models
{
    public class StandingPageViewModel
    {
        public string SeasonName { get; set; }
        public int Week { get; set; }
        public string FeaturedText { get; set; }
        public string FeaturedStadium { get; set; }
        public List<ResultStandingDto> Standings { get; set; }
    }
}