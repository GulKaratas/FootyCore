using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using FootyCore.DataAccessLayer.Repositories;
using FootyCore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootyCore.DataAccessLayer.EntityFramework
{
    public class EfMatchDal : GenericRepository<Match> , IMatchDal
    {
        protected readonly FootyContext _context;

        public EfMatchDal(FootyContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Match>> GetFinishedMatchesBySeasonAsync(int seasonId)
        {
            return await _context.Matches
                .Include(x => x.Stadium)
                .Where(x => x.SeasonId == seasonId
                    && x.MatchStatus.StatusName == "Bitti"
                    && x.HomeScore != null
                    && x.AwayScore != null)
                .OrderBy(x => x.MatchDate)
                .ToListAsync();
        }
        public async Task<List<Match>> GetMatchesBySeasonAndWeekAsync(int seasonId, int week)
        {
            return await _context.Matches
                .Include(x => x.HomeTeam)
                    .ThenInclude(x => x.League)
                .Include(x => x.AwayTeam)
                .Include(x => x.Stadium)
                .Include(x => x.MatchStatus)
                .Where(x => x.SeasonId == seasonId && x.Week == week)
                .OrderBy(x => x.MatchDate)
                .ToListAsync();
        }
        public async Task<Match> GetMatchDetailsByIdAsync(int matchId)
        {
            return await _context.Matches
                .Include(x => x.HomeTeam).ThenInclude(x => x.League)
                .Include(x => x.AwayTeam)
                .Include(x => x.Stadium)
                .Include(x => x.MatchStatus)
                .Include(x => x.Season)
                .Include(x => x.MatchStatistic)
                .FirstOrDefaultAsync(x => x.MatchId == matchId);
        }

        public async Task<List<Match>> GetMatchesWithDetailsAsync()
        {
            return await _context.Matches
                .Include(x => x.HomeTeam)
                    .ThenInclude(x => x.League)
                .Include(x => x.AwayTeam)
                .Include(x => x.Stadium)
                .Include(x => x.MatchStatus)
                .Include(x => x.MatchStatistic)
                .OrderBy(x => x.MatchDate)
                .ToListAsync();
        }
    }
}
