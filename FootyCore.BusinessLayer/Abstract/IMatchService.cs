using FootyCore.DtoLayer.MatchDto;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IMatchService : IGenericService<ResultMatchDto, CreateMatchDto, UpdateMatchDto, GetMatchByIdDto>
    {
        Task<List<ResultMatchDto>> GetMatchesWithDetailsAsync();

    }
}
