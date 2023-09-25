using FantasyWeb.Common.Models;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IPlayersStatsRepository
    {
        Task<IEnumerable<PlayerStats>> GetPlayerStatsAsync(int seasonId, int formGamesCount);

        Task<IEnumerable<PlayerExpectedFantasyPointsStats>> GetPlayerExpectedFantasyPointsAsync(int seasonId,
                                                                                                int formGamesCount,
                                                                                                DateTime lowerBoundDate,
                                                                                                DateTime upperBoundDate);
    }
}
