using FantasyWeb.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("predictions")]
    public class GamePreditionsController : Controller
    {
        private readonly IGamePredictionsService gamePredictionsService;

        public GamePreditionsController(IGamePredictionsService gamePredictionsService)
        {
            this.gamePredictionsService = gamePredictionsService;
        }

        [HttpGet]
        [Route("games/get")]
        public async Task<IActionResult> GetTeamsAsync()
        {
            return Ok(await gamePredictionsService.GetAllGamePredictionsAsync());
        }
    }
}
