using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuportLaborator11;

namespace SuportLaborator_11
{
    class AuditEventArgs: EventArgs
    {
        private readonly BankTransaction transData=null;

        public AuditEventArgs(BankTransaction transData)
        {
            this.transData = transData;
        }

        public BankTransaction getTransaction()
        {
            return transData;
        }

    }
}
