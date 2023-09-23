using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IFGameRepository
    {
        Task<IEnumerable<GamePrediction>> GetAllGamePredictionsAsync(int seasonID);
    }
}
