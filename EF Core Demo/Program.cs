using System;
using EF_Core_Demo.BLL;
using EF_Core_Demo.Unit_Of_Work;
using EF_Core_Demo.Context;
using EF_Core_Demo.Constants;

namespace EF_Core_Demo
{
    class Program
    {
        static void Main( string[] args )
        {
            TransferController controller = new TransferController( 
                new UnitOfWork( 
                    new FootballContext() ) );

            string fname, lname;

            Console.WriteLine("Enter name of the player you want to transfer.\nFirst name:");
            fname = Console.ReadLine();
            Console.WriteLine("Last name:");
            lname = Console.ReadLine();

            TransferResult tranferResult = 
                controller.TransferPlayer( fname, lname, Clubs.Barcelona );

            switch ( tranferResult.errorCode )
            {
                case ErrorCodeEnum.Succeded:
                    Console.WriteLine("Transfer was successful!");
                    break;

                case ErrorCodeEnum.DuplicatePlayer:
                    Console.WriteLine( "There are too mane players with such fullname!" );
                    break;

                case ErrorCodeEnum.NotFoundTeam:
                    Console.WriteLine( "No destination team found!" );
                    break;

                case ErrorCodeEnum.NotFoundPlayer:
                    Console.WriteLine( "There are no such player!" );
                    break;

                default:
                    Console.WriteLine("Something weird happened...");
                    break;
            }

            Console.ReadLine();
        }
    }
}
