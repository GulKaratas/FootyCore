using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.TeamDto;

namespace FootyCore.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;
        private readonly IMapper _mapper;

        public TeamManager(ITeamDal teamDal, IMapper mapper)
        {
            _teamDal = teamDal;
            _mapper = mapper;
        }

        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetTeamByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTeamDto>> TGetList()
        {
            var values = await _teamDal.GetList();
            return _mapper.Map<List<ResultTeamDto>>(values);
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
