using FantasyWeb.Services.Abstractions.Http;
using FantasyWeb.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("sportsSquad")]
    public class SportsSquadController
    {
        private readonly ISportsHttpClient sportsHttpClient;

        public SportsSquadController(ISportsHttpClient sportsHttpClient)
        {
            this.sportsHttpClient = sportsHttpClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<SportsSquadDTO> GetSportsSquad([FromQuery] string accountId)
        {
            return await sportsHttpClient.GetPlayersByAccountId(accountId);
        } 
    }
}
