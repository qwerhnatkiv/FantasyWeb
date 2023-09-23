using FantasyWeb.DataAccess.Entities;
using FastMember;
using Npgsql;
using System.Text;

namespace FantasyWeb.DataAccess.Utils
{
    public static class Helpers
    {
        public static string ConvertResultsToString(this IEnumerable<FTeamNST> teamsStats)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = teamsStats.Count() - 1; i >= 0; i--)
            {
                if (teamsStats.ElementAt(i).OTL > 0)
                {
                    sb.Append('O');
                    continue;
                }

                if (teamsStats.ElementAt(i).W > 0)
                {
                    sb.Append('W');
                    continue;
                }

                if (teamsStats.ElementAt(i).L > 0)
                {
                    sb.Append('L');
                    continue;
                }
            }

            return sb.ToString();
        }

        public static T ConvertToObject<T>(this NpgsqlDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);
                    try {
                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return t;
        }
    }
}
