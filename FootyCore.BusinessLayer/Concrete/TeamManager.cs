using FootyCore.BusinessLayer.Abstract;
using FootyCore.DtoLayer.TeamDto;

namespace FootyCore.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetTeamByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultTeamDto>> TGetList()
        {
            throw new NotImplementedException();
        }

        public Task TInsert(CreateTeamDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateTeamDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
