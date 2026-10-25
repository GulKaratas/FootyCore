using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatusDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchStatusManager : IMatchStatusService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMatchStatusByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultMatchStatusDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateMatchStatusDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateMatchStatusDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
