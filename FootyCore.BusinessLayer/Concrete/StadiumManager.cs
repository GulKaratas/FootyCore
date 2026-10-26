using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.StadiumDto;

namespace FootyCore.BusinessLayer.Concrete
{
    public class StadiumManager : IStadiumService
    {
        private readonly IStadiumDal _stadiumDal;
        private readonly IMapper _mapper;

        public StadiumManager(IStadiumDal stadiumDal, IMapper mapper)
        {
            _stadiumDal = stadiumDal;
            _mapper = mapper;
        }

        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetStadiumByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultStadiumDto>> TGetList()
        {
            var values = await _stadiumDal.GetList();
            return _mapper.Map<List<ResultStadiumDto>>(values);
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
