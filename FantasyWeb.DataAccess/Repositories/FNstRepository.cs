using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Extensions;
using FantasyWeb.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FantasyWeb.DataAccess.Repositories
{
    public class FNstRepository : IFNstRepository
    {
        private readonly DbSet<FTeamNST> entitiesDataSet;

        public FNstRepository(DbContext context)
        {
            entitiesDataSet = context.Set<FTeamNST>();
        }

        public async Task<IEnumerable<TeamStats>> GetLastTeamResultsAsync(int seasonID, int formGamesCount)
        {
            var val = await entitiesDataSet
                .GetValueWithInclude<FTeamNST>(x => x.DTeam, x => x.DGame)
                //.Where(x => x.DGame.SeasonId == seasonID)
                .GroupBy(x => x.DTeam.Id)
                .Select(x => new TeamStats
                {
                    TeamID = x.Key,
                    TeamGoalsForm = x.OrderByDescending(x => x.DGame.GameDate).Take(formGamesCount).Average(x => x.GF ?? 0),
                    TeamGoalsAwayForm = x.OrderByDescending(x => x.DGame.GameDate).Take(formGamesCount).Average(x => x.GA ?? 0),
                    TeamForm = x.OrderByDescending(x => x.DGame.GameDate).Select(x => x).Take(formGamesCount).ConvertResultsToString(),
                })
                .ToListAsync();

            return val;
        }
    }
}
