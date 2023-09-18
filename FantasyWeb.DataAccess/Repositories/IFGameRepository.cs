using FantasyWeb.DataAccess.Entities;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IFGameRepository
    {
        Task<IEnumerable<FGame>> GetAllGamePredictionsAsync(int seasonID);
    }
}
