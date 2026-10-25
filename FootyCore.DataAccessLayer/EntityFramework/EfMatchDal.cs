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
        public async Task<List<Match>> GetMatchesWithDetailsAsync()
        {
            return await _context.Matches
                .Include(x => x.HomeTeam)
                    .ThenInclude(x => x.League)
                .Include(x => x.AwayTeam)
                .Include(x => x.Stadium)
                .Include(x => x.MatchStatus)
                .OrderBy(x => x.MatchDate)
                .ToListAsync();
        }
    }
}
