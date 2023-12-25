using FantasyWeb.Common.Models;

namespace FantasyWeb.Services.DTOs
{
    public class GamesDTO
    {
        public IEnumerable<GamePrediction> GamePredictions { get; set; } = new List<GamePrediction>();

        public IEnumerable<TeamStats> TeamsStats { get; set; } = new List<TeamStats>();

        public IEnumerable<PlayerStats> PlayerStats { get; set; } = new List<PlayerStats>();

        public UpdateLogInformation UpdateLogInformation { get; set; }
    }
}
