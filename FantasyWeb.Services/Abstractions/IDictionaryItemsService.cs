using FantasyWeb.DataAccess.Entities;

namespace FantasyWeb.Services.Abstractions
{
    public interface IDictionaryItemsService
    {
        Task<IEnumerable<DTeam>> GetAllTeamsAsync();
    }
}
