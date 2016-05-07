using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SuportLaborator11;

namespace SuportLaborator_11
{
    class Audit
    {
        
        public Audit(string fileName)
        {
            this.fileName = fileName;
            auditFile = File.AppendText(fileName);
        }

        public void RecordTransaction(Object sender, AuditEventArgs eventData)
        {
            BankTransaction t;
            t=eventData.getTransaction();
            auditFile.WriteLine(t.Amount()+" "+t.Date());
        }

        public void Close() {
            bool closed = true;
            if (!closed) {
                this.auditFile.Close();
                closed = true; }
        }


        //   private event Auditing;
        private StreamWriter auditFile;
        private string fileName;

    }
}
