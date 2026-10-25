using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IGenericService<TResultDto, TCreateDto, TUpdateDto, TGetByIdDto>
    {
        Task<List<TResultDto>> TGetList();
        Task<TGetByIdDto> TGetById(int id);
        Task TInsert(TCreateDto dto);
        Task TUpdate(TUpdateDto dto);
        Task TDelete(int id);
    }
}
