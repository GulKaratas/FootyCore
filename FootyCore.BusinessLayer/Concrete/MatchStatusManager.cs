using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatusDto;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchStatusManager : IMatchStatusService
    {
        private readonly IMatchStatusDal _matchStatusDal;
        private readonly IMapper _mapper;

        public MatchStatusManager(IMatchStatusDal matchStatusDal, IMapper mapper)
        {
            _matchStatusDal = matchStatusDal;
            _mapper = mapper;
        }

        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMatchStatusByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultMatchStatusDto>> TGetList()
        {
            var values = await _matchStatusDal.GetList();
            return _mapper.Map<List<ResultMatchStatusDto>>(values);
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
