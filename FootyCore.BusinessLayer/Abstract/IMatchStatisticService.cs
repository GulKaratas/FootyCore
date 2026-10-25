using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IMatchStatisticService :IGenericService<ResultMatchStatisticDto, CreateMatchStatisticDto,UpdateMatchStatisticDto, GetMatchStatisticByIdDto>
    {
    }
}
