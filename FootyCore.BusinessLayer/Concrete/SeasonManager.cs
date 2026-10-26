using AutoMapper;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.SeasonDto;
using FootyCore.EntityLayer.Entities;

namespace FootyCore.BusinessLayer.Concrete
{
    public class SeasonManager : ISeasonService
    {
        private readonly ISeasonDal _seasonDal;
        private readonly IMapper _mapper;

        public SeasonManager(ISeasonDal seasonDal, IMapper mapper)
        {
            _seasonDal = seasonDal;
            _mapper = mapper;
        }

        public Task TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetSeasonByIdDto> TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultSeasonDto>> TGetList()
        {
            var values = (await _seasonDal.GetList()).OrderBy(x => x.SeasonId).ToList();
            return _mapper.Map<List<ResultSeasonDto>>(values);
        }

        public Task TInsert(CreateSeasonDto dto)
        {
            throw new NotImplementedException();
        }

        public Task TUpdate(UpdateSeasonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
