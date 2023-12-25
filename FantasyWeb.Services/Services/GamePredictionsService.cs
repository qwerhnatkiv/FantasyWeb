using FantasyWeb.Common;
using FantasyWeb.Common.Models;
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
        private readonly IFUpdateLogRepository fUpdateLogRepository;

        public GamePredictionsService(IFGameRepository fGameRepository, IFNstRepository fNstRepository, IPlayersStatsRepository playersStatsRepository, IFUpdateLogRepository fUpdateLogRepository)
        {
            this.fGameRepository = fGameRepository;
            this.fNstRepository = fNstRepository;
            this.playersStatsRepository = playersStatsRepository;
            this.fUpdateLogRepository = fUpdateLogRepository;
        }

        public async Task<GamesDTO> GetAllGamePredictionsAsync(int seasonID, int formGamesCount)
        {
            IEnumerable<PlayerStats> playerStats = await this.playersStatsRepository.GetPlayerStatsAsync(seasonID, formGamesCount);

            IEnumerable<TeamStats> teamsStats = await fNstRepository.GetLastTeamResultsAsync(seasonID, formGamesCount);
            foreach(var team in teamsStats)
            {
                int gamesCount = formGamesCount > team.TeamForm.Length && team.TeamForm.Length != 0 ? team.TeamForm.Length : formGamesCount;
                team.TeamFormWinPercentage = (team.TeamForm.Count(f => f == 'W') * 200 + team.TeamForm.Count(f => f == 'O') * 100) / (gamesCount * 2);
            }

            IEnumerable<GamePrediction> gamePredictionDTOs = await fGameRepository.GetAllGamePredictionsAsync(seasonID);
            UpdateLogInformation updateLogInformation = await fUpdateLogRepository.GetLatestUpdateDatesAsync();

            return new GamesDTO
            {
                GamePredictions = gamePredictionDTOs,
                TeamsStats = teamsStats,
                PlayerStats = playerStats,
                UpdateLogInformation = updateLogInformation
            };
        }

        public async Task<Dictionary<long, List<PlayerExpectedFantasyPointsStats>>> GetPlayerExpectedFantasyPointsAsync(
                                                               DateTime lowerBoundDate,
                                                               DateTime upperBoundDate,
                                                               int seasonID, 
                                                               int formGamesCount)
        {
            IEnumerable<PlayerExpectedFantasyPointsStats> playerStats = 
                await playersStatsRepository.GetPlayerExpectedFantasyPointsAsync(seasonID, formGamesCount, lowerBoundDate, upperBoundDate);


            return playerStats.GroupBy(k => k.PlayerID, v => v).ToDictionary(x => x.Key, y => y.ToList());
        }
    }
}
