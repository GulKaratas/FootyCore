using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootyCore.EntityLayer.Entities;
using System.Threading.Tasks;

namespace FootyCore.DataAccessLayer.Abstract
{
    public interface IMatchDal : IGenericDal<Match>
    {
        Task<List<Match>> GetFinishedMatchesBySeasonAsync(int seasonId);
        Task<List<Match>> GetMatchesBySeasonAndWeekAsync(int seasonId, int week);
        Task<Match> GetMatchDetailsByIdAsync(int matchId);
        Task<List<Match>> GetMatchesWithDetailsAsync();
    }
}
