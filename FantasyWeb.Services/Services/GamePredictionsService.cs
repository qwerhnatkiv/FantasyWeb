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

        public GamePredictionsService(IFGameRepository fGameRepository, IFNstRepository fNstRepository)
        {
            this.fGameRepository = fGameRepository;
            this.fNstRepository = fNstRepository;
        }

        public async Task<GamesDTO> GetAllGamePredictionsAsync(int seasonID = Constants.Database.CurrentSeasonID, 
                                                                                     int formGamesCount = Constants.Database.FormGamesCount)
        {
            IEnumerable<TeamStats> teamsStats = await fNstRepository.GetLastTeamResultsAsync(seasonID, formGamesCount);

            IEnumerable<GamePredictionDTO> gamePredictionDTOs = (await fGameRepository.GetAllGamePredictionsAsync(seasonID))
                .Select(x => new GamePredictionDTO()
            {
                HomeTeamAcronym = x.DGame.HomeTeam.AcronymTeamWolski!,
                HomeTeamName = x.DGame.HomeTeam.NameTeam!,
                HomeTeamWinChance = x.HomeWinChance.HasValue ? x.HomeWinChance.Value : 0,
                AwayTeamAcronym = x.DGame.AwayTeam.AcronymTeamWolski!,
                AwayTeamName = x.DGame.AwayTeam.NameTeam!,
                AwayTeamWinChance = x.AwayWinChance.HasValue ? x.AwayWinChance.Value : 0,
                DrawChance = x.DrawChance.HasValue ? x.DrawChance.Value : 0,
                GameDate = x.DGame.GameDate,
                WeekNumber = x.DGame.WeekNumber.HasValue ? x.DGame.WeekNumber.Value : 0,
                HomeTeamId = x.DGame.HomeTeamId,
                AwayTeamId = x.DGame.AwayTeamId
            });

            return new GamesDTO
            {
                GamePredictions = gamePredictionDTOs,
                TeamsStats = teamsStats
            };
        }
    }
}
