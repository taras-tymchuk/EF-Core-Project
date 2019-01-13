using EF_Core_Demo.Models;
using System.Collections.Generic;

namespace EF_Core_Demo.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetUkrainianPlayers();
        IEnumerable<Player> GetPlayersFromBarcelonaTeam();
        IEnumerable<Player> GetPlayerByFullName( 
            string firstName, string lastName);
    }
}
