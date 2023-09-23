using FantasyWeb.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IPlayersStatsRepository
    {
        Task<IEnumerable<PlayerStats>> GetPlayerStatsAsync(int seasonId, int formGamesCount);
    }
}
