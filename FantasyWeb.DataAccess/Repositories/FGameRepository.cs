using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Utils;
using Npgsql;
using NpgsqlTypes;

namespace FantasyWeb.DataAccess.Repositories
{
    public class FGameRepository: IFGameRepository
    {
        private readonly string connectionString;

        public FGameRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<GamePrediction>> GetAllGamePredictionsAsync(int seasonID)
        {
            var sqlQuery = @"   SELECT  
                                        f.away_win AS               ""AwayTeamWinChance"",
                                        f.draw AS                   ""DrawChance"",
                                        f.home_win AS               ""HomeTeamWinChance"",
                                        d.id_away_team AS           ""AwayTeamId"",
                                        d.game_date AS              ""GameDate"",
                                        d.id_home_team AS           ""HomeTeamId"",
                                        d.week_num AS               ""WeekNumber"",
                                        d0.acronym_team_wolski AS   ""HomeTeamAcronym"",
                                        d0.name_team AS             ""HomeTeamName"",
                                        d1.acronym_team_wolski AS   ""AwayTeamAcronym"",
                                        d1.name_team AS             ""AwayTeamName"",
                                        d.id AS                     ""GameId""
                                FROM nhl2324.f_games AS f
                                INNER JOIN nhl2324.d_games AS d ON f.id_game = d.id
                                INNER JOIN nhl2324.d_teams AS d0 ON d.id_home_team = d0.id
                                INNER JOIN nhl2324.d_teams AS d1 ON d.id_away_team = d1.id
                                WHERE d.id_season = @idSeason AND d.game_date >= @dateTime";

            List<GamePrediction> result = new List<GamePrediction>(1000);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                command.Parameters.Add("@idSeason", NpgsqlDbType.Integer).Value = seasonID;
                command.Parameters.Add("@dateTime", NpgsqlDbType.Timestamp).Value = DateTime.Now;

                using (NpgsqlDataReader rdr = await command.ExecuteReaderAsync())
                {
                    while (rdr.HasRows)
                    {
                        while (await rdr.ReadAsync())
                        {
                            var player = rdr.ConvertToObject<GamePrediction>();
                            result.Add(player);
                        }

                        await rdr.NextResultAsync();
                    }
                }
            }

            return result;
        }
    }
}
