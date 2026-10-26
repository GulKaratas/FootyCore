using Azure;
using FootyCore.BusinessLayer.Abstract;
using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DtoLayer.StandingDto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

public class StandingManager : IStandingService
{
    private readonly ITeamDal _teamDal;
    private readonly IMatchDal _matchDal;

    public StandingManager(ITeamDal teamDal, IMatchDal matchDal)
    {
        _teamDal = teamDal;
        _matchDal = matchDal;
    }

    public async Task<ResultStandingPageDto> GetStandingsBySeasonAsync(int seasonId)
    {
        var teams = await _teamDal.GetList();
        var matches = await _matchDal.GetFinishedMatchesBySeasonAsync(seasonId);

        var rows = teams.ToDictionary(
            t => t.TeamId,
            t => new ResultStandingDto
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                ShortName = t.TeamName.Length >= 3
                    ? t.TeamName.Substring(0, 3).ToUpper()
                    : t.TeamName.ToUpper(),
                LogoUrl = t.LogoUrl,
                Zone = "none"
            });

        foreach (var match in matches)
        {
            if (!rows.ContainsKey(match.HomeTeamId) || !rows.ContainsKey(match.AwayTeamId))
                continue;

            var home = rows[match.HomeTeamId];
            var away = rows[match.AwayTeamId];
            var homeScore = match.HomeScore.Value;
            var awayScore = match.AwayScore.Value;

            home.Played++;
            away.Played++;
            home.GoalsFor += homeScore;
            home.GoalsAgainst += awayScore;
            away.GoalsFor += awayScore;
            away.GoalsAgainst += homeScore;

            if (homeScore > awayScore)
            {
                home.Won++;
                home.Points += 3;
                away.Lost++;
                home.Form.Add("W");
                away.Form.Add("L");
            }
            else if (awayScore > homeScore)
            {
                away.Won++;
                away.Points += 3;
                home.Lost++;
                away.Form.Add("W");
                home.Form.Add("L");
            }
            else
            {
                home.Drawn++;
                away.Drawn++;
                home.Points++;
                away.Points++;
                home.Form.Add("D");
                away.Form.Add("D");
            }
        }

        foreach (var row in rows.Values)
        {
            if (row.Form.Count > 5)
            {
                row.Form = row.Form.Skip(row.Form.Count - 5).ToList();
            }
        }

        var ordered = rows.Values
            .OrderByDescending(x => x.Points)
            .ThenByDescending(x => x.GoalsFor - x.GoalsAgainst)
            .ThenByDescending(x => x.GoalsFor)
            .ToList();

        for (int i = 0; i < ordered.Count; i++)
        {
            var row = ordered[i];
            row.Position = i + 1;
            row.GoalDifference = row.GoalsFor - row.GoalsAgainst;

            if (row.Position == 1)
                row.Zone = "champ";
            else if (row.Position <= 4)
                row.Zone = "ucl";
            else if (row.Position <= 6)
                row.Zone = "uel";
            else if (i >= ordered.Count - 3)
                row.Zone = "rel";
        }

        var last = matches.LastOrDefault();
        var featuredText = "";
        var featuredStadium = "";

        if (last != null && rows.ContainsKey(last.HomeTeamId) && rows.ContainsKey(last.AwayTeamId))
        {
            featuredText = $"{rows[last.HomeTeamId].ShortName} {last.HomeScore}–{last.AwayScore} {rows[last.AwayTeamId].ShortName}";
            featuredStadium = last.Stadium?.StadiumName ?? "";
        }

        return new ResultStandingPageDto
        {
            Week = matches.Count == 0 ? 0 : matches.Max(x => x.Week),
            FeaturedText = featuredText,
            FeaturedStadium = featuredStadium,
            Standings = ordered
        };
    }
}