﻿using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Extensions;
using FantasyWeb.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Linq;

namespace FantasyWeb.DataAccess.Repositories
{
    public class FNstRepository : IFNstRepository
    {
        private readonly string connectionString;

        public FNstRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<TeamStats>> GetLastTeamResultsAsync(int seasonID, int formGamesCount)
        {

            List<TeamStats> result = new List<TeamStats>(32);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery =
                    @"  
                        WITH RankedTeamGames AS 
                        (
                          SELECT
                            f.id_team,
                            f.id_game,
                            f.w,
                            f.otl,
                            f.l,
                            f.gf, 
                            f.ga,
                            ROW_NUMBER() OVER (PARTITION BY t.id ORDER BY dg.game_date DESC) AS game_rank
                          FROM nhl2324.d_teams AS t
                          JOIN nhl2324.f_teams_nst AS f ON t.id = f.id_team
                          JOIN nhl2324.d_games AS dg ON f.id_game = dg.id
                          WHERE dg.game_date < @dateTime
                          ORDER BY dg.game_date ASC
                        )
                        SELECT 
                            TEAM.id AS ""TeamID"", 
                            TEAM.acronym_team_wolski AS ""TeamAcronym"",
                            AVG(COALESCE(NST_TEAM_RECORD.gf, 0.0)) AS ""TeamGoalsForm"",
                            AVG(COALESCE(NST_TEAM_RECORD.ga, 0.0)) AS ""TeamGoalsAwayForm"",
                            CONVERT_RESULTS_TO_STR(
                                COALESCE(NST_TEAM_RECORD.w, 0.0), 
                                COALESCE(NST_TEAM_RECORD.l, 0.0), 
                                COALESCE(NST_TEAM_RECORD.otl, 0.0)
                            ) AS ""TeamForm""
                        FROM 
                            nhl2324.d_games AS GAME
                        INNER JOIN RankedTeamGames AS NST_TEAM_RECORD ON NST_TEAM_RECORD.id_game = GAME.id
                        INNER JOIN nhl2324.d_teams AS TEAM ON NST_TEAM_RECORD.id_team = TEAM.id
                        WHERE nst_team_record.game_rank <= @formGamesCount
                        GROUP BY TEAM.id, TEAM.acronym_team_wolski;";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                command.Parameters.Add("@idSeason", NpgsqlDbType.Integer).Value = seasonID;
                command.Parameters.Add("@formGamesCount", NpgsqlDbType.Integer).Value = formGamesCount;
                command.Parameters.Add("@dateTime", NpgsqlDbType.Timestamp).Value = DateTime.Now;

                using (NpgsqlDataReader rdr = await command.ExecuteReaderAsync())
                {
                    while (rdr.HasRows)
                    {
                        while (await rdr.ReadAsync())
                        {
                            var row = rdr.ConvertToObject<TeamStats>();
                            result.Add(row);
                        }

                        await rdr.NextResultAsync();
                    }
                }
            }

            return result;
        }
    }
}