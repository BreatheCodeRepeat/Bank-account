using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuportLaborator11
{
    public class BankTransaction
    {
        public BankTransaction(decimal amount)
        {
            this.amount = amount;
            date = DateTime.Now;
        }

        public decimal Amount()
        {
            return amount;
        }

        public DateTime Date()
        {
            return date;
        }

        private readonly decimal amount;
        private readonly DateTime date;
    }
}
