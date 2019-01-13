using EF_Core_Demo.Unit_Of_Work;
using System.Collections.Generic;
using EF_Core_Demo.Models;
using System.Linq;

namespace EF_Core_Demo.BLL
{
    public class Controller
    {
        private UnitOfWork _model;

        public Controller(UnitOfWork model)
        {
            _model = model;
        }

        public void TransferPlayer(
            string firstName, string lastName, string newClubName )
        {
            var players = _model.Players.GetPlayerByFullName( firstName, lastName )
                .ToList();

            if ( players.Count == 0 )
            {
                System.Console.WriteLine("Sorry, there is no player with such name.");
            }
            else if ( players.Count > 1 )
            {
                System.Console.WriteLine("We have clones. Sorry we cannot move all of them.");
            }
            else
            {
                OrganizeTransfer(players[0], newClubName);
            }
        }

        private void OrganizeTransfer( Player player, string newClubName )
        {
            List<Team> teams = _model.Teams.GetTeamByName( newClubName )
                    .ToList();

            if ( teams.Count == 0 )
            {
                System.Console.WriteLine( "There no such team." );
            }
            else
            {
                UpdateTeam( player, teams[0] );
            }
        }

        private void UpdateTeam( Player player, Team newTeam )
        {
            Player updatedPlayer = new Player()
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                Nationality = player.Nationality
            };

            updatedPlayer.Team = newTeam;

            _model.Players.Remove( player );
            _model.Players.Add( updatedPlayer );
            _model.Save();
        }
    }
}
