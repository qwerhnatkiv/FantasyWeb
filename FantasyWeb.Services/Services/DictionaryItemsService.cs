using FantasyWeb.DataAccess.Entities;
using FantasyWeb.DataAccess.Repositories;
using FantasyWeb.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyWeb.Services.Services
{
    public class DictionaryItemsService: IDictionaryItemsService
    {
        //private readonly IRepository<DTeam> dTeamRepository;

        public DictionaryItemsService()//IRepository<DTeam> dTeamRepository) 
        {
            //this.dTeamRepository = dTeamRepository;
        }

        public async Task<IEnumerable<DTeam>> GetAllTeamsAsync() 
        {
            return new List<DTeam>() { };// await dTeamRepository.SelectAllAsync();
        }
    }
}
