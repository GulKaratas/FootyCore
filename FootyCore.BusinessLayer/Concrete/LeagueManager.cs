using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.LeagueDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class LeagueManager : ILeagueService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetLeagueByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultLeagueDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateLeagueDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateLeagueDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
