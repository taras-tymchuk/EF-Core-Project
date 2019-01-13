using System;
using EF_Core_Demo.Context;
using EF_Core_Demo.Models;
using System.Collections.Generic;
using EF_Core_Demo.Unit_Of_Work;
using EF_Core_Demo.Constants;

namespace EF_Core_Demo
{
    class Program
    {
        static void Main( string[] args )
        {
            using ( var uow = new UnitOfWork( new FootballContext() ) )
            {
                Team barca = new Team
                {
                    Name = Clubs.Barcelona,
                    Budget = 1000000
                };
                Team psg = new Team
                {
                    Name = Clubs.PSG,
                    Budget = 10000
                };

                Player p1 = new Player
                {
                    FirstName = "Andriy",
                    LastName = "Yarmolenko",
                    Age = 30,
                    Nationality = Nationalities.Ukrainian,
                    Team = barca
                };
                Player p2 = new Player
                {
                    FirstName = "Lionel",
                    LastName = "Messi",
                    Age = 32,
                    Nationality = Nationalities.Argentinean,
                    Team = barca
                };
                Player p3 = new Player
                {
                    FirstName = "Junior",
                    LastName = "Neymar",
                    Age = 26,
                    Nationality = Nationalities.Brazilian,
                    Team = psg
                };

                uow.Players.AddRange( new List<Player> { p1, p2, p3 } );
                uow.Save();
            }

            using ( var uow = new UnitOfWork( new FootballContext() ) )
            {
                var players = uow.Players.GetUkrainianPlayers();

                Console.WriteLine("Ukrainian players:");
                foreach ( var p in players )
                {
                    System.Console.WriteLine( $"{p.FirstName} {p.LastName}" );
                }

                Console.WriteLine("\nPlayers of Barelona:");
                var teams = uow.Teams.GetListOfPlayers( Clubs.Barcelona );
                foreach ( var t in teams )
                {
                    foreach ( var p in t.Players )
                    {
                        System.Console.WriteLine( $"{p.FirstName} {p.LastName} " +
                            $"is {p.Age} years old." );
                    }
                    
                }
            }

            using ( var uow = new UnitOfWork( new FootballContext() ) )
            {
                uow.Teams.RemoveByTeamName( Clubs.Barcelona );
                uow.Save();
            }

            using ( var uow = new UnitOfWork( new FootballContext() ) )
            {
                var teams = uow.Teams.GetAll();

                Console.WriteLine("Teams:");
                foreach ( var team in teams )
                {
                    Console.WriteLine( $"{team.Name} {team.Budget}" );
                }

                var players = uow.Players.GetAll();

                Console.WriteLine( "Players:" );
                foreach ( var player in players )
                {
                    Console.WriteLine( $"{player.FirstName} {player.LastName}" );
                }
            }

            Console.ReadLine();
        }
    }
}
