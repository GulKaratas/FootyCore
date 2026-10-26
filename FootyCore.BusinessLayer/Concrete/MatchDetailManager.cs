using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
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
        private readonly IMatchDetailDal _matchDetailDal;
        private readonly IMapper _mapper;

        public MatchDetailManager(IMatchDetailDal matchDetailDal, IMapper mapper)
        {
            _matchDetailDal = matchDetailDal;
            _mapper = mapper;
        }

        public async Task<List<ResultMatchDetailDto>> GetDetailsByMatchIdAsync(int matchId)
        {
            var values = await _matchDetailDal.GetDetailsByMatchIdAsync(matchId);
            return _mapper.Map<List<ResultMatchDetailDto>>(values);
        }

        public async Task TDelete(int id)
        {
            await _matchDetailDal.Delete(id);
        }

        public async Task<GetMatchDetailByIdDto> TGetById(int id)
        {
            var value = await _matchDetailDal.GetById(id);
            return _mapper.Map<GetMatchDetailByIdDto>(value);
        }

        public async Task<List<ResultMatchDetailDto>> TGetList()
        {
            var values = await _matchDetailDal.GetAllWithTeamAsync();
            return _mapper.Map<List<ResultMatchDetailDto>>(values);
        }

        public async Task TInsert(CreateMatchDetailDto dto)
        {
            var value = _mapper.Map<MatchDetail>(dto);
            await _matchDetailDal.Insert(value);
        }

        public async Task TUpdate(UpdateMatchDetailDto dto)
        {
            var value = _mapper.Map<MatchDetail>(dto);
            await _matchDetailDal.Update(value);
        }
    }
}
