using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.SeasonDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class SeasonManager : ISeasonService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetSeasonByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultSeasonDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateSeasonDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateSeasonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
