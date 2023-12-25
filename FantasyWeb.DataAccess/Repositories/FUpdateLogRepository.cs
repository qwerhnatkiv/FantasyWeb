using FantasyWeb.Common.Models;
using FantasyWeb.DataAccess.Utils;
using Npgsql;
using NpgsqlTypes;
using System;
namespace FantasyWeb.DataAccess.Repositories
{
    public class FUpdateLogRepository : IFUpdateLogRepository
    {

        private readonly string connectionString;

        public FUpdateLogRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<UpdateLogInformation> GetLatestUpdateDatesAsync()
        {

            UpdateLogInformation result = new UpdateLogInformation();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlQuery =
                    @"  
                        SELECT
                            (
                                SELECT timestamp
                                FROM nhl2324.f_update_log
                                WHERE log_type = 2
                                ORDER BY timestamp desc
                                LIMIT 1
                            ) AS ""BookmakersUpdateDate"",
                            (
                                SELECT timestamp
                                FROM nhl2324.f_update_log
                                WHERE log_type = 1
                                ORDER BY timestamp desc
                                LIMIT 1
                            ) AS ""GeneralUpdateDate""
                    
                ";

                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection);

                using (NpgsqlDataReader rdr = await command.ExecuteReaderAsync())
                {
                    while (rdr.HasRows)
                    {
                        while (await rdr.ReadAsync())
                        {
                            result = rdr.ConvertToObject<UpdateLogInformation>();
                        }

                        await rdr.NextResultAsync();
                    }
                }
            }

            return result;
        }
    }
}
