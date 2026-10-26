using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Concrete
{
    public class MatchManager : IMatchService
    {
        private readonly IMatchDal _matchDal;
        private readonly IMapper _mapper;

        public MatchManager(IMatchDal matchDal,IMapper mapper)
        {
            _matchDal = matchDal;
            _mapper = mapper;
        }

        public async Task<ResultMatchDto?> GetMatchDetailsByIdAsync(int matchId)
        {
            var match = await _matchDal.GetMatchDetailsByIdAsync(matchId);
            if (match == null)
                return null;

            var dto = _mapper.Map<ResultMatchDto>(match);
            dto.Statistic = match.MatchStatistic == null
                ? null
                : _mapper.Map<ResultMatchStatisticDto>(match.MatchStatistic);
            return dto;
        }

        public async Task<List<ResultMatchDto>> GetMatchesBySeasonAndWeekAsync(int seasonId, int week)
        {
            var value = await _matchDal.GetMatchesBySeasonAndWeekAsync(seasonId, week);
            return _mapper.Map<List<ResultMatchDto>>(value);
        }

        public async Task<List<ResultMatchDto>> GetMatchesWithDetailsAsync()
        {
            var value = await _matchDal.GetMatchesWithDetailsAsync();
            return _mapper.Map<List<ResultMatchDto>>(value);
        }

        public async Task TDelete(int id)
        {
            await _matchDal.Delete(id);
        }

        public async Task<GetMatchByIdDto> TGetById(int id)
        {
            var value = await _matchDal.GetById(id);
            return _mapper.Map<GetMatchByIdDto>(value);
            
        }

        public async Task<List<ResultMatchDto>> TGetList()
        {
            var value = await _matchDal.GetList();
            return _mapper.Map<List<ResultMatchDto>>(value);
        }

        public async Task TInsert(CreateMatchDto dto)
        {
            var value = _mapper.Map<Match>(dto);
            await _matchDal.Insert(value);
        }

        public async Task TUpdate(UpdateMatchDto dto)
        {
            var value = _mapper.Map<Match>(dto);
            await _matchDal.Update(value);
        }
    }
}
