using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystemData.Interfaces;

namespace RentalSystemData.Repositories
{
    public interface IDataService : IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class, IEntity;
    }
}
