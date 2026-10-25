using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.MatchStatusDto
{
    public class GetMatchStatusByIdDto
    {
        public int MatchStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
