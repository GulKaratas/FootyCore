using FootyCore.EntityLayer.Entities;

namespace FootyCore.DataAccessLayer.Abstract
{
    public interface IMatchDetailDal : IGenericDal<MatchDetail>
    {
        Task<List<MatchDetail>> GetDetailsByMatchIdAsync(int matchId);
    }
}
