using FantasyWeb.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("dictionary")]
    public class DictionaryItemsController : Controller
    {
        private readonly IDictionaryItemsService _dictionaryItemsService;

        public DictionaryItemsController(IDictionaryItemsService dictionaryItemsService)
        {
            _dictionaryItemsService = dictionaryItemsService;
        }

        [HttpGet]
        [Route("get_teams")]
        public async Task<IActionResult> GetTeamsAsync()
        {
            return Ok(await _dictionaryItemsService.GetAllTeamsAsync());
        }
    }
}
