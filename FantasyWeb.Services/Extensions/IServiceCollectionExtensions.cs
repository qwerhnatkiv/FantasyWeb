using FantasyWeb.DataAccess.Repositories;
using FantasyWeb.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FantasyWeb.Services.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDbServices(this IServiceCollection services, string connectionString)
        {
            return services.AddScoped<DbContext, DataContext>()
                           .AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString))
                           .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
