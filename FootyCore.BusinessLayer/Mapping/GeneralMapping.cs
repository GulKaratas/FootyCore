using AutoMapper;
using FootyCore.DtoLayer.MatchDetailDto;
using FootyCore.DtoLayer.MatchDto;
using FootyCore.DtoLayer.MatchStatisticDto;
using FootyCore.DtoLayer.SeasonDto;
using FootyCore.EntityLayer.Entities;

namespace FootyCore.BusinessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Season, ResultSeasonDto>();

            CreateMap<Match, ResultMatchDto>()
                .ForMember(dest => dest.HomeTeamName,
                    opt => opt.MapFrom(src => src.HomeTeam.TeamName))
                .ForMember(dest => dest.AwayTeamName,
                    opt => opt.MapFrom(src => src.AwayTeam.TeamName))
                .ForMember(dest => dest.HomeLogoUrl,
                    opt => opt.MapFrom(src => src.HomeTeam.LogoUrl))
                .ForMember(dest => dest.AwayLogoUrl,
                    opt => opt.MapFrom(src => src.AwayTeam.LogoUrl))
                .ForMember(dest => dest.StadiumName,
                    opt => opt.MapFrom(src => src.Stadium.StadiumName))
                .ForMember(dest => dest.StatusName,
                    opt => opt.MapFrom(src => src.MatchStatus.StatusName))
                .ForMember(dest => dest.LeagueName,
                    opt => opt.MapFrom(src => src.HomeTeam.League == null
                        ? string.Empty
                        : src.HomeTeam.League.LeagueName))
                .ForMember(dest => dest.SeasonName,
                    opt => opt.MapFrom(src => src.Season == null
                        ? string.Empty
                        : src.Season.SeasonName))
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.Stadium == null
                        ? string.Empty
                        : src.Stadium.City));

            CreateMap<MatchDetail, ResultMatchDetailDto>();
            CreateMap<MatchStatistic, ResultMatchStatisticDto>();
        }
    }
}
