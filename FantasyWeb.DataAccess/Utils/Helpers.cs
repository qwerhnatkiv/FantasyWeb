using FantasyWeb.DataAccess.Entities;
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
    }
}
