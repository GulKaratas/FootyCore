using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.DtoLayer.StadiumDto
{
    public class CreateStadiumDto
    {
        public string StadiumName { get; set; }

        public string City { get; set; }

        public int Capacity { get; set; }

    }
}
