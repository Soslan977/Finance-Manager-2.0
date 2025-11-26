using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance_Manager.models;

namespace Finance_Manager.Services
{
    public class TransactionService
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            transaction.Id = _transactions.Count + 1;
            _transactions.Add(transaction);
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }
    }
}
