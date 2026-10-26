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
        private readonly IMatchStatusDal _matchStatusDal;
        private readonly ITeamDal _teamDal;
        private readonly IStadiumDal _stadiumDal;
        private readonly ISeasonDal _seasonDal;
        private readonly IMapper _mapper;

        public MatchManager(
            IMatchDal matchDal,
            IMatchStatusDal matchStatusDal,
            ITeamDal teamDal,
            IStadiumDal stadiumDal,
            ISeasonDal seasonDal,
            IMapper mapper)
        {
            _matchDal = matchDal;
            _matchStatusDal = matchStatusDal;
            _teamDal = teamDal;
            _stadiumDal = stadiumDal;
            _seasonDal = seasonDal;
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
            var value = await _matchDal.GetMatchesWithDetailsAsync();
            return _mapper.Map<List<ResultMatchDto>>(value);
        }

        public async Task TInsert(CreateMatchDto dto)
        {
            var teams = await _teamDal.GetList();
            var stadiums = await _stadiumDal.GetList();
            var seasons = await _seasonDal.GetList();
            var statuses = await _matchStatusDal.GetList();

            var home = teams.FirstOrDefault(x => SameName(x.TeamName, dto.HomeTeamName));
            var away = teams.FirstOrDefault(x => SameName(x.TeamName, dto.AwayTeamName));
            var stadium = stadiums.FirstOrDefault(x => SameName(x.StadiumName, dto.StadiumName));
            var season = seasons.Where(x => x.IsActive).OrderBy(x => x.SeasonId).FirstOrDefault()
                ?? seasons.OrderBy(x => x.SeasonId).FirstOrDefault();
            var status = statuses.FirstOrDefault(x => SameName(x.StatusName, dto.StatusName))
                ?? statuses.FirstOrDefault(x => x.StatusName == "Oynanmadı")
                ?? statuses.FirstOrDefault();

            if (home == null || away == null || home.TeamId == away.TeamId || stadium == null || season == null || status == null)
            {
                throw new InvalidOperationException("Takım, stadyum, sezon veya durum bulunamadı.");
            }

            var match = new Match
            {
                Week = dto.Week,
                MatchDate = dto.MatchDate,
                SeasonId = season.SeasonId,
                HomeTeamId = home.TeamId,
                AwayTeamId = away.TeamId,
                StadiumId = stadium.StadiumId,
                MatchStatusId = status.MatchStatusId,
                HomeScore = null,
                AwayScore = null
            };

            await _matchDal.Insert(match);
        }

        private static bool SameName(string left, string right)
        {
            return string.Equals(left?.Trim(), right?.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public async Task TUpdate(UpdateMatchDto dto)
        {
            var match = await _matchDal.GetById(dto.MatchId);
            if (match == null)
            {
                return;
            }

            match.Week = dto.Week;
            match.MatchDate = dto.MatchDate;
            match.HomeScore = dto.HomeScore;
            match.AwayScore = dto.AwayScore;

            if (!string.IsNullOrWhiteSpace(dto.StatusName))
            {
                var statuses = await _matchStatusDal.GetList();
                var status = statuses.FirstOrDefault(x => SameName(x.StatusName, dto.StatusName));
                if (status != null)
                {
                    match.MatchStatusId = status.MatchStatusId;
                }
            }

            if (!string.IsNullOrWhiteSpace(dto.StadiumName))
            {
                var stadiums = await _stadiumDal.GetList();
                var stadium = stadiums.FirstOrDefault(x => SameName(x.StadiumName, dto.StadiumName));
                if (stadium != null)
                {
                    match.StadiumId = stadium.StadiumId;
                }
            }

            await _matchDal.Update(match);
        }
    }
}
