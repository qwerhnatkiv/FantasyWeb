using FantasyWeb.DataAccess.Repositories;
using FantasyWeb.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FantasyWeb.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDbServices(this IServiceCollection services, string connectionString)
        {
            return services.AddScoped<DbContext, DataContext>()
                           .AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString))
                           .AddScoped<IFGameRepository, FGameRepository>(x => new FGameRepository(connectionString))
                           .AddScoped<IFNstRepository, FNstRepository>(x => new FNstRepository(connectionString))
                           .AddScoped<IPlayersStatsRepository, PlayerStatsRepository>(x => new PlayerStatsRepository(connectionString))
                           .AddScoped<IFUpdateLogRepository, FUpdateLogRepository>(x => new FUpdateLogRepository(connectionString));
        }
    }
}
