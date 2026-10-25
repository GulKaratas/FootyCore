using FootyCore.DtoLayer.LeagueDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface ILeagueService :IGenericService<ResultLeagueDto, CreateLeagueDto,UpdateLeagueDto, GetLeagueByIdDto>
    {
    }
}
