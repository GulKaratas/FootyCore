using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchDetailManager : IMatchDetailService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMatchDetailByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultMatchDetailDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateMatchDetailDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateMatchDetailDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
