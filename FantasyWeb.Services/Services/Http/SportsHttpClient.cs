using FantasyWeb.Services.Abstractions.Http;
using FantasyWeb.Services.DTOs;
using Flurl.Http;
using HtmlAgilityPack;

namespace FantasyWeb.Services.Services.Http
{
    public class SportsHttpClient : ISportsHttpClient
    {
        public async Task<SportsSquadDTO> GetPlayersByAccountId(string accountId)
        {

            //// Get Balance
            //HtmlWeb web = new HtmlWeb();
            //HtmlNode? balanceLabelNode = sportsRuSquadPage.DocumentNode.SelectSingleNode("//*[text() = 'Balance']");
            //HtmlNode? balanceValueNode = balanceLabelNode.ParentNode.SelectSingleNode("td");
            //sportsSquadDTO.Balance = int.Parse(balanceValueNode.InnerText);

            //HtmlNode? substitutionsLabelNode = sportsRuSquadPage.DocumentNode.SelectSingleNode("//th[text() = 'Transfers']");
            //HtmlNode? substitutionsValueNode = substitutionsLabelNode.ParentNode.SelectSingleNode("td");
            //sportsSquadDTO.Substitutions = int.Parse(substitutionsValueNode.InnerText);

            return new SportsSquadDTO ();
        }
    }
}
