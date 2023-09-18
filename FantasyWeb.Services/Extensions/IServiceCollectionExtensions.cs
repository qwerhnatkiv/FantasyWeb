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
                           .AddScoped<IFGameRepository, FGameRepository>()
                           .AddScoped< IFNstRepository, FNstRepository>();
        }
    }
}
