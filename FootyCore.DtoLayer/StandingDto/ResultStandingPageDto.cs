using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.StandingDto
{
    public class ResultStandingPageDto
    {
        public int Week { get; set; }
        public string FeaturedText { get; set; }
        public string FeaturedStadium { get; set; }
        public List<ResultStandingDto> Standings { get; set; }
    }
}
