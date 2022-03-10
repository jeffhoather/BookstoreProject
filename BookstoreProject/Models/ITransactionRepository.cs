using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Models
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> Transactions { get; }

        public void SaveTransaction(Transaction transaction);
    }
}
