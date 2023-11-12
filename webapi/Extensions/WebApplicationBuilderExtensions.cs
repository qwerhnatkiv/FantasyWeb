using FantasyWeb.Services.Abstractions;
using FantasyWeb.Services.Abstractions.Http;
using FantasyWeb.Services.Extensions;
using FantasyWeb.Services.Services;
using FantasyWeb.Services.Services.Http;

namespace webapi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetSection("ConnectionString").Get<string>()!;
            builder.Services.ConfigureDbServices(connectionString);

            builder.Services.AddTransient<IGamePredictionsService, GamePredictionsService>();
            builder.Services.AddTransient<IDictionaryItemsService, DictionaryItemsService>();
            builder.Services.AddTransient<ISportsHttpClient, SportsHttpClient>();

            builder.Services.AddCors(options =>
            {

                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddHostedService<ScriptsExecutionBackgroundService>();

            return builder;
        }
    }
}
