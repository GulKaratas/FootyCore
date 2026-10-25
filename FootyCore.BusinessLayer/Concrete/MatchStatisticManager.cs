using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchStatisticManager : IMatchStatisticService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMatchStatisticByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultMatchStatisticDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateMatchStatisticDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateMatchStatisticDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
