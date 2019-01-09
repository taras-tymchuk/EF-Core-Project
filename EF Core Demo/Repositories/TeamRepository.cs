﻿using EF_Core_Demo.Context;
using EF_Core_Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF_Core_Demo.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Team> GetListOfPlayers( string teamName )
        {
            return ( (FootballContext) Context ).Teams
                .Where( t => t.Name == teamName )
                .Include(t => t.Players)
                .ToList();
        }

        public IEnumerable<Team> GetTopRichestTeams( int count )
        {
            return ( (FootballContext) Context ).Teams
                .OrderByDescending( t => t.Budget )
                .Take( count );
        }

        public void RemoveByTeamName( string teamName )
        {
            ( (FootballContext) Context ).Teams
                .RemoveRange( 
                    ( (FootballContext) Context ).Teams
                        .Where( t => t.Name == teamName )
                        .ToList() );
        }
    }
}
