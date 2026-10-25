using FootyCore.DtoLayer.MatchStatusDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IMatchStatusService : IGenericService<ResultMatchStatusDto, CreateMatchStatusDto,UpdateMatchStatusDto, GetMatchStatusByIdDto>
    {
    }
}
