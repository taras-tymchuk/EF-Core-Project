using EF_Core_Demo.Models;
using System.Collections.Generic;

namespace EF_Core_Demo.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTopRichestTeams( int count );
        IEnumerable<Team> GetListOfPlayers( string teamName );
        void RemoveByTeamName( string teamName );
    }
}
