using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Assignment6.Repositories
{
    public class AdoNetUnitOfWork : IUnitOfWork
    {
        private OleDbTransaction _transaction;
        private readonly Action<AdoNetUnitOfWork> _rolledBack;
        private readonly Action<AdoNetUnitOfWork> _commited;

        public OleDbTransaction Transaction { get; private set; }

        public AdoNetUnitOfWork(OleDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBack, Action<AdoNetUnitOfWork> commited)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _commited = commited;
        }

        public void Complete()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("May not call complete changes twice.");
            }

            _transaction.Commit();
            _commited(this);
            _transaction = null;
        }

        public void Dispose()
        {
            if (_transaction == null)
                return;

            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }
    }
}
