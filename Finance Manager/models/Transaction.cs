using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Manager.models
{
        public class Transaction
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public int CategoryId { get; set; } 
            public bool IsIncome { get; set; }
            public DateTime TransactionDate { get; set; } 
        }
}
