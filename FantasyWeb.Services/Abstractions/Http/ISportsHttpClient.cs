using FantasyWeb.Services.DTOs;

namespace FantasyWeb.Services.Abstractions.Http
{
    public interface ISportsHttpClient
    {
        Task<SportsSquadDTO> GetPlayersByAccountId(string accountId);
    }
}