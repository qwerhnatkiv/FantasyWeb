using FantasyWeb.Common.Models;

namespace FantasyWeb.Services.DTOs
{
    public class GamesDTO
    {
        public IEnumerable<GamePredictionDTO> GamePredictions { get; set; } = new List<GamePredictionDTO>();

        public IEnumerable<TeamStats> TeamsStats { get; set; } = new List<TeamStats>();
    }
}
