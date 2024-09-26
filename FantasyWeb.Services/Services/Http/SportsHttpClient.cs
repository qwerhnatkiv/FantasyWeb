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
                    new SportsSquadPlayerDTO () { Id = 34848 },

                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },

                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1907827 },
                    new SportsSquadPlayerDTO () { Id = 1884165 },
                    new SportsSquadPlayerDTO () { Id = 1884165 },
                }
            };
        }
    }
}
