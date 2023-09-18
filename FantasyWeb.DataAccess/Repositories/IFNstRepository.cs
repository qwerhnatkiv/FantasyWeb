using FantasyWeb.Common.Models;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IFNstRepository
    {
        Task<IEnumerable<TeamStats>> GetLastTeamResultsAsync(int seasonID, int formGamesCount);
    }
}