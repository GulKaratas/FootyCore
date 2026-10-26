using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatisticDto;

namespace FootyCore.WebUI.Models
{
    public class MatchDetailsViewModel
    {
        public ResultMatchDto Match { get; set; }
        public List<ResultMatchDetailDto> Details { get; set; } = new();
        public ResultMatchStatisticDto? Statistic { get; set; }
        public List<ResultMatchDetailDto> Goals { get; set; } = new();
        public List<ResultMatchDetailDto> Cards { get; set; } = new();
        public List<ResultMatchDetailDto> Substitutions { get; set; } = new();
    }
}