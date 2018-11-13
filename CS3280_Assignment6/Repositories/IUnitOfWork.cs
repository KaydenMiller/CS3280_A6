using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    /// <summary>
    /// Interface for UnitOfWork pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
    }
}
