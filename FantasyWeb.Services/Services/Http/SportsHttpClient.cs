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
            //SportsSquadDTO sportsSquadDTO = await $"https://www.sports.ru/fantasy/hockey/team/json/{accountId}.json"
            //    .GetJsonAsync<SportsSquadDTO>();

            //// Get Balance
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument? sportsRuSquadPage = web.Load($"https://www.sports.ru/fantasy/hockey/team/{accountId}.html");
            //HtmlNode? balanceLabelNode = sportsRuSquadPage.DocumentNode.SelectSingleNode("//*[text() = 'Баланс']");
            //HtmlNode? balanceValueNode = balanceLabelNode.ParentNode.SelectSingleNode("td");
            //sportsSquadDTO.Balance = int.Parse(balanceValueNode.InnerText);

            //HtmlNode? substitutionsLabelNode = sportsRuSquadPage.DocumentNode.SelectSingleNode("//th[text() = 'Трансферы']");
            //HtmlNode? substitutionsValueNode = substitutionsLabelNode.ParentNode.SelectSingleNode("td");
            //sportsSquadDTO.Substitutions = int.Parse(substitutionsValueNode.InnerText);

            //return sportsSquadDTO;

            return new SportsSquadDTO()
            {
                Balance = 0,
                Substitutions = 5,
                Players = new List<SportsSquadPlayerDTO>
                {
                    new SportsSquadPlayerDTO () { Id = 34848 },
                    new SportsSquadPlayerDTO () { Id = 1797942 },

                    new SportsSquadPlayerDTO () { Id = 37590 },
                    new SportsSquadPlayerDTO () { Id = 1902107 },
                    new SportsSquadPlayerDTO () { Id = 1836910 },
                    new SportsSquadPlayerDTO () { Id = 1908964 },
                    new SportsSquadPlayerDTO () { Id = 2004578 },
                    new SportsSquadPlayerDTO () { Id = 1947355 },

                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1842365 },
                    new SportsSquadPlayerDTO () { Id = 2124462 },
                    new SportsSquadPlayerDTO () { Id = 2055945 },
                    new SportsSquadPlayerDTO () { Id = 1922861 },
                    new SportsSquadPlayerDTO () { Id = 37625 },
                    new SportsSquadPlayerDTO () { Id = 1928651 },
                    new SportsSquadPlayerDTO () { Id = 1884165 },
                }
            };
        }
    }
}
