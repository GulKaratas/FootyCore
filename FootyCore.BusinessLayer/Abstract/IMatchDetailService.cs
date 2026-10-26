using FootyCore.DtoLayer.MatchDetailDto;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IMatchDetailService : IGenericService<ResultMatchDetailDto, CreateMatchDetailDto, UpdateMatchDetailDto, GetMatchDetailByIdDto>
    {
        Task<List<ResultMatchDetailDto>> GetDetailsByMatchIdAsync(int matchId);
    }
}
