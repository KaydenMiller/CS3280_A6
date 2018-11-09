using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Threading;

namespace CS3280_Assignment6.Repositories
{
    /// <summary>
    /// This is a context class to help with getting data from ADO.NET and to use the Repostiory pattern
    /// It is based on information provided at the followin URL
    /// http://blog.gauffin.org/2013/01/ado-net-the-right-way/
    /// </summary>
    public class AdoNetContext : IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly string _connectionString;
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private readonly LinkedList<AdoNetUnitOfWork> _unitOfWorks = new LinkedList<AdoNetUnitOfWork>();

        public AdoNetContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new OleDbConnection(connectionString);
            _connection.Open();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            var transaction = _connection.BeginTransaction() as OleDbTransaction;
            var uow = new AdoNetUnitOfWork(transaction, RemoveTransaction, RemoveTransaction);

            _rwLock.EnterWriteLock();
            _unitOfWorks.AddLast(uow);
            _rwLock.ExitWriteLock();

            return uow;
        }

        public OleDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand() as OleDbCommand;

            _rwLock.EnterReadLock();
            if (_unitOfWorks.Count > 0)
                cmd.Transaction = _unitOfWorks.First.Value.Transaction;
            _rwLock.ExitReadLock();

            return cmd;
        }

        private void RemoveTransaction(AdoNetUnitOfWork obj)
        {
            _rwLock.EnterWriteLock();
            _unitOfWorks.Remove(obj);
            _rwLock.ExitWriteLock();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
