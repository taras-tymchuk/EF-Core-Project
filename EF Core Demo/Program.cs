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
            Controller controller = new Controller( 
                new UnitOfWork( 
                    new FootballContext() ) );

            string fname, lname;

            Console.WriteLine("Enter name of the player you want to transfer.\nFirst name:");
            fname = Console.ReadLine();
            Console.WriteLine("Last name:");
            lname = Console.ReadLine();

            controller.TransferPlayer( fname, lname, Clubs.Barcelona );

            Console.ReadLine();
        }
    }
}
