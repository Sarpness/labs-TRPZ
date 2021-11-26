using popCount.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.UnitOfWork
{
    internal interface IUnitOfWork
        : IDisposable
    {
        ICityRepository citys { get; }
        ITaskRepository tasks { get; }
        void Save();
    }
}
