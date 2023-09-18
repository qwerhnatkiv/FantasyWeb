using FantasyWeb.Common;
using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Abstractions
{
    public interface IGamePredictionsService
    {
        Task<GamesDTO> GetAllGamePredictionsAsync(int seasonID = Constants.Database.CurrentSeasonID,
                                                                        int formGamesCount = Constants.Database.FormGamesCount);
    }
}
