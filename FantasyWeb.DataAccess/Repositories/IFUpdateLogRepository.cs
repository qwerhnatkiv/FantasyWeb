using FantasyWeb.Common.Models;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IFUpdateLogRepository
    {
        Task<UpdateLogInformation> GetLatestUpdateDatesAsync();
    }
}