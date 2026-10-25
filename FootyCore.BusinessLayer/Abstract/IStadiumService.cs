using FootyCore.DtoLayer.StadiumDto;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IStadiumService : IGenericService<ResultStadiumDto, CreateStadiumDto, UpdateStadiumDto, GetStadiumByIdDto>
    {
    }
}
