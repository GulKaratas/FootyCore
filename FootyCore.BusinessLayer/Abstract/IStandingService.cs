using FootyCore.DtoLayer.StandingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Abstract
{
    public interface IStandingService
    {
        Task<ResultStandingPageDto> GetStandingsBySeasonAsync(int seasonId);
    }
}
