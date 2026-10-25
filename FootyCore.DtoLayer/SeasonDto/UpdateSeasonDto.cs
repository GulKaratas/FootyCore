using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.SeasonDto
{
    public class UpdateSeasonDto
    {
        public int SeasonId { get; set; }

        public string SeasonName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
