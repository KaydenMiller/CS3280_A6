using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Complete();
    }
}
