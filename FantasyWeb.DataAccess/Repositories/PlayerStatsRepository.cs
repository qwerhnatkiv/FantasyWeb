using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Utils;
using MethodTimer;
using Npgsql;
using NpgsqlTypes;

namespace FantasyWeb.DataAccess.Repositories
{
    public class PlayerStatsRepository : IPlayersStatsRepository
    {
        private readonly string connectionString;

        public PlayerStatsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<PlayerStats>> GetPlayerStatsAsync(int seasonId, int formGamesCount)
        {
            List<PlayerStats> playerStats = new List<PlayerStats>(1000);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery =
                    @"  

                        WITH
                        RankedPlayerGames AS (
                        SELECT
                            PLAYER.id AS id_player,
                            GAME.id AS id_game,
                            ROW_NUMBER() OVER 
                            (
                                PARTITION BY PLAYER.id 
                                ORDER BY GAME.game_date DESC
                            ) AS game_rank
                        FROM
                            nhl2324.d_players AS PLAYER
                            INNER JOIN nhl2324.d_teams AS TEAM ON PLAYER.id_team = TEAM.id
                            INNER JOIN nhl2324.d_teams_games AS TG ON TG.id_team = TEAM.id
                            INNER JOIN nhl2324.d_games AS GAME ON TG.id_game = GAME.id
                        WHERE GAME.id_season = @idSeason
                        AND GAME.game_date < @dateTime
                        ),
                        PPRankings AS (
                        SELECT
                            id_team,
                            id_player,
                            avg_pp_toi,
                            PP_player_rank,
                            PP_brigade
                        FROM
                            nhl2324.f_pp_brigades (@idSeason, @formGamesCount)
                        )
                    SELECT
                        PLAYER.id AS ""PlayerID"",
                        PLAYER.id_player_sports AS ""PlayerIdSports"",
                        COALESCE(PLAYER.id_team, 0) AS ""TeamID"", 
                        PLAYER.name_sports AS ""PlayerName"", 
                        POSITION.short_name AS ""Position"",
                        SPORTS_PLAYER.actual_price AS ""Price"",
                        COUNT(NST_PLAYER.g) AS ""FormGamesPlayed"",
                        SUM(COALESCE(NST_PLAYER.g, 0)) AS ""FormGoals"",
                        SUM(COALESCE(NST_PLAYER.a, 0)) AS ""FormAssists"",
                        SUM(COALESCE(NST_PLAYER.plus_minus, 0)) AS ""FormPlusMinus"",
                        SUM(COALESCE(NST_PLAYER.shots, 0)) AS ""FormShotsOnGoal"",
                        SUM(COALESCE(NST_PLAYER.pim, 0)) AS ""FormPIM"",
                        SUM(COALESCE(NST_PLAYER.ixG, 0)) AS ""FormIxG"",
                        SUM(COALESCE(NST_PLAYER.icF, 0)) AS ""FormICF"",
                        SUM(COALESCE(NST_PLAYER.ihdcf, 0)) AS ""FormIHDCF"",
                        get_toi_float_from_seconds((SUM(NST_PLAYER.toi) / COUNT(NST_PLAYER.g))::integer) AS ""FormTOI"",
                        get_toi_float_from_seconds(PPRanks.avg_pp_toi::integer) AS ""FormPowerPlayTime"",
                        PPRanks.PP_player_rank AS ""FormPowerPlayTeamPosition"",
                        PPRanks.PP_brigade AS ""FormPowerPlayNumber"",
                        COALESCE(SEASON_PREDS.g, 0) AS ""ForecastGoals"",
                        COALESCE(SEASON_PREDS.a, 0) AS ""ForecastAssists"",
                        COALESCE(SEASON_PREDS.gp, COALESCE(GOALIES_PREDS.gp, 0)) AS ""ForecastGamesPlayed"",
                        COALESCE(SEASON_PREDS.plus_minus, 0) AS ""ForecastPlusMinus"",
                        COALESCE(SEASON_PREDS.pim, 0) AS ""ForecastPIM"",
                        COALESCE(SEASON_PREDS.name_sources, GOALIES_PREDS.name_sources) AS ""ForecastSources"",
                        COALESCE(SEASON_PREDS.wins, COALESCE(GOALIES_PREDS.wins, 0.0)) AS ""ForecastWins"",
                        COALESCE(SEASON_PREDS.l, COALESCE(GOALIES_PREDS.l, 0.0)) AS ""ForecastLosses"",
                        COALESCE(SEASON_PREDS.cs, COALESCE(GOALIES_PREDS.cs, 0.0)) AS ""ForecastShutouts""
                    FROM nhl2324.f_players_sports AS SPORTS_PLAYER
                    INNER JOIN nhl2324.d_players AS PLAYER 
                        ON SPORTS_PLAYER.id_player = PLAYER.id
                    INNER JOIN nhl2324.d_positions AS POSITION
                        ON POSITION.id = PLAYER.id_position
                    LEFT JOIN RankedPlayerGames AS RPG
                        ON RPG.id_player = PLAYER.id
                    LEFT JOIN nhl2324.f_players_nst AS NST_PLAYER
                        ON RPG.id_player = NST_PLAYER.id_player
                        AND RPG.id_game = NST_PLAYER.id_game
                    LEFT JOIN PPRankings AS PPRanks 
                        ON PPRanks.id_player = RPG.id_player
                    LEFT JOIN nhl2324.dm_season_preds_players AS SEASON_PREDS 
                        ON PLAYER.id = SEASON_PREDS.id_player
                        AND SEASON_PREDS.id_season = @idSeason
                    LEFT JOIN nhl2324.v_season_preds_goalkeepers AS GOALIES_PREDS
                        ON PLAYER.id = GOALIES_PREDS.id_player
                        AND GOALIES_PREDS.id_season = @idSeason
                    WHERE (RPG.id_player IS NULL OR RPG.game_rank <= @formGamesCount)
                    AND SPORTS_PLAYER.id_season = @idSeason
                    GROUP BY 
                        PLAYER.id, 
                        PLAYER.id_player_sports,
                        PLAYER.id_team, 
                        PLAYER.name_sports,
                        SPORTS_PLAYER.actual_price,
                        POSITION.short_name,
                        SEASON_PREDS.g,
                        SEASON_PREDS.a,
                        SEASON_PREDS.gp,
                        SEASON_PREDS.plus_minus,
                        SEASON_PREDS.pim,
                        SEASON_PREDS.name_sources,
                        GOALIES_PREDS.gp,
                        GOALIES_PREDS.name_sources,
                        SEASON_PREDS.wins,
                        SEASON_PREDS.l,
                        SEASON_PREDS.cs,
                        GOALIES_PREDS.wins,
                        GOALIES_PREDS.l,
                        GOALIES_PREDS.cs,
                        PPRanks.avg_pp_toi,
                        PPRanks.PP_player_rank,
                        PPRanks.PP_brigade";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                command.Parameters.Add("@idSeason", NpgsqlDbType.Integer).Value = seasonId;
                command.Parameters.Add("@formGamesCount", NpgsqlDbType.Integer).Value = formGamesCount;
                command.Parameters.Add("@dateTime", NpgsqlDbType.Timestamp).Value = DateTime.Today;

                using (NpgsqlDataReader rdr = await command.ExecuteReaderAsync())
                {
                    while (rdr.HasRows)
                    {
                        while (await rdr.ReadAsync())
                        {
                            var player = rdr.ConvertToObject<PlayerStats>();
                            playerStats.Add(player);
                        }

                        await rdr.NextResultAsync();
                    }
                }
            }

            return playerStats;
        }

        public async Task<IEnumerable<PlayerExpectedFantasyPointsStats>> GetPlayerExpectedFantasyPointsAsync( 
                                                                                        int seasonId, 
                                                                                        int formGamesCount,
                                                                                        DateTime lowerBoundDate,
                                                                                        DateTime upperBoundDate)
        {
            List<PlayerExpectedFantasyPointsStats> playerStats = new List<PlayerExpectedFantasyPointsStats>(20);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery =
                    @"  
                        SELECT 
                            OfoCalculations.id_game AS ""GameID"",
                            OfoCalculations.id_player AS ""PlayerID"",
                            OfoCalculations.player_game_ofo AS ""PlayerExpectedFantasyPoints"",
                            PLAYER.id_team AS ""TeamID"",
                            TEAM.name_team AS ""TeamName""
                        FROM nhl2324.get_complete_ofo_calculations(
                            nhl2324.get_maximum_ofo_games_array(@lowerBoundDate, @upperBoundDate), 
                            @formGamesCount, 
                            @idSeason,
                            @lowerBoundDate
                        ) AS OfoCalculations
                        INNER JOIN nhl2324.d_games AS GAME ON GAME.id = OfoCalculations.id_game
                        INNER JOIN nhl2324.d_players AS PLAYER ON PLAYER.id = OfoCalculations.id_player
                        INNER JOIN nhl2324.d_teams AS TEAM ON PLAYER.id_team = TEAM.id
                        WHERE GAME.game_date >= @lowerBoundDate AND GAME.game_date <= @upperBoundDate";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                command.Parameters.Add("@idSeason", NpgsqlDbType.Integer).Value = seasonId;
                command.Parameters.Add("@formGamesCount", NpgsqlDbType.Integer).Value = formGamesCount;
                command.Parameters.Add("@lowerBoundDate", NpgsqlDbType.Timestamp).Value = lowerBoundDate;
                command.Parameters.Add("@upperBoundDate", NpgsqlDbType.Timestamp).Value = upperBoundDate;

                using (NpgsqlDataReader rdr = await command.ExecuteReaderAsync())
                {
                    while (rdr.HasRows)
                    {
                        while (await rdr.ReadAsync())
                        {
                            var player = rdr.ConvertToObject<PlayerExpectedFantasyPointsStats>();
                            playerStats.Add(player);
                        }

                        await rdr.NextResultAsync();
                    }
                }
            }

            return playerStats;
        }
    }
}
