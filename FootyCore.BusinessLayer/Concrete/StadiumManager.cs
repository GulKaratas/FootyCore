using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.StadiumDto;

namespace FootyCore.BusinessLayer.Concrete
{
    public class StadiumManager : IStadiumService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetStadiumByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultStadiumDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateStadiumDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateStadiumDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
