using FantasyWeb.Common;
using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Repositories;
using FantasyWeb.Services.Abstractions;
using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Services
{
    public class GamePredictionsService : IGamePredictionsService
    {
        private readonly IFGameRepository fGameRepository;
        private readonly IFNstRepository fNstRepository;
        private readonly IPlayersStatsRepository playersStatsRepository;

        public GamePredictionsService(IFGameRepository fGameRepository, IFNstRepository fNstRepository, IPlayersStatsRepository playersStatsRepository)
        {
            this.fGameRepository = fGameRepository;
            this.fNstRepository = fNstRepository;
            this.playersStatsRepository = playersStatsRepository;
        }

        public async Task<GamesDTO> GetAllGamePredictionsAsync(int seasonID = Constants.Database.CurrentSeasonID, 
                                                                                     int formGamesCount = Constants.Database.FormGamesCount)
        {
            IEnumerable<PlayerStats> playerStats = await this.playersStatsRepository.GetPlayerStatsAsync(seasonID, formGamesCount);

            IEnumerable<TeamStats> teamsStats = await fNstRepository.GetLastTeamResultsAsync(seasonID, formGamesCount);

            IEnumerable<GamePrediction> gamePredictionDTOs = (await fGameRepository.GetAllGamePredictionsAsync(seasonID));

            return new GamesDTO
            {
                GamePredictions = gamePredictionDTOs,
                TeamsStats = teamsStats,
                PlayerStats = playerStats
            };
        }
    }
}
