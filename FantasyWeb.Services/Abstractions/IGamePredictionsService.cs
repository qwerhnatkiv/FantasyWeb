using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Abstractions
{
    public interface IGamePredictionsService
    {
        Task<IEnumerable<GamePredictionDTO>> GetAllGamePredictionsAsync();
    }
}
