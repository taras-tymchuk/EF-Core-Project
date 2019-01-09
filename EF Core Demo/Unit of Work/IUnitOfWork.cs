using EF_Core_Demo.Repositories;
using System;

namespace EF_Core_Demo.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        ITeamRepository Teams { get; }

        int Save();
    }
}
