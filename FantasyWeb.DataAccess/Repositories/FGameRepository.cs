using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FantasyWeb.DataAccess.Repositories
{
    public class FGameRepository: IFGameRepository
    {
        private readonly DbSet<FGame> entitiesDataSet;

        public FGameRepository(DbContext context)
        {
            entitiesDataSet = context.Set<FGame>();
        }

        public async Task<IEnumerable<FGame>> GetAllGamePredictionsAsync(int seasonID)
        {

            return await entitiesDataSet
                .GetValueWithInclude<FGame>(x => x.DGame,
                                            x => x.DGame.HomeTeam,
                                            x => x.DGame.AwayTeam)
                .Where(x => x.DGame.WeekNumber > 0 && x.DGame.SeasonId == seasonID && x.DGame.GameDate.Day >= DateTime.Today.Day)
                .ToListAsync();
        }
    }
}
