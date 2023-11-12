using FantasyWeb.Common;
using FantasyWeb.Common.Models;
using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Abstractions
{
    public interface IGamePredictionsService
    {
        Task<GamesDTO> GetAllGamePredictionsAsync(int seasonID, int formGamesCount);

        Task<Dictionary<long, List<PlayerExpectedFantasyPointsStats>>> GetPlayerExpectedFantasyPointsAsync(
                                                               DateTime lowerBoundDate,
                                                               DateTime upperBoundDate,
                                                               int seasonID, 
                                                               int formGamesCount);
    }
}
