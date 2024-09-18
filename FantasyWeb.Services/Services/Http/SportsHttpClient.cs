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
                    new SportsSquadPlayerDTO () { Id = 1087 },
                    new SportsSquadPlayerDTO () { Id = 283 },

                    new SportsSquadPlayerDTO () { Id = 586 },
                    new SportsSquadPlayerDTO () { Id = 1118 },
                    new SportsSquadPlayerDTO () { Id = 1035 },
                    new SportsSquadPlayerDTO () { Id = 391 },
                    new SportsSquadPlayerDTO () { Id = 140 },
                    new SportsSquadPlayerDTO () { Id = 1165 },

                    new SportsSquadPlayerDTO () { Id = 592 },
                    new SportsSquadPlayerDTO () { Id = 600 },
                    new SportsSquadPlayerDTO () { Id = 502 },
                    new SportsSquadPlayerDTO () { Id = 673 },
                    new SportsSquadPlayerDTO () { Id = 735 },
                    new SportsSquadPlayerDTO () { Id = 1183 },
                    new SportsSquadPlayerDTO () { Id = 719 },
                    new SportsSquadPlayerDTO () { Id = 606 },
                    new SportsSquadPlayerDTO () { Id = 734 },
                }
            };
        }
    }
}
