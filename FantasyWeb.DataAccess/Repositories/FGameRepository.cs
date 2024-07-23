using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Utils;
using MethodTimer;
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

        [Time]
        public async Task<IEnumerable<GamePrediction>> GetAllGamePredictionsAsync(int seasonID)
        {
            var sqlQuery = @"   SELECT  
                                        COALESCE(f.away_win_bookmakers, f.away_win) AS      ""AwayTeamWinChance"",
                                        COALESCE(f.draw_bookmakers, f.draw) AS              ""DrawChance"",
                                        COALESCE(f.home_win_bookmakers, f.home_win) AS      ""HomeTeamWinChance"",
                                        CASE WHEN f.home_win_bookmakers IS NOT NULL
                                            THEN TRUE
                                            ELSE FALSE
                                        END AS                                              ""IsFromBookmakers"",
                                        d.id_away_team AS                                   ""AwayTeamId"",
                                        d.game_date AS                                      ""GameDate"",
                                        d.id_home_team AS                                   ""HomeTeamId"",
                                        d.week_num AS                                       ""WeekNumber"",
                                        d0.acronym_team_wolski AS                           ""HomeTeamAcronym"",
                                        d0.name_team AS                                     ""HomeTeamName"",
                                        d1.acronym_team_wolski AS                           ""AwayTeamAcronym"",
                                        d1.name_team AS                                     ""AwayTeamName"",
                                        d.id AS                                             ""GameId"",
                                        d.gf_home_ot AS                                     ""HomeTeamGoals"",
                                        d.gf_away_ot AS                                     ""AwayTeamGoals"",
                                        CASE 
                                              WHEN d.game_date >= @dateTime  THEN False
                                              ELSE True
                                        END AS ""IsOldGame""
                                FROM nhl2324.f_games AS f
                                INNER JOIN nhl2324.d_games AS d ON f.id_game = d.id
                                INNER JOIN nhl2324.d_teams AS d0 ON d.id_home_team = d0.id
                                INNER JOIN nhl2324.d_teams AS d1 ON d.id_away_team = d1.id
                                WHERE d.id_season = @idSeason";

            List<GamePrediction> result = new List<GamePrediction>(1000);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                command.Parameters.Add("@idSeason", NpgsqlDbType.Integer).Value = seasonID;
                command.Parameters.Add("@dateTime", NpgsqlDbType.Timestamp).Value = DateTime.Today;

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
