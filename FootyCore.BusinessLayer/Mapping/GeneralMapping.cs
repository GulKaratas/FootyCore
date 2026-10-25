using AutoMapper;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace FootyCore.BusinessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() {

            CreateMap<Match, ResultMatchDto>()
        }
    }
}
