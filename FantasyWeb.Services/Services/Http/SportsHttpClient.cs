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
                Balance = 20000,
                Substitutions = 5,
                Players = new List<SportsSquadPlayerDTO>
                {
                    new SportsSquadPlayerDTO () { Id = 1908477 },
                    new SportsSquadPlayerDTO () { Id = 1843111 },

                    new SportsSquadPlayerDTO () { Id = 1976577 },
                    new SportsSquadPlayerDTO () { Id = 1976603 },
                    new SportsSquadPlayerDTO () { Id = 1952455 },
                    new SportsSquadPlayerDTO () { Id = 26417 },
                    new SportsSquadPlayerDTO () { Id = 1991649 },
                    new SportsSquadPlayerDTO () { Id = 37792 },

                    new SportsSquadPlayerDTO () { Id = 1843078 },
                    new SportsSquadPlayerDTO () { Id = 1836995 },
                    new SportsSquadPlayerDTO () { Id = 1755742 },
                    new SportsSquadPlayerDTO () { Id = 1884104 },
                    new SportsSquadPlayerDTO () { Id = 1843151 },
                    new SportsSquadPlayerDTO () { Id = 26043 },
                    new SportsSquadPlayerDTO () { Id = 1934871 },
                    new SportsSquadPlayerDTO () { Id = 1753254 },
                    new SportsSquadPlayerDTO () { Id = 1908928 },
                }
            };
        }
    }
}
