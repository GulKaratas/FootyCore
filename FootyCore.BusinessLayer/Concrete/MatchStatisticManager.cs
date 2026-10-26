using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.EntityLayer.Entities;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchStatisticManager : IMatchStatisticService
    {
        private readonly IMatchStatisticDal _matchStatisticDal;
        private readonly IMapper _mapper;

        public MatchStatisticManager(IMatchStatisticDal matchStatisticDal, IMapper mapper)
        {
            _matchStatisticDal = matchStatisticDal;
            _mapper = mapper;
        }

        public async Task TDelete(int id)
        {
            await _matchStatisticDal.Delete(id);
        }

        public async Task<GetMatchStatisticByIdDto> TGetById(int id)
        {
            var value = await _matchStatisticDal.GetById(id);
            return _mapper.Map<GetMatchStatisticByIdDto>(value);
        }

        public async Task<List<ResultMatchStatisticDto>> TGetList()
        {
            var value = await _matchStatisticDal.GetList();
            return _mapper.Map<List<ResultMatchStatisticDto>>(value);
        }

        public async Task TInsert(CreateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            await _matchStatisticDal.Insert(value);
        }

        public async Task TUpdate(UpdateMatchStatisticDto dto)
        {
            var value = _mapper.Map<MatchStatistic>(dto);
            await _matchStatisticDal.Update(value);
        }
    }
}
