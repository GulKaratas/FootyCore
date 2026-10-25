using FootyCore.DtoLayer.TeamDto;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface ITeamService : IGenericService<ResultTeamDto, CreateTeamDto, UpdateTeamDto, GetTeamByIdDto>
    {
    }
}
