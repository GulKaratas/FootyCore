using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using FootyCore.DataAccessLayer.Repositories;
using FootyCore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootyCore.DataAccessLayer.EntityFramework
{
    public class EfMatchDetailDal : GenericRepository<MatchDetail>, IMatchDetailDal
    {
        private readonly FootyContext _context;

        public EfMatchDetailDal(FootyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MatchDetail>> GetDetailsByMatchIdAsync(int matchId)
        {
            return await _context.MatchDetails
                .Where(x => x.MatchId == matchId)
                .OrderBy(x => x.Minute)
                .ToListAsync();
        }

        public async Task<List<MatchDetail>> GetAllWithTeamAsync()
        {
            return await _context.MatchDetails
                .Include(x => x.Team)
                .OrderBy(x => x.Minute)
                .ToListAsync();
        }
    }
}
