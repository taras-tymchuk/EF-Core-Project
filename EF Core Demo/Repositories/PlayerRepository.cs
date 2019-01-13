using EF_Core_Demo.Context;
using EF_Core_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF_Core_Demo.Repositories
{
    public class PlayerRepository 
        : Repository<Player, FootballContext>, IPlayerRepository
    {
        public PlayerRepository(FootballContext context)
            : base(context)
        {
        }

        public IEnumerable<Player> GetPlayersFromBarcelonaTeam()
        {
            return Context.Players
                .Include( p => p.Team )
                .Where( t => t.Team.Name == "Barcelona" )
                .ToList();
        }

        public IEnumerable<Player> GetUkrainianPlayers()
        {
            return Context.Players
                .Where( p => p.Nationality == "Ukrainian" );
        }
    }
}
