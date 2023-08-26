using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Repositories;
using FantasyWeb.Services.Abstractions;
using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Services
{
    public class GamePredictionsService : IGamePredictionsService
    {
        private readonly IRepository<FGameOdd> repository;

        public GamePredictionsService(IRepository<FGameOdd> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GamePredictionDTO>> GetAllGamePredictionsAsync()
        {
            return (await repository.SelectAllAsync(x => true, 
                                                    x => x.DGame, 
                                                    x=> x.DGame.HomeTeam, 
                                                    x => x.DGame.AwayTeam)).Select(x => new GamePredictionDTO()
            {
                HomeTeamAcronym = x.DGame.HomeTeam.AcronymTeamWolski,
                HomeTeamName = x.DGame.HomeTeam.NameTeam,
                HomeTeamWinChance = x.HomeWinChance.HasValue ? x.HomeWinChance.Value : 0,
                AwayTeamAcronym = x.DGame.AwayTeam.AcronymTeamWolski,
                AwayTeamName = x.DGame.AwayTeam.NameTeam,
                AwayTeamWinChance = x.AwayWinChance.HasValue ? x.AwayWinChance.Value : 0,
                DrawChance = x.DrawChance.HasValue ? x.DrawChance.Value : 0,
                GameDate = x.DGame.GameDate,
                WeekNumber = x.DGame.WeekNumber.HasValue ? x.DGame.WeekNumber.Value : 0,
            });
        }
    }
}
