using EF_Core_Demo.Unit_Of_Work;
using System.Collections.Generic;
using EF_Core_Demo.Models;
using System.Linq;

namespace EF_Core_Demo.BLL
{
    public class TransferController
    {
        private UnitOfWork _model;
        private TransferResult _transferResult;

        public TransferController(UnitOfWork model)
        {
            _model = model;
        }

        public TransferResult TransferPlayer(
            string firstName, string lastName, string newClubName )
        {
            _transferResult = new TransferResult();

            var players = _model.Players.GetPlayerByFullName( firstName, lastName )
                .ToList();

            if ( players.Count == 0 )
            {
                _transferResult.errorCode = ErrorCodeEnum.NotFoundPlayer;
            }
            else if ( players.Count > 1 )
            {
                _transferResult.errorCode = ErrorCodeEnum.DuplicatePlayer;
            }
            else
            {
                OrganizeTransfer(players[0], newClubName);
            }

            return _transferResult;
        }

        private void OrganizeTransfer( Player player, string newClubName )
        {
            List<Team> teams = _model.Teams.GetTeamByName( newClubName )
                    .ToList();

            if ( teams.Count == 0 )
            {
                _transferResult.errorCode = ErrorCodeEnum.NotFoundTeam;
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
